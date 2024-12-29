using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SyncCart
{
    public class Operations
    {
            //create customerList
            static List<CustomerDetails> customers = new List<CustomerDetails>();
            //create orderlist
            static List<OrderDetails> orders = new List<OrderDetails>();
            //create product list
            static List<ProductDetails> products = new List<ProductDetails>();
            //global user
            static string currentLoggedInUser ;
        public static void  DefaultData()
        {

            //add objects to the list customer Details
            CustomerDetails customer1 = new CustomerDetails("Ravi","Chennai","889588699945",5000,"ravi@gmail.com");
            customers.Add(customer1);
            CustomerDetails customer2 = new CustomerDetails("Baskaran","Chennai","8588699945",6000,"baskaran@gmail.com");
            customers.Add(customer2);
            //create objects and store it to the orders list
            OrderDetails order1 =new OrderDetails("PID2001","CID3001",20000,new DateTime(12/27/2024),2,OrderStatus.Ordered);
            orders.Add(order1);
            OrderDetails order2 =new OrderDetails("PID2003","CID3001",40000,new DateTime(12/17/2024),2,OrderStatus.Ordered);
            orders.Add(order2);
            // cretae objects and store it to the list products
            ProductDetails product1 = new ProductDetails("PID2001","Mobile",10,10000,3);
            products.Add(product1);
            ProductDetails product2 = new ProductDetails("PID2002","Tablet",5,150000,2);
            products.Add(product2);
            ProductDetails product3 = new ProductDetails("PID2003","Camera",3,60000,4);
            products.Add(product3);
            ProductDetails product4 = new ProductDetails("PID2004","iphone",6,10000,3);
            products.Add(product4);
            ProductDetails product5 = new ProductDetails("PID2005","speakers",1,10000,3);
            products.Add(product5);
            /*
                        //Display Details --customer details
            System.Console.WriteLine("Customer Details");
            foreach (CustomerDetails customer in customers)
            {
                Console.WriteLine($"{customer.CustomerID}\t{customer.CustomerName}\t{customer.City}\t{customer.MobileNumber}\t{CustomerDetails.WalletBalance}\t{customer.EmailID}");
            }
            //display Product Details
            System.Console.WriteLine("Product Details");
            foreach (ProductDetails product in products)
            {
                System.Console.WriteLine($"{product.ProductID}\t{product.ProductName}\t{product.Stock}\t{product.Price}\t{product.ShippingDuration}");
            }
            //Display Order Details
            System.Console.WriteLine("Order Details");
            foreach(OrderDetails order in orders)
            {
                System.Console.WriteLine($"{order.OrderID}\t{order.ProductID}\t{order.CustomerID}\t{order.Price}\t{order.PurchaseDate.ToString("dd/MM/yyyy")}\t{order.OrderStatus}");
            } */

        }
        public static void MainMenu()
        {
            //display main menu to the user
            //set flag as true
            bool flag = true;
            do
            {
                System.Console.WriteLine($"Main Menu : 1.Registration 2.Login 3.Exit");
                System.Console.Write("Select an option (1/2/3) :  ");
                int option = int.Parse(Console.ReadLine());
                //using switch statement
                switch(option)
                {   //option 1 - registration
                    case 1 :
                    {
                        System.Console.WriteLine("-----------------------Registration--------------------");
                        Registration();
                        break;
                    }
                    //option 2 login
                    case 2 :
                    {
                        System.Console.WriteLine("------------------Login---------------------");
                        Login();
                        break;
                    }
                    // option 3 - exiting
                    case 3 :
                    {
                        System.Console.WriteLine("------------------------Exiting-------------------");
                        flag= false;
                        break;
                    }
                    default:
                    {
                        System.Console.WriteLine("Invalid Option");
                        break;
                    }
                }
            }while(flag);
        }
        //Registration method
        public static void Registration()
        {
            //get user Details
            //name
            System.Console.Write("Enter Name : ");
            string name = Console.ReadLine();
            //city
            System.Console.Write("Enter city : ");
            string city = Console.ReadLine();
            //mobile number
            System.Console.Write("Enter Mobile Number : ");
            string mobileNumber = Console.ReadLine();
            //wallet balance
            System.Console.Write("Enter wallet Baalance : ");
            double walletBalance = double.Parse(Console.ReadLine());
            //emailid
            System.Console.Write("Enter mail ID : ");
            string emailID = Console.ReadLine();
            //create object
            CustomerDetails customer = new CustomerDetails(name,city,mobileNumber,walletBalance,emailID);
            //add to list
            customers.Add(customer);
            System.Console.WriteLine($"Registration Successfully ! your Customer ID : {customer.CustomerID}");

        }
        //Login Method
        public static void Login()
        {
            //ask customer ID
            System.Console.Write("Enter Customer ID : ");
            string userID = Console.ReadLine().ToUpper();
            //check whether it is valid or not
            bool isValid = false ;
            //if valid - call submenu
            foreach (CustomerDetails customer in customers)
            {
                if(customer.CustomerID.Equals(userID))
                {
                    System.Console.WriteLine("Login Successfull");
                    currentLoggedInUser=customer.CustomerID;
                    isValid = true;
                    SubMenu();
                }
            }
            //if not valid display - invalid user ID
            if(!isValid)
            {
                System.Console.WriteLine("Invalid user");
            }
        }
        //submenu
        public static void SubMenu()
        {
            bool flag = true;
            do
            {
            //display the submenu
            System.Console.WriteLine("-----------------------SubMenu---------------------------\n1.Purchase\t 2.Order History\t 3.Cancel Order \t4.Wallet Balance\t 5.Wallet Recharge \t6.Exit");
            System.Console.Write("Select an option (1/2/3/4/5/6) : ");
            //get option from the user 
            int option = int.Parse(Console.ReadLine());
            switch(option)
            {
                //option -1 purchase
                case 1 :
                {
                    Purchase();
                    break;
                }
                //option -2 orderHIstory
                case 2 :
                {
                    OrderHistory();
                    break;
                }
                //option 3 - Cancel Order
                case 3 :
                {
                    CancelOrder();
                    break;
                }
                //option 4 - wallet Balance
                case 4 :
                {
                    WalletBalance();
                    break;
                }
                //option 5 - Wallet recharge
                case 5:
                {
                    WalletRecharge();
                    break;
                }
                //option 6 - Exiting
                case 6 :
                {
                    System.Console.WriteLine("------------------Exiting from submenu----------------");
                    flag = false;
                    break;
                }
                //invalid option
                default :
                {
                    System.Console.WriteLine("-------------Invalid option------------------");
                    break;
                }
            }

            }while(flag);
        }
        //purchase method
        public static void Purchase()
        {   
            System.Console.WriteLine("-------------------------Purchase-----------------------");
            //show product details
            foreach(ProductDetails product in products)
            {
                System.Console.WriteLine($"{product.ProductID}\t {product.ProductName}\t{product.Stock}\t{product.Price}\t{product.ShippingDuration}");
            }
            //ask the user to enter the productID
            System.Console.Write("Enter the product ID : ");
            string productID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach(ProductDetails product in products)
            {
            //check if valid - ask for count
                if(product.ProductID.Equals(productID))
                {
                    flag = false;
                    //check count is available 
                    System.Console.Write("Enter count of the product : ");
                    int count = int.Parse(Console.ReadLine());
                    if(count <= product.Stock)
                    {
                        //calculate the total amount 
                        double totalPrice = product.Price*count +50;
                        //check the user's wallet balance 
                        foreach(CustomerDetails customer in customers)
                        {
                            //if the user have enough balance - place the order
                            if(currentLoggedInUser==customer.CustomerID)
                            {
                                //reduce the total amount from the user's wallet balance
                                if(customer.WalletBalance >= totalPrice)
                                {
                                    customer.DeductWallet(totalPrice);
                                    product.Stock -=count;
                                
                                //string productID, string customerID,double price, DateTime purchaseDate ,int quantity , Enum orderStatus
                                DateTime date = DateTime.Now;
                                OrderDetails order = new OrderDetails(product.ProductID,currentLoggedInUser,totalPrice,date,count,OrderStatus.Ordered);
                                orders.Add(order);
                                //display "Order successfully placed"
                                System.Console.WriteLine($"\nOrder placed Successfully and your orderID {order.OrderID}");
                                //also display the deleivery date ,by adding the shippingdays to the purchase date
                                DateTime deliveryDate = date.AddDays(product.ShippingDuration);
                                //display yourorder will be delivered on
                                System.Console.WriteLine($"\nYour order will be delivered on {deliveryDate.ToString("dd/MM/yyyy")}");
                                }
                                //if user don't have enough balance - display insufficient balance
                                else
                                {
                                    System.Console.WriteLine($"\nInsufficient balance.Total Price {totalPrice} . your current balance {customer.WalletBalance}");
                                }
                            }
                        }

                    }
                    //if count is not avaliable - display count is not available and display avaliable count
                    else
                    {
                        System.Console.WriteLine($"COunt not available . Available Count {product.Stock} ");
                    }
                }
            //if invalid product id
            }
            if(flag)
            {
                System.Console.WriteLine("Invalid Product ID");
            }
        }
        //order history
        public static void OrderHistory()
        {
            System.Console.WriteLine("-----------------------------------------Order History-------------------------------------------");
            bool flag = true;
            foreach(OrderDetails order in orders)
            {
                //check whether the userid of the currenetloggedinuser == order.Customer ID
                if(currentLoggedInUser==order.CustomerID)
                {
                    //display order details
                    System.Console.WriteLine($"{order.OrderID},{order.ProductID},{order.Quantity},{order.PurchaseDate},{order.OrderStatus}");
                    flag = false;
                }
            }
                if(flag)
                {
                System.Console.WriteLine("No Orders found");
                }      
        }
        //order history
        public static void CancelOrder()
        {
            System.Console.WriteLine("--------------------------------------------------Cancel Order--------------------------------------");
            //show the previous orders of the current logged In user
            foreach(OrderDetails order in orders)
            {
                if(currentLoggedInUser.Equals(order.CustomerID) && order.OrderStatus.Equals(OrderStatus.Ordered))
                {
                    System.Console.WriteLine($"orderID : {order.OrderID} \t product ID {order.ProductID} \t order Date : {order.PurchaseDate} \t order price {order.Price} order quantity : {order.Quantity}");
                }
            }
            //ask user to enter the orderID
            System.Console.Write("Enter order ID : ");
            string orderID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (OrderDetails order in orders)
            {
                //check whether the order exists
                if(orderID.Equals(order.OrderID) && currentLoggedInUser.Equals(order.CustomerID))
                {
                    foreach(ProductDetails product in products)
                    {
                        if(product.ProductID.Equals(order.ProductID))
                        {
                            //increase coount
                            product.Stock +=order.Quantity;
                        }
                    }
                    //change the order status to cancell
                    order.OrderStatus = OrderStatus.Cancelled;
                    //refund the amount to user wallet balance
                    foreach(CustomerDetails customer in customers)
                    {
                        if(currentLoggedInUser.Equals(customer.CustomerID))
                        {
                            customer.WalletBalance +=order.Price-50;
                        }
                    }
                    System.Console.WriteLine($"Order {order.OrderID} cancelled successfully ! {order.Price} is refund to your wallet");
                    flag = false;
                }
            }
            if(flag)
            {
                System.Console.WriteLine("Invalid Order ID");
            }
            
            
        }
        //wallet balance
        public static void WalletBalance()
        {
            System.Console.WriteLine("---------------------------------------------Wallet Balance---------------------------------------");
            foreach (CustomerDetails customer in customers)
            {
                if(currentLoggedInUser==customer.CustomerID)
                {
                    System.Console.WriteLine(customer.WalletBalance);
                }
            }
        }
        //wallet recharge
        public static void WalletRecharge()
        {
            System.Console.WriteLine("---------------------------------------Wallet Recharge----------------------------------------------");
            System.Console.Write("Do you wish to recharge (yes/no) : ");
            string option = Console.ReadLine().ToLower();
            //if yes add amount to user wallet
            if(option.Equals("yes"))
            {
                //get amount from the user 
                System.Console.Write("Enter the amount : ");
                double amount = double.Parse(Console.ReadLine());
                        
                foreach(CustomerDetails customer in customers)
                {
                    if(currentLoggedInUser==customer.CustomerID)
                    {
                        customer.WalletRecharge(amount);
                        System.Console.WriteLine($"Your Wallet Balance :{customer.WalletBalance}");
                    }
                }
                
            }
            else if(option.Equals("no"))
            {
                System.Console.WriteLine("Back to sub menu");
            }
            else
            {
                System.Console.WriteLine("Invalid. Type yes/no .");
            }
        }

    
    }
}