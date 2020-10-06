using AppPrism.Shared.ViewModels;
using AppPrism.Shared.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Navigation;
using Xamarin.Forms;

namespace AppPrism.Shared
{
    //Para usar o Prim é necessário informar que App agora herda da classe base PrismApplication
    //Também é necessário fazer essa mudança na TAG xaml da App.xaml
    public partial class App : PrismApplication
    {

        //Para usar Prism tb é necessário criar ao menos esses dis construtores
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        //Para usar Prism tb vamos sobrescrever OnInitialized
        protected override void OnInitialized()
        {

            InitializeComponent();

            //Aqui vamos navegar para a primeira página com o prims
            NavigationService.NavigateAsync("HomePage");
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


        }

    }
}
