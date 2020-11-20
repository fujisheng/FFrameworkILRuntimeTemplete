using Framework.IL.Hotfix.Module.UI;
using UnityEngine.UI;

namespace Game.Hotfix
{
    class HomeView : View
    {
        public override void Init()
        {
            base.Init();
            resourceLoader.Get<Text>("111111111");
        }

        [BindProperty("Name")]
        void OnChangedName(string oldValue, string newValue)
        {
            string a = newValue;
        }
    }
}
