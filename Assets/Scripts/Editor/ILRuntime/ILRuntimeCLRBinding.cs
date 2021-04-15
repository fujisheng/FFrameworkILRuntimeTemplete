#if UNITY_EDITOR
using Game.Local.ILR.Reginster;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Game.Editor
{
    [System.Reflection.Obfuscation(Exclude = true)]
    public class ILRuntimeCLRBinding
    {
        [MenuItem("ILRuntime/通过自动分析热更DLL生成CLR绑定")]
        static void GenerateCLRBindingByAnalysis()
        {
            //用新的分析热更dll调用引用来生成绑定代码
            ILRuntime.Runtime.Enviorment.AppDomain domain = new ILRuntime.Runtime.Enviorment.AppDomain();
            LoadDll(domain, "Assets/Sources/Code/Game.Hotfix.dll.bytes", out MemoryStream gameStream);

            //Crossbind Adapter is needed to generate the correct binding code
            var reginster = new ILRuntimeReginster();
            reginster.Reginster(domain);

            ILRuntime.Runtime.CLRBinding.BindingCodeGenerator.GenerateBindingCode(domain, "Assets/Scripts/Local/ILRuntime/Generated");

            AssetDatabase.Refresh();
        }

        static void LoadDll(ILRuntime.Runtime.Enviorment.AppDomain domain , string dllName, out MemoryStream dllStream)
        {
            TextAsset dllAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(dllName);
            dllStream = new MemoryStream(Framework.Utility.Encryption.AESDecrypt(dllAsset.bytes));

            domain.LoadAssembly(dllStream);
        }
    }
}
#endif
