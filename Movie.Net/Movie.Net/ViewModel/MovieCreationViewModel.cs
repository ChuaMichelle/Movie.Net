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
    public class MovieCreationViewModel : ViewModelBase
    {
        private Movies _NewMovie;
        private List<Genres> _GenresList;
        public RelayCommand CreateMovieCommand { get; set; }

        public MovieCreationViewModel()
        {
            DataModelContainer ctx = new DataModelContainer();
            GenresList = ctx.Genres.ToList();
            CreateMovieCommand = new RelayCommand(CreateMovieExecute, MyCommandCanSubmit);
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

        private void CreateMovieExecute()
        {
            // add movie to database
            Trace.WriteLine("chosen genre: " + NewMovie.Genre.Name);
        }
        private bool MyCommandCanSubmit()
        {
            return true;
        }
    }
}
