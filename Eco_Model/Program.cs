using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eco_Model
{
    class Program
    {
        static void Main(string[] args)
        {
            Ocean MyOcean = new Ocean();
            MyOcean.Initialize();
            MyOcean.run();
        }
    }
}
