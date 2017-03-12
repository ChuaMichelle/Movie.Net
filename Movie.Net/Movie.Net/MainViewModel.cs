using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Diagnostics;

namespace Movie.Net
{
    public class MainViewModel : ViewModelBase
    {
        public AuthenticationViewModel AuthViewModel { get; set; }
        public RelayCommand SignupCommand { get; set; }
        public RelayCommand LoginCommand { get; set; }
        public User user = new User();
        private string _AuthErrorMessage;
        private bool _HasAuthErrorMessage;
        private string _AuthSuccessMessage;
        private bool _HasAuthSuccessMessage;

        public MainViewModel()
        {
            AuthViewModel = new AuthenticationViewModel();
            SignupCommand = new RelayCommand(SignupExecute, MyCommandsCanExecute);
            LoginCommand = new RelayCommand(LoginExecute, MyCommandsCanExecute);
        }

        public string AuthErrorMessage
        {
            get { return _AuthErrorMessage; }
            set
            {
                _AuthErrorMessage = value;
                RaisePropertyChanged("AuthErrorMessage");
            }
        }
        public bool HasAuthErrorMessage
        {
            get { return _HasAuthErrorMessage; }
            set
            {
                _HasAuthErrorMessage = value;
                RaisePropertyChanged("HasAuthErrorMessage");
            }
        }
        public string AuthSuccessMessage
        {
            get { return _AuthSuccessMessage; }
            set
            {
                _AuthSuccessMessage = value;
                RaisePropertyChanged("AuthSuccessMessage");
            }
        }
        public bool HasAuthSuccessMessage
        {
            get { return _HasAuthSuccessMessage; }
            set
            {
                _HasAuthSuccessMessage = value;
                RaisePropertyChanged("HasAuthSuccessMessage");
            }
        }


        private void SignupExecute()
        {
            DataModelContainer ctx = new DataModelContainer();
            if (ctx.Users.Any(u => u.Login == AuthViewModel.CurrentUser.Login))
            {

                HandleMessages(false, "Error: Username already taken.");
                Trace.WriteLine(ctx.Users.Any(u => u.Login == AuthViewModel.CurrentUser.Login).GetType());
            }
            else
            {
                ctx.Users.Add(AuthViewModel.CurrentUser);
                ctx.SaveChanges();
                HandleMessages(true, "Welcome ! Log in to continue to the app.");

            }
        }

        private void LoginExecute()
        {            
            DataModelContainer ctx = new DataModelContainer();
            if (ctx.Users.Any(u => u.Login == AuthViewModel.CurrentUser.Login))
            {
                if (ctx.Users.Any(u => u.Login == AuthViewModel.CurrentUser.Login && u.Password == AuthViewModel.CurrentUser.Password))
                {
                    // Login
                    HandleMessages(true, "Hello! User logged in successfully!");
                }
                else
                {
                    HandleMessages(false, "Error: Incorrect password.");
                }                
            }
            else
            {
                HandleMessages(false, "Error:  User not found in the database.");
                Trace.WriteLine(ctx.Users.Any(u => u.Login == AuthViewModel.CurrentUser.Login));

            }
        }

        private bool MyCommandsCanExecute()
        {
            if (String.IsNullOrWhiteSpace(AuthViewModel.CurrentUser.Login) || String.IsNullOrWhiteSpace(AuthViewModel.CurrentUser.Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // false meanse error / true means success
        private void HandleMessages(Boolean bolError, String msg)
        {
            if (bolError)
            {
                // handle success
                HasAuthSuccessMessage = true;
                AuthSuccessMessage = msg;
                // handle error
                HasAuthErrorMessage = false;
                AuthErrorMessage = null;
                Trace.WriteLine(AuthSuccessMessage);
            }
            else
            {
                // handle success
                HasAuthSuccessMessage = false;
                AuthSuccessMessage = null;
                // handle error
                HasAuthErrorMessage = true;
                AuthErrorMessage = msg;
                Trace.WriteLine(AuthErrorMessage);
            }
        }
    }
}
