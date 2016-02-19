using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Component
    {
        string partnumber { get; set; }
        string name { get; set; }
        int price { get; set; }

        public Component(string n, string m, int p)
        {
            partnumber = n;
            name = m;
            price = p;    
        }
    }
}
