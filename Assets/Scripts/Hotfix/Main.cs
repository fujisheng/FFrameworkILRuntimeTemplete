using Framework.IL.Hotfix.Module.UI;
using UnityEngine;

namespace Game.Hotfix
{
    public static class Main
    {
        public static void Initialize()
        {
            OpenView<HomeView>();
        }

        static async void OpenView<TView>()
        {
            var viewType = typeof(TView);
            string viewName = viewType.Name;
            var context = Contexts.GetOrCreate<HomeViewModel, HomeView>();
            var view = await context.CreateView();
            context.BindWithAttribute(view);
            context.SetValue<string>("title", "sssssssssssssssss");
        }

        
    }
}