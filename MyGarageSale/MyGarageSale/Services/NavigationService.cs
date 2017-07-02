using MyGarageSale.Views;
using MyGarageSale.Views.FavouritePage;
using MyGarageSale.Views.GaragePages;
using MyGarageSale.Views.MessagePages;
using MyGarageSale.Views.ProfilePages;
using MyGarageSale.Views.SearchPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyGarageSale.Services
{
    public class NavigationService
    {
        public const string SAFETY_PAGE_NEW = "SafetyPageNew";
        public const string SAFETY_PAGE_LIST = "SafetyPageList";

        public static async void Navigate(string pageName)
        {
            App.Master.IsPresented = false;
            switch (pageName)
            {
                case "HomePage":
                    await Navigate(new HomePage());
                    break;
                case "FavouritePage":
                    await Navigate(new FavouritePage());
                    break;
                case "SalePage":
                    //await Navigate(new SearchPage());
                    await Navigate(new SearchTabPage());
                    break;
                case "MessagePage":
                    await Navigate(new MessagePage());
                    break;
                case "ProfilePage":
                    await Navigate(new ProfilePage());
                    break;
                case "GaragePage":
                    await Navigate(new GaragePage());
                    break;
                default:
                    break;
            }
        }

        public static async void GoBack()
        {
            await App.Navigator.PopAsync();
        }

        //public static async void Navigate(string pageName, Object viewModel)
        //{
        //    App.Master.IsPresented = false;
        //    switch (pageName)
        //    {
        //        case "HomePage":
        //            await Navigate(new HomePage((HomePageViewModel)viewModel));
        //            break;
        //        case "FavouritePage":
        //            await Navigate(new FavouritePage((FavouritePageViewModel)viewModel));
        //            break;
        //        case "SalePage":
        //            //await Navigate(new SearchPage());
        //            await Navigate(new SearchTabPage((SearchPageViewModel)viewModel));
        //            break;
        //        case "MessagePage":
        //            await Navigate(new MessagePage((MessagePageViewModel)viewModel));
        //            break;
        //        case "ProfilePage":
        //            await Navigate(new ProfilePage((ProfilePageViewModel)viewModel));
        //            break;
        //        default:
        //            break;
        //    }
        //}

        private static async Task Navigate<T>(T page) where T : Page
        {
            NavigationPage.SetHasBackButton(page, true);
            NavigationPage.SetBackButtonTitle(page, "Back");
            await App.Navigator.PushAsync(page);
        }



    }
}
