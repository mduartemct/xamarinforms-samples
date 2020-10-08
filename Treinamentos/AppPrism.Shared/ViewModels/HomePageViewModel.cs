using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPrism.Shared.ViewModels
{
    public class HomePageViewModel
    {
        INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;

        public HomePageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
        }
        

        //Criar um delegate Command para executar um comando da página
        private Prism.Commands.DelegateCommand _myCommand;
        public DelegateCommand MyCommand => _myCommand ?? (_myCommand = new DelegateCommand(async () => await MyCommandAsync()));

        private async Task MyCommandAsync()
        {
            //Criar um objeto e passar ele como parametro usando o Prism
           
            Models.UserProfile profile = new Models.UserProfile { Name = "Marcelo Duarte", Email = "mduarte_mct@hotmail.com" };
            //1 - Instancia do objeto NavigationParameters
            INavigationParameters _param = new NavigationParameters();
            _param.Add("_paramProfile", profile);

           await _navigationService.NavigateAsync("ProfilePage",_param );
        }


        private Prism.Commands.DelegateCommand _goToTabbedInLineCommand;
        public DelegateCommand GoToTabbedInLineCommand => _goToTabbedInLineCommand ?? (_goToTabbedInLineCommand = new DelegateCommand(async () => await GoToTabbedInLineAsync()));

        private async Task GoToTabbedInLineAsync()
        {
          var rs=  await _navigationService.NavigateAsync("TabbedPage2");
            try
            {
                if (!rs.Success)
                {
                    throw new Exception("Navegação sem Sucesso");
                }
            }
            catch (Exception ex)
            {
                _pageDialogService.DisplayAlertAsync("Ops...ocorreu um problema...", "Tivemos um problema de execução. Vamos avaliar o que aconteceu.", "Ok");
            }
          
        }

        //TabbedPage 
        private Prism.Commands.DelegateCommand _goToTabbedInPageCommand;
        public DelegateCommand GoToTabbedInPageCommand => _goToTabbedInPageCommand ?? (_goToTabbedInPageCommand = new DelegateCommand(async () => await GoToTabbedInPageAsync()));

        private async Task GoToTabbedInPageAsync()
        {
            var rs = await _navigationService.NavigateAsync("TabbedPage1");
            try
            {
                if (!rs.Success)
                {
                    throw new Exception("Navegação sem Sucesso");
                }
            }
            catch (Exception ex)
            {
                _pageDialogService.DisplayAlertAsync("Ops...ocorreu um problema...", "Tivemos um problema de execução. Vamos avaliar o que aconteceu.", "Ok");
            }

        }

        //LoginPage 
        private Prism.Commands.DelegateCommand _goLoginPageCommand;
        public DelegateCommand GoToLoginPageCommand => _goLoginPageCommand ?? (_goLoginPageCommand = new DelegateCommand(async () => await GoToLoginPageAsync()));

        private async Task GoToLoginPageAsync()
        {

            try
            {
                var rs = await _navigationService.NavigateAsync("LoginPage");
                //if (!rs.Success)
                //{
                //    throw new Exception("Navegação sem Sucesso");
                //}
            }
            catch (Exception ex)
            {
                _pageDialogService.DisplayAlertAsync("Ops...ocorreu um problema...", "Tivemos um problema de execução. Vamos avaliar o que aconteceu.", "Ok");
            }

        }

    }
}
