//Author: Niall Ferguson 
//Date:19/08/2013
//Class containing properties and methods for the processing of fruit state.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Niall_Ferguson_Test
{
    public enum DeliveryState
    {
        JustPicked = 1,
        ArrivedAtClassificationCentre = 2,
        EnrouteToMarket = 3,
        Delivered = 4
    }//end enum

    class Fruit
    {
        private string name;
        private DateTime expiry;
        private decimal price;
        private DeliveryState deliveryState;
        //end private fields

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime Expiry
        {
            get { return expiry; }
            set { expiry = value; }
        }

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public DeliveryState DeliveryState
        {
            get { return deliveryState; }
            set { deliveryState = value; }
        }
        //end getter and setters

        public static void newStatus(Fruit fruitIn)
        {
            string fruitState;
            fruitIn.DeliveryState = fruitIn.deliveryState + 1;
            fruitState = Regex.Replace(fruitIn.deliveryState.ToString(), "(\\B[A-Z])", " $1");
            Console.WriteLine(fruitIn.name + "\t " + "\t " + fruitState);
            FileManager.writeFruit(fruitIn);
            FileManager.processed(fruitIn);
        }//end method         
    }//end class
}//end namespace
