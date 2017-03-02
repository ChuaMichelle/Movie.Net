namespace DCOMProductions.MvvmDemo.Commands
{
    using System;
    using System.Windows.Input;
    using DCOMProductions.MvvmDemo.ViewModels;

    internal class UpdateCustomerCommand : ICommand
    {
        private CustomerViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the UpdateCustomerCommand class.
        /// </summary>
        public UpdateCustomerCommand(CustomerViewModel viewModel) {
            this.viewModel = viewModel;
        }

        public event System.EventHandler CanExecuteChanged {
            add {
                CommandManager.RequerySuggested += value;
            }
            remove {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter) {
            return String.IsNullOrWhiteSpace(viewModel.Customer.Error);
        }

        public void Execute(object parameter) {
            viewModel.SaveChanges();
        }
    }
}