using AppPrism.Shared.Models;
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
    public class CreateLoginViewModel : ViewModelBase
    {
        string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        bool _emailError;
        public virtual bool EmailError
        {
            get => _emailError;
            set => SetProperty(ref _emailError, value);
        }

        string _senha;
        public string Senha
        {
            get => _senha;
            set => SetProperty(ref _senha, value);
        }

        bool _senhaError;
        public virtual bool SenhaError
        {
            get => _senhaError;
            set => SetProperty(ref _senhaError, value);
        }
        public CreateLoginViewModel(IPageDialogService pageDialogService, INavigationService navigationService) : base(pageDialogService, navigationService)
        {
            //IPageDialogService pageDialogService, INavigationService navigationService) : base(pageDialogService, navigationService)
        }

        #region Comando de Login com Delegate

        private Prism.Commands.DelegateCommand createLoginCommand;
        public Prism.Commands.DelegateCommand CreateLoginCommand => createLoginCommand ?? (createLoginCommand = new DelegateCommand(async () => await CreateLoginAsync()));

        public bool IsCreated { get; set; }
        private async Task CreateLoginAsync()
        {
            var x = Xamarin.Essentials.Connectivity.NetworkAccess;
            
            var profiles = Xamarin.Essentials.Connectivity.ConnectionProfiles;
            if (profiles.Contains(Xamarin.Essentials.ConnectionProfile.WiFi))
            {
                // Active Wi-Fi connection.
            }

            IsBusy = true;
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Senha))
            {
                await _pageDialogService.DisplayAlertAsync("Campos Incompletos", "Email e/ou Senha não podem estar vazios", "Ok");
                IsCreated = false;
                IsBusy = false;
                return;
            }

            try
            {
                //Criar os dados no Azure
                //1 - Pegue a entidade com a qual vai trabalhar!
                var _appUserTable = App.CloudService.GetTable<AppUser>();

                //2 - Instanciar o objeto
                var _appUser = new AppUser { Email = this.Email, AuthenticationMethod = Senha };

                //2 - Execute a operação de CRUD necessária
                var ret = await _appUserTable.CreateItemAsync(_appUser);

                if (ret!=null)
                {
                    await _pageDialogService.DisplayAlertAsync("Conta Criada", "Conta Criada com Sucesso", "OK");
                }
            }
            catch (Exception)
            {

                throw;
            }
      
         

            if (IsCreated)
            {
                IsBusy = false;
                await base._navigationService.NavigateAsync("/HomePage");
            }
            else
            {
                //IsBusy = false;
            }
            IsBusy = false;
        }

        #endregion Comando de Login com Delegate



    }
}
