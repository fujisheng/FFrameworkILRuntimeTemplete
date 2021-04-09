using Framework.Module.FSM;
using ILHotfix;
using System;
using UnityEngine;

namespace Game
{
    public class LoadModuleState : State<Launcher>
    {
        public override async void OnEnter(IFSM<Launcher> fsm)
        {
            Modules.Script.InvokeMethod("Game.Hotfix.Main", "Initialize", null, new object[] {Modules.Script});

            Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            var classType = typeof(TestClass);
            var methodName = $"{classType.FullName}.{classType.GetMethod("Add").Name}";
            Hotfix.Reginster(methodName, (typeName, mnt, instance, args)=>{
                Debug.Log($"methodName=>{mnt}");
                foreach (var arg in args)
                {
                    Debug.Log($"arg=>{arg}");
                }

                //string typeName = mnt.Remove(mnt.LastIndexOf("."), mnt.Length); 
                //string mn = mnt.Remove(0, mnt.LastIndexOf("."));
                //Debug.Log($"typeName=>{typeName} methodName=>{methodName}");
                Modules.Script.InvokeMethod(typeName + "_Hotfix", "SetOrigin", null, instance);
                return Modules.Script.InvokeMethod(typeName + "_Hotfix", mnt, null, args);
            });
            var test = new TestClass();
            Debug.Log($"1 + 2 = {test.Add(1, 2)}");
        }

        public override void OnUpdate(IFSM<Launcher> fsm)
        {
            //scriptManager.OnUpdate();
            //scriptManager.OnLateUpdate();
        }
    }
}