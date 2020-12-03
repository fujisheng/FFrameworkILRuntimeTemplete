using Framework.IL.Hotfix.Module.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Hotfix
{
    
    public class PublicViewModel : ViewModel, IPerloadViewModel
    {
        BindableProperty<string> title = new BindableProperty<string>("Hello ILRuntime");
        IntBp age = new IntBp(1000);

        public override void Initialize()
        {
            base.Initialize();
            Debug.Log("PublicViewModelInit");
        }
    }
}
