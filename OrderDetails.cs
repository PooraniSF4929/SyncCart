using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{
    public class OrderDetails
    {
        //get and set all the properties 
        //static field 
        public static int s_orderID = 1000;
        //order ID - primary key
        public string OrderID {get; set;}
        //Product ID -- foreign key
        public string ProductID {get; set;}
        //customerID -- foreign key
        public string CustomerID{get; set;}
        //price
        public double Price {get;set;}
        //purchase date
        public DateTime PurchaseDate {get; set;}
        //quantity
        public int Quantity{get;set;}
        //Enum for OrderStatus 
        public Enum OrderStatus {get;set;}
        //default constructor
        public OrderDetails(){}
        //parameterized constructor 
        public OrderDetails(string productID, string customerID,double price, DateTime purchaseDate ,int quantity , Enum orderStatus)
        {
            OrderID = $"OID{s_orderID++}";
            ProductID= productID;
            CustomerID = customerID;
            Price = price;
            PurchaseDate = purchaseDate;
            Quantity = quantity;
            OrderStatus = orderStatus;
        }

    }
}