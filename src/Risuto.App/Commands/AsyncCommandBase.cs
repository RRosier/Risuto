using System;
using System.Threading.Tasks;

namespace Risuto.App.Commands
{
    public abstract class AsyncCommandBase : IAsyncCommand
    {
        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);
        public abstract Task ExecuteAsync(object parameters);

        public async void Execute(object parameter)
        {
            await this.ExecuteAsync(parameter);
        }

        public void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
