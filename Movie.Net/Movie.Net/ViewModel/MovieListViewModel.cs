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
        public Movies _FindMovie;
        public RelayCommand FilterMoviesCommand { get; set; }
        public RelayCommand FilterMoviesRefreshCommand { get; set; }
        public RelayCommand ShowMovieCreationWindowCommand { get; set; }
        public RelayCommand ShowMoviePageWindowCommand { get; set; }
        public MoviePageViewModel MPageVM { get; set; }

        public MovieListViewModel()
        {
            FindMovie = new Movies();
            MPageVM = new MoviePageViewModel();
            ShowMoviePageWindowCommand = new RelayCommand(ShowMoviePageWindow, CanShowAnotherWindow);
            ShowMovieCreationWindowCommand = new RelayCommand(ShowMovieCreationWindow, CanShowAnotherWindow);
        }

        public Movies FindMovie
        {
            get { return _FindMovie; }
            set
            {
                if (value != _FindMovie)
                {
                    _FindMovie = value;
                    RaisePropertyChanged("FindMovie");
                }
            }
        }

        public bool CanShowAnotherWindow()
        {
            return true;
        }

        private void ShowMovieCreationWindow()
        {
            var window = new View.MovieCreationWindow();
            window.ShowDialog();
        }

        private void ShowMoviePageWindow()
        {
            Trace.WriteLine("ShowMoviePageWindow w/out params");
            var window = new View.MovieCommentAndNote();
            window.ShowDialog();
        }

        private void ShowMoviePageWindow(Movies movie)
        {
            Trace.WriteLine("ShowMoviePageWindow w/ params");
            Trace.WriteLine("current movie title: " + movie.Title);
            //var window = new View.Mo();
            //window.ShowDialog();
        }

        private void FilterCommandExecute()
        {
            Trace.WriteLine("filter");

        }

        public bool FilterCommandCanExecute()
        {
            if (!String.IsNullOrWhiteSpace(FindMovie.Title) || FindMovie.Genre != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}