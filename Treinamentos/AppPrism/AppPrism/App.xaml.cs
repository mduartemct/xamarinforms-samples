using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppPrism.Services;
using AppPrism.Views;
using Prism.DryIoc;
using Prism;
using Prism.Ioc;

namespace AppPrism
{
    public partial class App : PrismApplication
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }


        protected override void OnInitialized()
        {
            InitializeComponent();

            // NavigationService.NavigateAsync("EntryPage");

        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();


        }

    }
}
