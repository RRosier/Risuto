using Risuto.App.Commands;
using Risuto.Data;
using Risuto.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Risuto.App.ViewModels
{
    public class ItemsViewModel : INotifyPropertyChanged
    {
        private readonly IStorage storage;
        private Item newItem;
        public event PropertyChangedEventHandler PropertyChanged;

        public ItemsViewModel(IStorage storage)
        {
            this.storage = storage;
            this.Items = new ObservableCollection<Item>();
            this.NewItem = new Item();
            this.AddItem = new AsyncCommand(
                async () =>
                {
                    if (!string.IsNullOrEmpty(this.newItem.Name))
                    {
                        await this.storage.InsertAsync(this.NewItem);
                        this.Items.Add(new Item() { Name = newItem.Name });
                        this.newItem = new Item();
                    }
                });
        }

        public ObservableCollection<Item> Items { get; private set; }

        public Item NewItem
        {
            get { return newItem; }
            set
            {
                newItem = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand AddItem { get; private set; }

        public async Task LoadSavedItemsAsync()
        {
            var savedItems = await this.storage.QueryAllAsync<Item>();
            foreach (var item in savedItems)
            {
                this.Items.Add(item);
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
