using Project0.Data;
using Project0.Logic;
using System;
using System.Collections.Generic;

namespace Project0.App
{
    class MenuHandler
    {
        internal static void HandleRequest(MenuRequest req)
        {
            if (req.Equals(MenuRequest.AddCustomer)) HandleRequestAddCustomer();
            else if (req.Equals(MenuRequest.SearchCustomer)) HandleRequestSearchCustomer();
            else if (req.Equals(MenuRequest.DisplayDetailsOfOrder)) HandleRequestDisplayDetailsOfOrder();
            else if (req.Equals(MenuRequest.DisplayOrderHistoryOfLocation)) HandleRequestDisplayOrderHistoryOfLocation();
            else if (req.Equals(MenuRequest.DisplayOrderHistoryOfCustomer)) HandleRequestDisplayOrderHistoryOfCustomer();
            else if (req.Equals(MenuRequest.Exit)) HandleRequestExit();
            else HandleRequestInvalid();
        }

        private static void HandleRequestAddCustomer()
        {
            Console.WriteLine("What is the first name of the customer?: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("What is the last name of the customer?: ");
            string lastName = Console.ReadLine();

            CustomerFirstNameValidationMessage msgFirstName = CustomerValidation.ValidateCustomerFirstName(firstName);
            CustomerLastNameValidationMessage msgLastName = CustomerValidation.ValidateCustomerLastName(lastName);
            if (msgFirstName == CustomerFirstNameValidationMessage.FirstNameEmpty) Console.WriteLine("Customer first name is empty");
            else if (msgFirstName == CustomerFirstNameValidationMessage.FirstNameTooLong) Console.WriteLine("Customer first name is too long");
            else if (msgFirstName == CustomerFirstNameValidationMessage.FirstNameNotAlpha) Console.WriteLine("Customer first name is not alphabetic");
            else if (msgLastName == CustomerLastNameValidationMessage.LastNameEmpty) Console.WriteLine("Customer last name is empty");
            else if (msgLastName == CustomerLastNameValidationMessage.LastNameTooLong) Console.WriteLine("Customer last name is too long");
            else if (msgLastName == CustomerLastNameValidationMessage.LastNameNotAlpha) Console.WriteLine("Customer last name is not alphabetic");
            else
            {
                CustomerData.AddCustomer(firstName, lastName);
                Console.WriteLine($"We have added a customer with name {firstName} {lastName}");
            }
        }

        private static void HandleRequestSearchCustomer()
        {
            Console.WriteLine("What is the first name of the customer you are searching for?");
            string firstName = Console.ReadLine();

            Console.WriteLine("What is the last name of the customer you are searching for?");
            string lastName = Console.ReadLine();

            List<Customer> customers = CustomerData.GetCustomersByFirstAndLastName(firstName, lastName);
            if (customers.Count == 0)
            {
                Console.WriteLine($"We have found {customers.Count} customers");
            }
            else
            {
                Console.WriteLine($"There is no customer named {firstName} {lastName}");
            }
        }

        private static void HandleRequestDisplayDetailsOfOrder()
        {
            Console.WriteLine("What is the order ID?: ");
            string orderId = Console.ReadLine();
            Console.WriteLine($"Searching for order {orderId}");
        }

        private static void HandleRequestDisplayOrderHistoryOfLocation()
        {
            Console.WriteLine("What is the location ID?");
            string locationId = Console.ReadLine();
            Console.WriteLine($"Searching for order history of location {locationId}");
        }

        private static void HandleRequestDisplayOrderHistoryOfCustomer()
        {
            Console.WriteLine("What is the customer ID?");
            string customerId = Console.ReadLine();
            Console.WriteLine($"Searching for order history of customer {customerId}");
        }

        private static void HandleRequestExit()
        {
            Console.WriteLine("Bye!");
            Environment.Exit(0);
        }

        private static void HandleRequestInvalid()
        {
            Console.WriteLine("Invalid input");
        }
    }
}
