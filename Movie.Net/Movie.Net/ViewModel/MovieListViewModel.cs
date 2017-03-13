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
        public MovieListViewModel()
        {

        }

        private List<Movies> _movieTitle;

        public List<Movies> MovieTitle
        {
            get { return _movieTitle; }
            set { _movieTitle = value; }
        }

        public void GetListFilmTitle()
        {
            DataModelContainer ctx = new DataModelContainer();

            MovieTitle = ctx.Movies.Where(m => m.Title.Contains("a")).ToList();

        }
    }
}
