using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{
    public class ProductDetails
    {
        //static field
        public static int s_productID = 2000;
        //product ID
        public string ProductID {get;set;}
        //Product Name
        public string ProductName{get;set;}
        //Stock
        public int Stock{get;set;}
        //Price
        public double Price {get;set;} 
        //Shipping Duration
        public int ShippingDuration{get;set;}
        //Default Constructor
        public ProductDetails(){}
        //parameterized Constructor
        public ProductDetails(string productID , string productName, int stock,double price , int shippingDuration)
        {
            ProductID = $"PID{s_productID++}";
            ProductName= productName;
            Stock=stock;
            Price = price;
            ShippingDuration=shippingDuration;

        }
    }
}