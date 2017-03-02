namespace MVVM.Commands
{
    using System;
    using System.Windows.Input;
    using MVVM.ViewModels;

    internal class CustomerUpdateCommand : ICommand
    {
        private CustomerViewModel viewModel;

        /// <summary>
        /// Initialize a new instace of the CustomerUpdateCommand class.
        /// </summary> 
        /// <param name="viewModel"></param>
        public CustomerUpdateCommand(CustomerViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        //#region ICommand Members

        public event System.EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            //throw new System.NotImplementedException();
            return String.IsNullOrWhiteSpace(viewModel.Customer.Error);
        }

        public void Execute(object parameter)
        {
            //throw new System.NotImplementedException();
            viewModel.SaveChanges();
        }

        //#endregion
    }
}
