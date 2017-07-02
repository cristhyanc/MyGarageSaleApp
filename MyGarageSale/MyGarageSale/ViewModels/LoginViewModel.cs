using MyGarageSale.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyGarageSale.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand BtnLoginCommand { get; protected set; }

        string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }

        string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }

        public bool Requested { get; set; }


        public LoginViewModel()
        {
            BtnLoginCommand = new Command(Login);

        }

        private async void Login()
        {

            try
            {
                this.IsBusy = true;


                //  InstanceLocator.MockUser();
              //  await System.Threading.Tasks.Task.Delay(1500);
                //this.IsBusy = false;

                //NavigationService.Navigate("SalePage");
            }
            catch (Exception ex)
            {
                LogService.RecordError(ex, "", "LoginViewModel", "Login");
            }

        }
    }
}
