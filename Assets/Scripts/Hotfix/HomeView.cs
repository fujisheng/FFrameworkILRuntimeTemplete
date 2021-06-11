using Framework.ILR.Service.UI;
using UnityEngine;

namespace Game.Hotfix
{
    [Binding(typeof(HomeViewModel))] //必须有的
    [Config(assetName: "HomeView", layer: Layer.NORMAL, flag: Flag.CACHE)] //可以不存在 这样都会取默认值
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

        [OnValueChanged("title")] //当绑定的ViewModel的title属性更改的时候触发
        public void OnChangedName(string oldValue, string newValue)
        {
            Debug.Log($"OnChanedTitle=>{newValue}");
        }

        [OnValueChanged("age")] //当绑定的ViewModel的age属性更改的时候触发
        public void OnChangedAge(int oldValue, int newValue)
        {
            Debug.Log($"OnChangedAge=>{newValue}");
        }
    }
}
