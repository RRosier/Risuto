using Risuto.App.Commands;
using Risuto.Data;
using Risuto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Risuto.App.ViewModels
{
    public class NewListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ShoppingList list;
        private readonly IStorage storage;

        public NewListViewModel(IStorage storage)
        {
            this.storage = storage;
            this.list = new ShoppingList("fake name");
            this.SaveList = new AsyncCommand(
                async () =>
                {
                    await this.storage.InsertAsync(this.list);
                    this.NotifyPropertyChanged("Typed");
                });
        }

        public string Name
        {
            get { return this.list.Name; }
            set {
                this.list.Name = value;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged("Typed"); }
        }

        public ICommand SaveList { get; private set; }

        public string Typed { get { return this.list.Name; } }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
