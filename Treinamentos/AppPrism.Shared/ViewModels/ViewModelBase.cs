using Prism.AppModel;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppPrism.Shared.ViewModels
{
    public class ViewModelBase : BindableBase, IDestructible, INavigationAware, IConfirmNavigation, IApplicationLifecycleAware, IPageLifecycleAware
    {
        protected INavigationService _navigationService;
        protected IPageDialogService _pageDialogService;

        public ViewModelBase(IPageDialogService pageDialogService,  INavigationService navigationService)
        {
            _pageDialogService = pageDialogService;
            _navigationService = navigationService;
        }

        private Task<bool> _taskInit;
        protected Task<bool> TaskInit { get => _taskInit; set => _taskInit = value; }

        string _pageTitle;
        public virtual string PageTitle
        {
            get => _pageTitle;
            set => SetProperty(ref _pageTitle, value);
        }

        #region INavigationAware

        /// <summary>
        ///OnNavigatingTo intercept before the View is navigated to  - OnNavigatingTo is not called when using device hardware or software back button.
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        public virtual void OnNavigatingTo(INavigationParameters parameters) { }

        /// <summary>
        /// once it is navigated to - raises when you come from the other page to this page
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            //get a single parameter as type object, which must be cast
            // var invite = parameters["inviteParam"] as Invite;

            //get a single typed parameter
            //var invite = parameters.GetValue<Invite>("inviteParam");
            //Item = invite;
            //get a collection of typed parameters
            // var invites = parameters.GetValues<Invite>("colors");
        }

        /// <summary>
        ///  Raise when you navigated from this page to the other page
        /// </summary>
        /// <param name="parameters">Parameters.</param>
        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

        #endregion INavigationAware

        #region IDestructible

        public virtual void Destroy() { }

        #endregion IDestructible

        #region IConfirmNavigation

        public virtual bool CanNavigate(INavigationParameters parameters) => true;

        public virtual Task<bool> CanNavigateAsync(INavigationParameters parameters) =>
            Task.FromResult(CanNavigate(parameters));

        #endregion IConfirmNavigation

        #region IApplicationLifecycleAware

        public virtual void OnResume() { }

        public virtual void OnSleep() { }

        #endregion IApplicationLifecycleAware

        #region IPageLifecycleAware

        public virtual void OnAppearing() { }

        public virtual void OnDisappearing() { }

        #endregion IPageLifecycleAware

    }
}
