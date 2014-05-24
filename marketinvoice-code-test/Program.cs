//Author: Niall Ferguson 
//Date:19/08/2013
//Main programme class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Niall_Ferguson_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Product Name" + "\t" + "Product State");
            Console.WriteLine("*************************************");
            Console.WriteLine();

            //read fruits from file into list
            List<Fruit> fruit = FileManager.readFile();

            //itterate through all the fruits in the fruitlist moving to next status until they have all been delivered
            foreach (var f in fruit)
            {
                while (f.DeliveryState != DeliveryState.Delivered)
                {
                    Fruit.newStatus(f);
                }//end while
            }//end foreach    
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }// end method
    }//end class
}//end namespace
