using AppPrism.Shared.Interfaces;
using AppPrism.Shared.Models;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AppPrism.Shared.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private readonly ICloudService _cloudService;

        private ObservableCollection<string> _options = new ObservableCollection<string> {"Facebook", "Google", "Microsoft" };
        public ObservableCollection<string> Options
        {
            get => _options;
            set => SetProperty(ref _options, value);
        }


        string _email;
        public  string Email
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
        public  string Senha
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


        public LoginPageViewModel(IPageDialogService pageDialogService, INavigationService navigationService, ICloudService cloudService) : base(pageDialogService, navigationService)
        {
            _cloudService = cloudService;
             EmailError = false; SenhaError = false;
            base.PageTitle = "Titulo do App";
        }

        //Criar um delegate Command para executar um comando da página
        #region Comando de Login com Delegate

        private Prism.Commands.DelegateCommand _loginCommand;
        public Prism.Commands.DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(async () => await LoginAsync()));

        public bool IsAuthenticated { get;  set; }
        private async Task LoginAsync()
        {
            IsBusy = true;
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Senha))
            {
                await _pageDialogService.DisplayAlertAsync("Campos Incompletos", "Email e/ou Senha não podem estar vazios", "Ok");
                IsAuthenticated = false;
                IsBusy = false;
                return;
            }
            await Task.Delay(5000);

            //IsBusy = true;
            if (!Email.Contains("mduarte_mct@hotmail.com"))
            {
                EmailError = true;
                IsAuthenticated = false;
                IsBusy = false;
            }
            else
            {
                EmailError = false;
               // IsAuthenticated = true;
            }
            if (!Senha.Contains("xpto") )
            {
                SenhaError = true;
                IsAuthenticated = false;
                IsBusy = false;
            }
            else
            {
                SenhaError = false;
                IsAuthenticated = true;
            }
            //Faz o teste para pegar dados no Azure
            //var table = App.CloudService.GetTable<TodoItem>();
            var table = _cloudService.GetTable<TodoItem>();
            var list = await table.ReadAllItemsAsync();
            if (list.Count > 0)
            {
              await  _pageDialogService.DisplayAlertAsync("Dados Recuperados do Azure", "Item: " + list.First().Text, "Perfeito");

            }

            if (IsAuthenticated)
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

        #region Comando de Recuperar a Senha reduzido com Delegate
        public DelegateCommand RecuperarSenhaCommand => new DelegateCommand(async () => await _navigationService.NavigateAsync("/RecoveryPasswordPage" ));

        #endregion  Comando de Recuperar a Senha reduzido com Delegate

        public DelegateCommand CriarContaCommand => new DelegateCommand(async () => await _navigationService.NavigateAsync("/CreateLoginPage"));

        #region Comando de Login com Azure AD

        private Prism.Commands.DelegateCommand _loginAdCommand;
        public Prism.Commands.DelegateCommand LoginAdCommand => _loginAdCommand ?? (_loginAdCommand = new DelegateCommand(async () => await LoginAdAsync()));

        private async Task LoginAdAsync()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            IsAuthenticated = false;
            try
            {
                await _cloudService.LoginAsync();
                IsAuthenticated = true;
                //Faz o teste para pegar dados no Azure
                //var table = App.CloudService.GetTable<TodoItem>();
                var table = _cloudService.GetTable<TodoItem>();
                var list = await table.ReadAllItemsAsync();
                if (list.Count > 0)
                {
                    await _pageDialogService.DisplayAlertAsync("Dados Recuperados do Azure", "Item: " + list.First().Text, "Autenticado");
                   
                }

                if (IsAuthenticated)
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
            catch (Exception ex)
            {
                Debug.WriteLine($"[ExecuteLoginCommand] Error = {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion Comando de Login com Azure AD


    }
}
