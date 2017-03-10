using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Movie.Net
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Name = "Hello MVVM!";
            MyCommand = new RelayCommand(MycommandExecute, MyCommandCanExecute);
            ChangePage = new RelayCommand(changePage, returnTrue);
        }

        public string _name;
        public string _password;
        public string _username;
        public string _isAuthenticated;

        public string IsAuthenticated
        {
            get { return _isAuthenticated; }
            set
            {
                //_isAuthenticated = true;
                RaisePropertyChanged();
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged();
            }
        }
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                RaisePropertyChanged();
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand MyCommand { get; }
        public RelayCommand ChangePage { get; }

        void MycommandExecute()
        {

            Name = "Hello click!";
            DataModelContainer ctx = new DataModelContainer();
            var query = ctx.Users.Where(u => u.Id.Equals(1)).ToList();
        }

        bool MyCommandCanExecute()
        {
            return Name != "Hello click!";
        }

        void changePage() {
            //MainWindow.
        }

        bool returnTrue() {
            return true;
        }

    }
}
