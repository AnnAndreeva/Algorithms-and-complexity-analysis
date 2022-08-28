using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_05
{
    class Item
    {
        public string name { get; set; } //название

        public int weigth { get; set; }//вес

        public double price { get; set; }//стоимость

        public Item(string _name, int _weigth, double _price)
        {
            name = _name;
            weigth = _weigth;
            price = _price;
        }

        
    }
}
