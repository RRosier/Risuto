using System.Threading.Tasks;
using System.Windows.Input;

namespace Risuto.App.Commands
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameters);
        void RaiseCanExecuteChanged();
    }
}
