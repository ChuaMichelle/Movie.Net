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
        private DataModelContainer ctx = new DataModelContainer();
        private HelpersViewModel HelpersViewModel { get; set; }
        private MovieListViewModel MListViewModel { get; set; }
        public RelayCommand CreateMovieCommand { get; set; }

        public MovieCreationViewModel()
        {
            HelpersViewModel = new HelpersViewModel();
            MListViewModel = new MovieListViewModel();
            CreateMovieCommand = new RelayCommand(CreateMovieExecute, MyCommandCanSubmit);
            GenresList = ctx.Genres.ToList();
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
        private bool MyCommandCanSubmit()
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

        private void CreateMovieExecute()
        {
            ctx.Movies.Add(NewMovie);
            ctx.SaveChanges();
            MListViewModel.updateList(NewMovie);
            HelpersViewModel.GetCurrentFocusedWindow().Close();
        }

    }
}
