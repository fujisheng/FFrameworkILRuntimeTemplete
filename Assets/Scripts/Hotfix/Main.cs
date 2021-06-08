using Framework.ILR.Service.Script;
using Framework.ILR.Service.UI;

namespace Game.Hotfix
{
    public static class Main
    {
        public static void Initialize(IScriptService scriptManager)
        {
            //HomeView homeView = new HomeView();
            //UnityEngine.Debug.Log($"homeViewType=>{homeView.GetType()}");
            //Test.ShowType(homeView.GetType());
            //Test.ShowType<HomeView>();
            //homeView.OnChangedName(null, "nihaoaaoaoao");
            Contexts.Initialize(scriptManager);
            OpenView<HomeView>();
            OpenView<HomeView, PublicViewModel>();
        }

        static async void OpenView<TView>() where TView : IView
        {
            var context = Contexts.Create<TView>();
            var view = await context.CreateView();
            context.BindingWithAttribute(view);
            context.SetProperty("title", "sssssssssssssssss");
            context.SetProperty("age", 10000, true);
        }

        static async void OpenView<TView, TViewModel>() where TView : IView where TViewModel : IViewModel
        {
            var context = Contexts.Create<TViewModel, TView>();
            var view = await context.CreateView();
            context.BindingWithAttribute(view);
            context.SetProperty("title", "我是通过PublicViewModel 设置的");
            context.SetProperty("age", 1000);
        }
    }
}