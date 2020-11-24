using Framework.IL.Hotfix.Module.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Hotfix
{
    public class HomeViewModel : ViewModel
    {
        BindableProperty<string> title = new BindableProperty<string>("Hello ILRuntime");

        public override void Init()
        {
            base.Init();
        }
    }
}
