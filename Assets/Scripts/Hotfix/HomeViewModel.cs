using Framework.IL.Hotfix.Module.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Hotfix
{
    
    public class HomeViewModel : ViewModel, IPerloadViewModel
    {
        BindableProperty<string> title = new BindableProperty<string>("Hello ILRuntime");
        IntBp age = new IntBp(1000);

        public override void Init()
        {
            base.Init();
            Debug.Log("HomeViewModelInit");
        }
    }
}
