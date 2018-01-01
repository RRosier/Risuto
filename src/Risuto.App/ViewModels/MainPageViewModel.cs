using Risuto.Data;
using Risuto.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risuto.App.ViewModels
{
    public class MainPageViewModel
    {
        private readonly IStorage storage;

        public MainPageViewModel(IStorage storage)
        {
            this.storage = storage;
            this.Lists = new ObservableCollection<ShoppingList>();
        }

        public ObservableCollection<ShoppingList> Lists { get; private set; }

        public async Task LoadSavedListsAsync()
        {
            var savedLists = await this.storage.LoadSavedListsAsync();
            foreach(var list in savedLists)
            {
                this.Lists.Add(list);
            }
        }
    }
}
