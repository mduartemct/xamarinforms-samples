using AppPrism.Shared.Interfaces;
using AppPrism.Shared.Services;
using AppPrism.Shared.ViewModels;
using AppPrism.Shared.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Navigation;
using System.Diagnostics;
using Xamarin.Forms;

namespace AppPrism.Shared
{
    //Para usar o Prim é necessário informar que App agora herda da classe base PrismApplication
    //Também é necessário fazer essa mudança na TAG xaml da App.xaml
    public partial class App : PrismApplication
    {
        public static ICloudService CloudService { get; set; }

        //Para usar Prism tb é necessário criar ao menos esses dis construtores
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        //Para usar Prism tb vamos sobrescrever OnInitialized
        protected override void OnInitialized()
        {

            InitializeComponent();

            //CloudService = new AzureCloudServices();
           
            //Aqui vamos navegar para a primeira página com o prims
            // NavigationService.NavigateAsync("HomePage");
            NavigationService.NavigateAsync("/LoginPage");
        }

        //Sobrescrever para poder registrar os tipo com o Prism e DryIoc
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //obrigatorio que seja registrado para que possamos utilizar em qualquer página ou viewModel para navegaçao 
            containerRegistry.RegisterForNavigation<NavigationPage>();

            //Resgistro de uma página que não tem ViewModel:
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            //Registrando uma Page e a ViewModel sem usar nomeclatura padrão
            containerRegistry.RegisterForNavigation<Views.ProfilePage, ProfileViewModel>();
            containerRegistry.RegisterForNavigation<Views.TabbedPage1>();
            containerRegistry.RegisterForNavigation<Views.TabbedPage2>();
            containerRegistry.RegisterForNavigation<Views.LoginPage>();
            containerRegistry.RegisterForNavigation<RecoveryPasswordPage>();
            containerRegistry.RegisterForNavigation<CreateLoginPage, CreateLoginViewModel>();

            //Registro de Serviços
            containerRegistry.Register<ICloudService, AzureCloudServices>();

        }

        protected override void OnStart()
        {
            Debug.WriteLine("OnStart");
        }
        protected override void OnSleep()
        {
            Debug.WriteLine("OnSleep");
        }
        protected override void OnResume()
        {
            Debug.WriteLine("OnResume");
        }
    }
}
