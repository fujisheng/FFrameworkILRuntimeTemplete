using Framework.ILR.Service.UI;
using UnityEngine;

namespace Game.Hotfix
{
    [Binding(typeof(HomeViewModel), Layer.NORMAL, Flag.CACHE, "HomeView")]
    public class HomeView : View
    {
        public override void Initialize()
        {
            base.Initialize();
        }

        public override void OnOpen(object param)
        {
            base.OnOpen(param);
        }

        [OnValueChanged("title")]
        public void OnChangedName(string oldValue, string newValue)
        {
            Debug.Log($"OnChanedTitle=>{newValue}");
        }

        [OnValueChanged("age")]
        public void OnChangedAge(int oldValue, int newValue)
        {
            Debug.Log($"OnChangedAge=>{newValue}");
        }
    }
}
