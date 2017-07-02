using MyGarageSale.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyGarageSale
{
    public partial class App : Application
    {
        public static MasterDetailPage Master { get; internal set; }
        public static NavigationPage Navigator { get; set; }

        public App()
        {
            try
            {
                InitializeComponent();

                MainPage = new LoginPage();
                MainPage.Appearing += MainPage_Appearing;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void MainPage_Appearing(object sender, EventArgs e)
        {
           // MainPage.BindingContext = new ViewModels.LoginViewModel();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
