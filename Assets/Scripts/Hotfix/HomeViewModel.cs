using Framework.IL.Hotfix.Module.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Hotfix
{
    
    public class HomeViewModel : ViewModel//,IPerloadViewModel
    {
        int aaa = 21;
        BindableProperty<string> title = new BindableProperty<string>("Hello ILRuntime");
        List<int> bbb = new List<int>();

        public override void Init()
        {
            base.Init();
            Debug.Log("HomeViewModelInit");
        }
    }
}
