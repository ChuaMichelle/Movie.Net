namespace DCOMProductions.MvvmDemo.Models
{
    using System;
    using System.ComponentModel;
    
    public class Customer : IDataErrorInfo, INotifyPropertyChanged
    {
        private string name;

        /// <summary>
        /// Initializes a new instance of the Customer class.
        /// </summary>
        public Customer(String customerName) {
            Name = customerName;
        }

        /// <summary>
        /// Gets or sets the Customer's name.
        /// </summary>
        public String Name {
            get {
                return name;
            }
            set {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region IDataErrorInfo Members

        public string Error
        {
            get;
            private set;
        }

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Name")
                {
                    if (String.IsNullOrWhiteSpace(Name))
                    {
                        Error = "Name cannot be null or empty.";
                    }
                    else
                    {
                        Error = null;
                    }
                }

                return Error;
            }
        }

        #endregion
    }
}