using Android.Text;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppPrism.Shared.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {

        string _email;
        public virtual string Email
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
        public virtual string Senha
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


        public LoginPageViewModel(IPageDialogService pageDialogService, INavigationService navigationService) : base(pageDialogService, navigationService)
        {
            EmailError = false; SenhaError = false;
            base.PageTitle = "Titulo do App";
        }

        //Criar um delegate Command para executar um comando da página
        private Prism.Commands.DelegateCommand _loginCommand;
        public Prism.Commands.DelegateCommand LoginCommand => _loginCommand ?? (_loginCommand = new DelegateCommand(async () => await LoginAsync()));

        public bool IsAuthenticated { get;  set; }

        private async Task LoginAsync()
        {
            if (!Email.Contains("mduarte_mct@hotmail.com"))
            {
                EmailError = true;
                IsAuthenticated = false;
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
            }
            else
            {
                SenhaError = false;
                IsAuthenticated = true;
            }
            if (IsAuthenticated)
            {
                await base._navigationService.NavigateAsync("HomePage");
            }
        }



    }
}
