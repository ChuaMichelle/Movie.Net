using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using secondTrial.Model;

namespace secondTrial.ViewModel
{
    public class AuthViewModel : ViewModelBase
    {
        private User _CurrentUser;
        private bool _IsAuthenticated;

        public AuthViewModel()
        {
            CurrentUser = new User { UserName = "Name", Password = "Password" };
        }

        public bool IsAuthenticated
        {
            get { return _IsAuthenticated; }
            set
            {
                if (value != _IsAuthenticated)
                {
                    _IsAuthenticated = value;
                    RaisePropertyChanged("IsAuthenticated");
                    RaisePropertyChanged("IsNotAuthenticated");
                }
            }
        }

        public bool IsNotAuthenticated
        {
            get
            {
                return !IsAuthenticated;
            }
        }

        // why ignore ? 
        public bool CanDoAuthenticated(object ignore)
        {
            return IsAuthenticated;
        }

        public User CurrentUser
        {
            get { return _CurrentUser; }
            set

            {
                if (value != _CurrentUser)
                {
                    _CurrentUser = value;
                    RaisePropertyChanged("CurrentUser");
                }
            }
        }

        public void Authenticate()
        {
            IsAuthenticated = true;
        }

        public void LogOff()
        {
            IsAuthenticated = false;
        }
    }
}
