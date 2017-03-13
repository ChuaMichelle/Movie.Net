using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Diagnostics;


namespace Movie.Net.ViewModel
{
    public class MovieListViewModel : ViewModelBase
    {
        public FilmListViewModel GetFilmTitle { get; set; }

        public MovieListViewModel()
        {
        }
    }
}
