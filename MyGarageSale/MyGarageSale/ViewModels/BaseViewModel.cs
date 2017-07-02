
using MyGarageSale.Services;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyGarageSale.ViewModels
{
    public class BaseViewModel : Shared.MainViewModel
    {            

        public BaseViewModel()
        {
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if (!IsConnected())
            {
                MessageService.DisplayOkAlert("Internet Connection", "There is not connection");
            }

        }

        public static Boolean IsConnected()
        {
            return CrossConnectivity.Current.IsConnected;
        }



    }
}
