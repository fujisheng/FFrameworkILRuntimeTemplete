using Framework.ILR.Service.UI;
using UnityEngine;

namespace Game.Hotfix
{

    public class PublicViewModel : ViewModel, IPerloadViewModel
    {
        BindableProperty<string> title = new BindableProperty<string>("Hello ILRuntime");
        BindableProperty<int> age = 1000;

        public override void Initialize()
        {
            base.Initialize();
            Debug.Log("PublicViewModelInit");
        }
    }
}
