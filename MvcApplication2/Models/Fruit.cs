using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class Fruit
    {
        public enum DeliveryState
        {
            JustPicked = 1,
            ArrivedAtClassificationCentre = 2,
            EnrouteToMarket = 3,
            Delivered = 4
        }//end enum

        public string name { get; set; }
        public DateTime expiry { get; set; }
        public decimal price { get; set; }
        public DeliveryState deliveryState { get; set; }

    }//end class
}//end namespace