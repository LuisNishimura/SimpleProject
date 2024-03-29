﻿using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace WebAPIDemo.Models
{
    public class WebAPIDemoContextInitializer : DropCreateDatabaseAlways<WebAPIDemoContext>
    {
        protected override void Seed(WebAPIDemoContext context)
        {
            var books = new List<Book>()
            {
                new Book() { Name="War and Peace", Author ="Tolstoy", Price=19.95m },
                new Book() { Name="As I Lay Dying", Author ="Faulkner", Price=9.95m },
                new Book() { Name="Harry Potter 1", Author ="J.K. Rowling", Price=29.95m },
                new Book() { Name="Pro Win 8", Author ="Liberty", Price=49.95m },
                new Book() { Name="Book One", Author ="Author 1", Price=10.95m },
                new Book() { Name="Book Two", Author ="Auhtor 2", Price=20.95m } ,
                new Book() { Name="Book 3", Author ="Author 3", Price=30.95m }
            };

            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();

            var order = new Order()
            {
                Customer = "John Doe",
                OrderDate = DateTime.Today.AddDays(-2)
            };

            var details = new List<OrderDetail>()
            {
                new OrderDetail() { Book = books[0], Quantity = 1, Order = order},
                new OrderDetail() { Book = books[1], Quantity= 2, Order = order},
                new OrderDetail() { Book = books[2], Quantity= 3, Order = order}
            };

            context.Orders.Add(order);
            details.ForEach(o => context.OrderDetails.Add(o));
            context.SaveChanges();

            order = new Order()
            {
                Customer = "Joe Smith",
                OrderDate = DateTime.Today.AddDays(-1)
            };

            details = new List<OrderDetail>()
            {
                new OrderDetail() { Book = books[1], Quantity = 1, Order = order},
                new OrderDetail() { Book = books[1], Quantity= 1, Order = order},
                new OrderDetail() { Book = books[3], Quantity= 12, Order = order},
                new OrderDetail() { Book = books[4], Quantity= 3, Order = order}
            };

            context.Orders.Add(order);
            details.ForEach(o => context.OrderDetails.Add(o));
            context.SaveChanges();

            order = new Order()
            {
                Customer = "Ward Bell",
                OrderDate = DateTime.Today
            };

            details = new List<OrderDetail>()
            {
                new OrderDetail() { Book = books[2], Quantity = 1, Order = order},
                new OrderDetail() { Book = books[4], Quantity= 1, Order = order},
                new OrderDetail() { Book = books[3], Quantity= 1, Order = order},
                new OrderDetail() { Book = books[1], Quantity= 3, Order = order}
            };

            context.Orders.Add(order);
            details.ForEach(o => context.OrderDetails.Add(o));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}