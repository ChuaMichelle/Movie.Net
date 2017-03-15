using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Diagnostics;
using GalaSoft.MvvmLight.CommandWpf;

namespace Movie.Net.ViewModel
{
    public class MoviePageViewModel : ViewModelBase
    {
        private Movies _CurrentMovie;

        public MoviePageViewModel()
        {

        }

        public Movies CurrentMovie
        {
            get { return _CurrentMovie; }
            set
            {
                if (value != _CurrentMovie)
                {
                    _CurrentMovie = value;
                    RaisePropertyChanged("CurrentMovie");
                }
            }
        }

        

    }
}
