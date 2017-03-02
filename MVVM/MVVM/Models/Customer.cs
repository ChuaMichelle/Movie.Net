namespace MVVM.Models
{
    using System;
    using System.ComponentModel;

    class Customer : INotifyPropertyChanged, IDataErrorInfo
    {
        private string name;

        /// <summary>
        /// Initialize a new instace of the Customer class;
        /// </summary> 
        public Customer(string customerName) {
            Name = customerName;
        }

        /// <summary>
        /// Gets or sets Customer's name.
        /// </summary> 
        /// 
        public String Name
        {
            get { return name; }
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
                        Error = "Name cannot be null or empty";
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
