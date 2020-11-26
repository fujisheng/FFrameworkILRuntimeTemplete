using Framework.IL.Hotfix.Module.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Hotfix
{
    [Bind("HomeViewModel", Layer.NORMAL, B.CACHE)]
    public class HomeView : View
    {
        public override void Init()
        {
            base.Init();
            Image image;
        }

        public override void OnOpen(object param)
        {
            base.OnOpen(param);
        }

        [BindProperty("title")]
        void OnChangedName(string oldValue, string newValue)
        {
            Debug.Log($"OnChangedTitle=>{newValue}");
        }
    }
}
