using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace AppPrism.Shared.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : Xamarin.Forms.TabbedPage
    {
        public TabbedPage1()
        {
            InitializeComponent();
            //Setar para não navegar Inline
            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);

            //Set top margin in IPhone X or latter
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            //set to  use large titles in IPhone X or latter
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Always);
            Title = "Home";
            CurrentPageChanged += CurrentPageHasChanged;
        }

        protected void CurrentPageHasChanged(object sender, EventArgs e)
        { Title = CurrentPage.Title; }
    }
}