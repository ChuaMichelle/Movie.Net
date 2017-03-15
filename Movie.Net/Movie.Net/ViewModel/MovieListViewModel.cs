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
        public RelayCommand ShowMovieCreationWindowCommand { get; set; }

        public MovieListViewModel()
        {
            FindMovie = new Movies();
            ShowMovieCreationWindowCommand = new RelayCommand(ShowMovieCreationWindow, CanShowMovieCreationWindow);
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

        public bool CanShowMovieCreationWindow()
        {
            return true;
        }

        private void ShowMovieCreationWindow()
        {
            var window = new View.MovieCreationWindow();
            window.ShowDialog();
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