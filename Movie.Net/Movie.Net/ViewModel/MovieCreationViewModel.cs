using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Diagnostics;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;

namespace Movie.Net.ViewModel
{
    public class MovieCreationViewModel : ViewModelBase
    {
        private Movies _NewMovie;
        private List<Genres> _GenresList;
        public RelayCommand CreateMovieCommand { get; set; }

        public MovieCreationViewModel()
        {
            NewMovie = new Movies { Title="testMovie", Plot="something something" };
        }

        public Movies NewMovie
        {
            get { return _NewMovie; }
            set
            {
                if (value != _NewMovie)
                {
                    _NewMovie = value;
                    RaisePropertyChanged("NewMovie");
                }
            }
        }

        public List<Genres> GenresList
        {
            get { return _GenresList; }
            set
            {
                _GenresList = value;
                RaisePropertyChanged("GenresList");
            }
        }

        public bool MyCommandCanSubmit()
        {
            if (String.IsNullOrWhiteSpace(NewMovie.Title) || String.IsNullOrWhiteSpace(NewMovie.Plot) || NewMovie.Genre == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
