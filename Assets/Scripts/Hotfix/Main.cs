using Framework.IL.Hotfix.Module.UI;
using System;
using UnityEngine;

namespace Game.Hotfix
{
    public static class Main
    {
        public static void Initialize()
        {
            Contexts.Init();
            OpenView<HomeView>();
        }

        static async void OpenView<TView>() where TView : IView
        {
            var context = Contexts.Create<TView>();
            var view = await context.CreateView();
            context.BindWithAttribute(view);
            context.SetValue<string>("title", "sssssssssssssssss");
        }

        static async void OpenView<TView, TViewModel>() where TView : IView where TViewModel : IViewModel
        {
            var context = Contexts.Create<TViewModel, TView>();
            var view = await context.CreateView();
            context.BindWithAttribute(view);
            context.SetValue<string>("title", "sssssssssssssssss");
        }
    }
}