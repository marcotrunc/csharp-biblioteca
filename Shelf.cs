using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    public class Shelf
    {
        private string sNumber;
        public string Number
            { get { return sNumber; } set { sNumber = value; } }
        public Shelf(string sNumber)
        {
            this.Number = sNumber;
        }
    }
}
