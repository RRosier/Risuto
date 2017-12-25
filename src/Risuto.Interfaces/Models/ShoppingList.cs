using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risuto.Models
{
    public class ShoppingList
    {
        public ShoppingList()
        {

        }

        public ShoppingList(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
