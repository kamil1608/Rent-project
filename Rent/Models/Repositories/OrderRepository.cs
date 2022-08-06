using Rent.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Rent.Models.Repositories
{
    public class OrderRepository
    {
        public List<Order> GetOrders(string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Orders
                    .Include(x => x.Client)
                    .Where(x => x.UserId == userId)
                    .ToList();
            }
        }

        public Order GetOrder(int id, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Orders
                     .Include(x => x.OrderItems)
                     .Include(x => x.OrderItems.Select(y => y.Product))
                     .Include(x => x.MethodOfPayment)
                     .Include(x => x.User)
                     .Include(x => x.User.Address)
                     .Include(x => x.Client)
                     .Include(x => x.Client.Address)
                     .Single(x => x.Id == id && x.UserId == userId);
            }
        }

        public List<MethodOfPayment> GetMethodsOfPayment()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.MethodOfPayments.ToList();
            }
        }

        public OrderItem GetOrderItem(int orderItemId, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.OrderItems
                    .Include(x => x.Order)
                    .Single(x => x.Id == orderItemId && x.Order.UserId == userId);
            }
        }

        public void Add(Order order)
        {
            using (var context = new ApplicationDbContext())
            {
                order.CreatedDate = DateTime.Now;
                context.Orders.Add(order);
                context.SaveChanges();

            }
        }

        public void Update(Order order)
        {
            using (var context = new ApplicationDbContext())
            {
                var orderToUpdate = context.Orders
                    .Single(x => x.Id == order.Id && x.UserId == order.UserId);

                
                orderToUpdate.ClientId = order.ClientId;
                orderToUpdate.Comments = order.Comments;
                orderToUpdate.MethodOfPaymentId = order.MethodOfPaymentId;
                orderToUpdate.PaymentDeadline = order.PaymentDeadline;
                orderToUpdate.Title = order.Title;

                context.SaveChanges();

            }
        }

        public void AddItem(OrderItem orderItem, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var order = context.Orders
                    .Single(x => x.Id == orderItem.OrderId && x.UserId == userId);

                context.OrderItems.Add(orderItem);
                context.SaveChanges();
            }
        }

        public void UpdateItem(OrderItem orderItem, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var itemToUpdate = context.OrderItems
                    .Include(x => x.Product)
                    .Include(x => x.Order)
                    .Single(x =>
                        x.Id == orderItem.Id && x.Order.UserId == userId);

                itemToUpdate.Lp = orderItem.Lp;
                itemToUpdate.ProductId = orderItem.ProductId;
                itemToUpdate.Number = orderItem.Number;
                itemToUpdate.Value = orderItem.Product.Value * orderItem.Value;

                context.SaveChanges();

            }
        }

        public decimal UpdateOrderValue(int orderId, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var order = context.Orders
                    .Include(x => x.OrderItems)
                    .Single(x => x.Id == orderId && x.UserId == userId);

                order.Value = order.OrderItems.Sum(x => x.Value);
                context.SaveChanges();
                return order.Value;
            }
        }

        public void Delete(int id, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var orderToDelete = context.Orders
                    .Single(x => x.Id == id && x.UserId == userId);
                context.Orders.Remove(orderToDelete);
                context.SaveChanges();
            }
        }

        public void DeleteItem(int id, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var orderToDelete = context.OrderItems
                    .Include(x => x.Order)
                    .Single(x => x.Id == id && x.Order.UserId == userId);
                context.OrderItems.Remove(orderToDelete);
                context.SaveChanges();
            }
        }
    }
}