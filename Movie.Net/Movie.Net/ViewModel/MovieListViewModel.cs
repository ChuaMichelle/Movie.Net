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

        public MovieListViewModel()
        {
            ShowMovieCreationWindowCommand = new RelayCommand(ShowMovieCreationWindow, CanShowMovieCreationWindow);
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
    }
}