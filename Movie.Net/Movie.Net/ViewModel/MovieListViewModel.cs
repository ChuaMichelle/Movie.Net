using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Diagnostics;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.CommandWpf;

namespace Movie.Net.ViewModel
{
    public class MovieListViewModel : ViewModelBase
    {
        public RelayCommand ShowMovieCreationWindowCommand { get; set; }
        public FilmListViewModel GetFilmTitle { get; set; }

        private ObservableCollection<Movies> _Movies;
        private DataModelContainer ctx = new DataModelContainer();

        public MovieListViewModel()
        {
            //Movies = new ObservableCollection<Movies>(ctx.Movies.ToList());
            Movies = new ObservableCollection<Movies>(ctx.Movies);
            //updateList();
            ShowMovieCreationWindowCommand = new RelayCommand(ShowMovieCreationWindow, CanShowMovieCreationWindow);
        }

        public ObservableCollection<Movies> Movies
        {
            get { return _Movies; }
            set
            {
                _Movies = value;
                RaisePropertyChanged("Movies");
            }
        }
        private bool CanShowMovieCreationWindow()
        {
            return true;
        }

        public void updateList(Movies movie)
        {
            Trace.WriteLine("MovieListViewModel | Inside updatelist");
            Movies.Add(movie);

        }

        private void ShowMovieCreationWindow()
        {
            var window = new View.MovieCreationWindow();
            window.ShowDialog();
        }

    }
}