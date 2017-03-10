using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using secondTrial.ViewModel;
using System.Windows.Controls;


namespace secondTrial.Helpers
{
    public class ViewModelLocator
    {
        // TODO : put stage here as params
        public static MainViewModel MainVM { get; } = new MainViewModel();

        //string s = MainWindow.name;



    }
}
