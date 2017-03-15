using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Movie.Net.ViewModel
{
    public class VMLocator
    {
        public static MainViewModel MainVM { get; set; } = new MainViewModel();
        public static GeneralViewModel GeneralVM { get; set; } = new GeneralViewModel();
        public static MovieListViewModel MovieListVM { get; set; } = new MovieListViewModel();
        public static MovieCreationViewModel MovieCreationVM { get; set; } = new MovieCreationViewModel();
    }
}