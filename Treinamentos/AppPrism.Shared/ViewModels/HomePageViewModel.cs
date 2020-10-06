using Prism.Commands;
using Prism.Navigation;
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

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
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
    }
}
