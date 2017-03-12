﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace Movie.Net
{
    public class AuthenticationViewModel : ViewModelBase
    {
        private User _CurrentUser;
        private bool _IsAuthenticated;

        public AuthenticationViewModel()
        {
            CurrentUser = new User { Login = "Root", Password = "Root" };
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

        public bool CanDoAuthenticated(object ignore)
        {
            return IsAuthenticated;
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