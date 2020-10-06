using AppPrism.Shared.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppPrism.Shared.ViewModels
{
    //A viewModel da página que vai receber os parametros que são passados usando Prism precisa implementar a interface INavigationAware
    public class ProfileViewModel : INavigationAware
    {
        private readonly INavigationService _navigationService;
        //Usado para mostrar uma caixa Popup para usuário no IoS ou Android
        private readonly IPageDialogService _pageDialogService;
        public string PageTitle { get; set; }

      

        public ProfileViewModel(IPageDialogService pageDialogService, INavigationService navigationService)
        {
            _navigationService = navigationService;
            PageTitle = "PageTitle = Profile";
            _pageDialogService = pageDialogService;

        }


        //Criar um delegate Command para executar um comando da página
        private Prism.Commands.DelegateCommand _alertCommand;
        public Prism.Commands.DelegateCommand AlertCommand => _alertCommand ?? (_alertCommand = new DelegateCommand(async () => await AlertAsync()));

        private async Task AlertAsync()
        {
            var action = await _pageDialogService.DisplayActionSheetAsync("ActionSheet: Enviar para onde?", "Cancel", null, "Email", "Twitter", "Facebook");
            //Debug.WriteLine("Action: " + action); // writes the selected button label to the console
            await _pageDialogService.DisplayAlertAsync(" Você selecionou...", action, "Ok");
        }

        //Criar um delegate Command para executar um comando da página
        private Prism.Commands.DelegateCommand _backCommand;
        public Prism.Commands.DelegateCommand GoBackCommand => _backCommand ?? (_backCommand = new DelegateCommand(async () => await GoBackAsync()));

        private async Task GoBackAsync()
        {
            await _navigationService.GoBackAsync();
        }



        //Disparado quando você navega desta página para a outra página - 
        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            _pageDialogService.DisplayAlertAsync("OnNavigatedFrom", "Navegando para outra Página", "OK");
        }

        //uma vez que é navegado para - disparado quando você vem de outra página (ou viewModel) para esta página (ou ViewModel)
        public void OnNavigatedTo(INavigationParameters parameters)
        {
            UserProfile _profile = null;
            //Verifica se o parametroexiste
            if (parameters.ContainsKey("_paramProfile"))
            {
               //Pega o Parametro do tipo objeto
                 _profile = parameters.GetValue<UserProfile>("_paramProfile");
            }
            else
            {
                
            }
            _pageDialogService.DisplayAlertAsync("OnNavigatedTo", "Navegando de outra Página para essa com parametro Profile: " + _profile.Name, "OK");
        }

        // Vai interceptar os parametros do objeto que chamou essa viewModel antes que a Visualização seja navegada - OnNavigatingTo não é chamado ao usar o hardware do dispositivo ou o botão Voltar do software.
        public virtual void OnNavigatingTo(INavigationParameters parameters)
        { 

        }
    }
}
