using Framework.ILR.Service.UI;
using UnityEngine;

namespace Game.Hotfix
{

    public class HomeViewModel : ViewModel, IPerloadViewModel
    {
        BindableProperty<string> title = "Hello ILRuntime";
        BindableProperty<int> age = 1000;

        public override void Initialize()
        {
            base.Initialize();
            title.Value = "sssss";
            Debug.Log("HomeViewModelInit");
        }
    }
}
