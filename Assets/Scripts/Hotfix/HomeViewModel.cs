using Framework.ILR.Service.UI;
using UnityEngine;

namespace Game.Hotfix
{

    public class HomeViewModel : ViewModel, IPerloadViewModel
    {
        public BindableProperty<string> title = "Hello ILRuntime";
        public BindableProperty<int> age = 1000;

        public override void Initialize()
        {
            base.Initialize();
            title.Value = "sssss";
            int a = age;
            Debug.Log($"2==age {2 == age}");
            Debug.Log("HomeViewModelInit");
        }
    }
}
