﻿using Project0.DataAccess;
using Project0.BusinessLogic;
using System;
using System.Collections.Generic;

namespace Project0.App
{
    class MenuHandler
    {
        internal static void HandleRequest(MenuRequest req)
        {
            //if (req.Equals(MenuRequest.AddCustomer)) HandleRequestAddCustomer();
            /*else*/if (req.Equals(MenuRequest.SearchCustomer)) HandleRequestSearchCustomer();
            //else if (req.Equals(MenuRequest.DisplayDetailsOfOrder)) HandleRequestDisplayDetailsOfOrder();
            //else if (req.Equals(MenuRequest.DisplayOrderHistoryOfLocation)) HandleRequestDisplayOrderHistoryOfLocation();
            //else if (req.Equals(MenuRequest.DisplayOrderHistoryOfCustomer)) HandleRequestDisplayOrderHistoryOfCustomer();
            //else if (req.Equals(MenuRequest.DisplayAllLocations)) HandleRequestDisplayAllLocations();
            else if (req.Equals(MenuRequest.Exit)) HandleRequestExit();
            else HandleRequestInvalid();
        }

        //private static void HandleRequestAddCustomer()
        //{
        //    try
        //    {
        //        Customer cust = new Customer();

        //        Console.WriteLine("[?] What is the first name of the customer");
        //        string firstName = Console.ReadLine();
        //        cust.FirstName = firstName;

        //        Console.WriteLine("[?] What is the last name of the customer");
        //        string lastName = Console.ReadLine();
        //        cust.LastName = lastName;

        //        CustomerData.AddCustomer(cust);
        //        Console.WriteLine($"[+] The customer {cust.FirstName} {cust.LastName} has been added");
        //    }
        //    catch (CustomerException ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        private static void HandleRequestSearchCustomer()
        {
            try
            {
                BusinessCustomer cust = new BusinessCustomer();

                Console.WriteLine("[?] What is the last name of the customer you are searching for");
                string lastName = Console.ReadLine();
                cust.LastName = lastName;

                ICollection<BusinessCustomer> customersWithLastName = CustomerData.GetCustomersByLastName(cust);
                Console.WriteLine($"[*] There are {customersWithLastName.Count} customers with last name \"{lastName}\"");
                foreach (BusinessCustomer c in customersWithLastName)
                {
                    Console.WriteLine(c);
                }
                Console.WriteLine("\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        //private static void HandleRequestDisplayDetailsOfOrder()
        //{
        //    Console.WriteLine("[?] What is the order ID");
        //    string orderId = Console.ReadLine();
        //    int oId;
        //    if (Int32.TryParse(orderId, out oId))
        //    {
        //        Order order = OrderData.GetOrderById(oId);
        //        if (order != null)
        //        {
        //            Console.WriteLine(order);
        //        }
        //        else
        //        {
        //            Console.WriteLine("[!] Order does not exist in the database");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("[!] Input is not an integer");
        //    }
        //}

        //private static void HandleRequestDisplayOrderHistoryOfLocation()
        //{
        //    Console.WriteLine("[?] What is the location ID");
        //    string locationId = Console.ReadLine();
        //    int lId;
        //    if (Int32.TryParse(locationId, out lId))
        //    {
        //        List<Order> ordersWithLocation = OrderData.GetOrdersByLocation(lId);
        //        foreach (Order ord in ordersWithLocation)
        //        {
        //            Console.WriteLine(ord);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("[!] Input is not an integer");
        //    }
        //}

        //private static void HandleRequestDisplayOrderHistoryOfCustomer()
        //{
        //    Console.WriteLine("[?] What is the customer ID");
        //    string customerId = Console.ReadLine();
        //    int cId;
        //    if(Int32.TryParse(customerId, out cId))
        //    {
        //        List<Order> ordersWithCustomer = OrderData.GetOrdersByCustomer(cId);
        //        foreach (Order ord in ordersWithCustomer)
        //        {
        //            Console.WriteLine(ord);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("[!] Input is not an integer");
        //    }
        //}

        //private static void HandleRequestDisplayAllLocations()
        //{
        //    List<Location> locations = LocationData.GetLocations();
        //    Console.WriteLine("[*] Locations");
        //    foreach (Location loc in locations)
        //    {
        //        Console.WriteLine(loc);
        //    }
        //}

        private static void HandleRequestExit()
        {
            Console.WriteLine("[*] Bye!\n");
            Environment.Exit(0);
        }

        private static void HandleRequestInvalid()
        {
            Console.WriteLine("[!] Invalid input\n");
        }
    }
}
