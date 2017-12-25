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
        public MainPageViewModel()
        {
            this.Lists = new ObservableCollection<ShoppingList>();
            for (int i = 0; i < 30; i++)
            {
                this.Lists.Add(new ShoppingList($"List {i+1}"));
            }
        }

        public ObservableCollection<ShoppingList> Lists { get; set; }
    }
}
