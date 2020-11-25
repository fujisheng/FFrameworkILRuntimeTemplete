using Framework.IL.Hotfix.Module.UI;
using System.Collections.Generic;

namespace Game.Hotfix
{
    
    public class HomeViewModel : ViewModel
    {
        BindableProperty<string> title = new BindableProperty<string>("Hello ILRuntime");
        List<int> aaa = new List<int>();

        public override void Init()
        {
            base.Init();
        }
    }
}
