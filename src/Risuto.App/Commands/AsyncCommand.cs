using System;
using System.Threading.Tasks;

namespace Risuto.App.Commands
{
    public class AsyncCommand : AsyncCommandBase
    {
        private readonly Func<Task> command;

        public AsyncCommand(Func<Task> command)
        {
            this.command = command;
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override Task ExecuteAsync(object parameters)
        {
            return this.command();
        }
    }
}
