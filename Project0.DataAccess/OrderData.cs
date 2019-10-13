﻿using Microsoft.EntityFrameworkCore;
using Project0.BusinessLogic;
using Project0.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Project0.DataAccess
{
    public static class OrderData
    {
        public static BusinessOrder GetOrderDetailsById(int id)
        {
            DbContextOptions<TThreeTeasContext> options = new DbContextOptionsBuilder<TThreeTeasContext>()
                .UseSqlServer(SecretConfiguration.ConnectionString)
                .UseLoggerFactory(CustomerData.AppLoggerFactory)
                .Options;
            using var context = new TThreeTeasContext(options);

            Orders order = context.Orders.FirstOrDefault(o => o.Id == id);
            if (order is null)
            {
                return null;
            }

            Location loc = context.Location.Where(l => l.Id == order.LocationId).FirstOrDefault();
            BusinessLocation bLocation = new BusinessLocation()
            {
                Id = loc.Id,
                Address = loc.Address,
                City = loc.City,
                Zipcode = loc.Zipcode,
                State = loc.State
            };

            List<Inventory> inventories = context.Inventory.Where(i => i.LocationId == loc.Id).ToList();
            foreach (Inventory inv in inventories)
            {
                Product prod = context.Product.Where(p => p.Id == inv.ProductId).FirstOrDefault();
                BusinessProduct bProd = new BusinessProduct()
                {
                    Id = prod.Id,
                    Name = prod.Name,
                    Price = prod.Price
                };
                bLocation.AddProduct(bProd, inv.Stock);
            }

            Customer customer = context.Customer.Where(c => c.Id == order.CustomerId).FirstOrDefault();
            BusinessCustomer bCustomer = new BusinessCustomer()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };

            BusinessOrder bOrder = new BusinessOrder
            {
                Id = order.Id,
                StoreLocation = bLocation,
                Customer = bCustomer,
                OrderTime = order.OrderTime
            };

            List<LineItem> lineItems = context.LineItem.Where(l => l.OrdersId == order.Id).ToList();
            foreach (LineItem item in lineItems)
            {
                Product product = context.Product.Where(p => p.Id == item.ProductId).FirstOrDefault();
                BusinessProduct bProduct = new BusinessProduct()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                };
                bOrder.AddLineItem(bProduct, item.Quantity);
            }

            return bOrder;
        }
        public static ICollection<BusinessOrder> GetOrdersByLocationId(int lId)
        {
            DbContextOptions<TThreeTeasContext> options = new DbContextOptionsBuilder<TThreeTeasContext>()
                .UseSqlServer(SecretConfiguration.ConnectionString)
                .UseLoggerFactory(CustomerData.AppLoggerFactory)
                .Options;
            using var context = new TThreeTeasContext(options);

            List<BusinessOrder> bOrders = new List<BusinessOrder>();
            List<Orders> orders = context.Orders.Where(o => o.LocationId == lId).ToList();
            foreach (Orders o in orders)
            {
                bOrders.Add(GetOrderDetailsById(o.Id));
            }
            return bOrders;
        }
        public static ICollection<BusinessOrder> GetOrdersByCustomerId(int cId)
        {
            DbContextOptions<TThreeTeasContext> options = new DbContextOptionsBuilder<TThreeTeasContext>()
                .UseSqlServer(SecretConfiguration.ConnectionString)
                .UseLoggerFactory(CustomerData.AppLoggerFactory)
                .Options;
            using var context = new TThreeTeasContext(options);

            List<BusinessOrder> bOrders = new List<BusinessOrder>();
            List<Orders> orders = context.Orders.Where(o => o.CustomerId == cId).ToList();
            foreach (Orders o in orders)
            {
                bOrders.Add(GetOrderDetailsById(o.Id));
            }
            return bOrders;
        }
    }
}
