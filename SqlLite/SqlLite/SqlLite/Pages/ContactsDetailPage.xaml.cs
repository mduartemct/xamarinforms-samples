using SqlLite.Persistence;
using SqlLite.Repositories;
using SqlLite.Services;
using SqlLite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SqlLite.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsDetailPage : ContentPage
    {
        public ContactsDetailPage(ContactViewModel viewModel)
        {
            InitializeComponent();

            var contactStore = new SQLiteContactRepository(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            Title = (viewModel.Phone == null) ? "New Contact" : "Edit Contact";
            BindingContext = new ContactsDetailViewModel(viewModel ?? new ContactViewModel(), contactStore, pageService);
        }
    }
}