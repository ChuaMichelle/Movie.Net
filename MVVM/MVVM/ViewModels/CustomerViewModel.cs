namespace MVVM.ViewModels
{
    using System;
    using System.Diagnostics;
    using System.Windows.Input;
    using MVVM.Commands;
    using MVVM.Models;
    using MVVM.Views;

    internal class CustomerViewModel
    {
        private Customer customer;
        private CustomerInfoViewModel childViewModel;

        /// <summary>
        /// Initialize a new instace of the CustomerViewModel class.
        /// </summary> 
        public CustomerViewModel()
        {
            // TODO: insert database shit here
            customer = new Customer("David");
            childViewModel = new CustomerInfoViewModel();
            UpdateCommand = new CustomerUpdateCommand(this);
        }
        
        /// <summary>
        /// Gets the customer instance
        /// </summary> 
        /// 
        public Customer Customer
        {
            get { return customer; }
        }

        /// <summary>
        /// Gets the UpdateCommand for the ViewModel
        /// </summary> 
        /// 
        public ICommand UpdateCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Save changes made to the Customer Instace
        /// </summary> 
        /// 
        public void SaveChanges()
        {
           // CustomerInfoViewModel view = new CustomerInfoViewModel();
           // view.DataContext = childViewModel

            CustomerInfoView view = new CustomerInfoView()
            {
                DataContext = childViewModel
            };

            childViewModel.Info = Customer.Name + " was updated in the database.";
            view.ShowDialog();
            //Debug.Assert(false, String.Format("{0} was updated.", Customer.Name));
        }



    }
}
