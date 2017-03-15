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
    public class GeneralViewModel : ViewModelBase
    {
        public FilmListViewModel GetFilmTitle { get; set; }
        private ObservableCollection<Movies> _Movies;
        private DataModelContainer ctx = new DataModelContainer();
        public MovieCreationViewModel MCreationVM { get; set; }
        public MovieListViewModel MListVM { get; set; }
        private HelpersViewModel HelpersViewModel { get; set; }

        public GeneralViewModel()
        {
            //Movies = new ObservableCollection<Movies>(ctx.Movies.ToList());
            
            MListVM = new MovieListViewModel();
            HelpersViewModel = new HelpersViewModel();
            Movies = new ObservableCollection<Movies>(ctx.Movies);

            MCreationVM = new MovieCreationViewModel();
            MCreationVM.GenresList = ctx.Genres.ToList();
            MCreationVM.CreateMovieCommand = new RelayCommand(CreateMovieExecute, MCreationVM.MyCommandCanSubmit);
        }

        // MovieListWindow
        public ObservableCollection<Movies> Movies
        {
            get { return _Movies; }
            set
            {
                _Movies = value;
                RaisePropertyChanged("Movies");
            }
        }

        // MovieListWindow
        public void updateList(Movies movie)
        {
            Movies.Add(movie);
            RaisePropertyChanged("Movies");
        }

        // MovieCreationWindow
        private void CreateMovieExecute()
        {
            ctx.Movies.Add(MCreationVM.NewMovie);
            ctx.SaveChanges();
            updateList(MCreationVM.NewMovie);
            HelpersViewModel.GetCurrentFocusedWindow().Close();
            Trace.WriteLine("saved now: " + string.Join(", ", ctx.Movies.OrderByDescending(o => o.Id).Select(e => e.Title).ToArray()));
        }
    }
}
