using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Net.ViewModel
{
    public class VMLocator
    {
        public static MainViewModel MainVM { get; set; } = new MainViewModel();
        public static MovieListViewModel MovieListVM { get; set; } = new MovieListViewModel();
    }
}