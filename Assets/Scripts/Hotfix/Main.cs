using Framework.ILR.Module.Script;
using Framework.ILR.Module.UI;

namespace Game.Hotfix
{
    public static class Main
    {
        public static void Initialize(IScriptManager scriptManager)
        {
            Contexts.Initialize(scriptManager);
            OpenView<HomeView>();
            OpenView<HomeView, PublicViewModel>();
        }

        static async void OpenView<TView>() where TView : IView
        {
            var context = Contexts.Create<TView>();
            var view = await context.CreateView();
            context.BindWithAttribute(view);
            context.SetValue("title", "sssssssssssssssss");
            context.SetValue("age", 10000, true);
        }

        static async void OpenView<TView, TViewModel>() where TView : IView where TViewModel : IViewModel
        {
            var context = Contexts.Create<TViewModel, TView>();
            var view = await context.CreateView();
            context.BindWithAttribute(view);
            context.SetValue("title", "我是通过PublicViewModel 设置的");
            context.SetValue("age", 1000);
        }
    }
}