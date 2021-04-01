using Framework.ILR.Module.UI;
using UnityEngine;

namespace Game.Hotfix
{
    [Bind(typeof(HomeViewModel), Layer.NORMAL, Flag.CACHE, "HomeView")]
    public class HomeView : View
    {
        public override void Initialize()
        {
            base.Initialize();
        }

        //sssssssss
        public override void OnOpen(object param)
        {
            base.OnOpen(param);
        }

        [BindProperty("title")]
        public void OnChangedName(string oldValue, string newValue)
        {
            Debug.Log($"OnChanedTitle=>{newValue}");
        }

        [BindProperty("age")]
        public void OnChangedAge(int oldValue, int newValue)
        {
            Debug.Log($"OnChangedAge=>{newValue}");
        }
    }
}
