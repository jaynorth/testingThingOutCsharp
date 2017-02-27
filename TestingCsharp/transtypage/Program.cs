using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace transtypage
{
    class Program
    {
        static void Main(string[] args)
        {


            int shortnumber = 54;

            long longnumber=69;

            longnumber = shortnumber;
            Console.WriteLine(longnumber);

            longnumber = 34;
            shortnumber = (int)longnumber;//implicit not possible
            Console.WriteLine(shortnumber);
            Console.ReadKey();
        }
    }
}
