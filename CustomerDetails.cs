using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{
    public class CustomerDetails
    {
        //get properties
        //static field
        public static int s_customerID = 3001;
        //Customer ID
        public string CustomerID {get;set;}
        //CustomerName
        public string CustomerName{get;set;}
        //city
        public string City{get;set;}
        //mobilenumber
        public string MobileNumber{get;set;}
        //wallet Balance
        public double WalletBalance{get;set;}
        //emailId
        public string EmailID{get;set;}
        //default Constructor
        public CustomerDetails(){}
        //parameterized constructor
        public CustomerDetails(string customerName, string city, string mobilenumber,double walletBalance,string emailID)
        {
            CustomerID =$"CID{s_customerID++}";
            CustomerName = customerName;
            City=city ;
            MobileNumber = mobilenumber;
            WalletBalance = walletBalance;
            EmailID= emailID;
        }
        public  void WalletRecharge(double amount)
        {
            WalletBalance += amount;
        }
        public  void DeductWallet(double amount)
        {
            WalletBalance -=amount;
        }

    }
}