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
        public MainViewModel MainVM { get; set; }
        public MovieListViewModel MListVM { get; set; }
        public FilmListViewModel GetFilmTitle { get; set; }
        public MovieCreationViewModel MCreationVM { get; set; }

        private ObservableCollection<Movies> _Movies;
        private HelpersViewModel HelpersViewModel { get; set; }
        private DataModelContainer ctx = new DataModelContainer();

        public GeneralViewModel()
        {
            //Movies = new ObservableCollection<Movies>(ctx.Movies.ToList());
            MainVM = new MainViewModel();
            HelpersViewModel = new HelpersViewModel();
            Movies = new ObservableCollection<Movies>(ctx.Movies);

            MListVM = new MovieListViewModel();
            MListVM.FilterMoviesCommand = new RelayCommand(FilterCommandExecute, MListVM.FilterCommandCanExecute);
            
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
            // Wicked workaround
            // Movies.Add(movie); // turned all newly saved items into the last entry on the datagrid
            Movies = new ObservableCollection<Movies>(ctx.Movies.OrderByDescending(x => x.Id));
            RaisePropertyChanged("Movies");
        }

        // MovieListWindow
        private void FilterCommandExecute()
        {
            if (!String.IsNullOrWhiteSpace(MListVM.FindMovie.Title) && MListVM.FindMovie.Genre == null)
            {
                Movies = new ObservableCollection<Movies>(ctx.Movies.OrderByDescending(x => x.Title).Where(x => x.Title.Contains(MListVM.FindMovie.Title)));
            }
            else if (String.IsNullOrWhiteSpace(MListVM.FindMovie.Title) && MListVM.FindMovie.Genre != null)
            {
                Movies = new ObservableCollection<Movies>(ctx.Movies.OrderByDescending(x => x.Title).Where(x => x.Genre.Name.Equals(MListVM.FindMovie.Genre.Name)));
            }
            else if (!String.IsNullOrWhiteSpace(MListVM.FindMovie.Title) && MListVM.FindMovie.Genre != null)
            {
                Movies = new ObservableCollection<Movies>(ctx.Movies.OrderByDescending(x => x.Title).Where(x => x.Title.Contains(MListVM.FindMovie.Title) && x.Genre.Name.Equals(MListVM.FindMovie.Genre.Name)));
            }
            else
            {
                Movies = new ObservableCollection<Movies>(ctx.Movies.OrderByDescending(x => x.Id));
            }
            RaisePropertyChanged("Movies");
        }

        // MovieCreationWindow
        private void CreateMovieExecute()
        {
            ctx.Movies.Add(MCreationVM.NewMovie);
            ctx.SaveChanges();
            //updateList(MCreationVM.NewMovie);
            MListVM.FindMovie = new Movies();
            FilterCommandExecute();
            HelpersViewModel.GetCurrentFocusedWindow().Close();
            Trace.WriteLine("saved now: " + string.Join(", ", ctx.Movies.OrderByDescending(o => o.Id).Select(e => e.Title).ToArray()));
        }
        
    }
}
