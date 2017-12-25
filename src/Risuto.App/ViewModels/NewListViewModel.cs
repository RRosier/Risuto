using Risuto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Risuto.App.ViewModels
{
    public class NewListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ShoppingList list;

        public NewListViewModel()
        {
            this.list = new ShoppingList("fake name");
        }

        public string Name
        {
            get { return this.list.Name; }
            set {
                this.list.Name = value;
                this.NotifyPropertyChanged();
                this.NotifyPropertyChanged("Typed"); }
        }

        public string Typed { get { return this.list.Name; } }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
