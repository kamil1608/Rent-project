using Microsoft.AspNet.Identity;
using Rent.Models.Domains;
using Rent.Models.Repositories;
using Rent.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rent.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private ClientRepository _clientRepository = new ClientRepository();
        private OrderRepository _orderRepository = new OrderRepository();        
        private ProductRepository _productRepository = new ProductRepository();


        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var orders = _orderRepository.GetOrders(userId);


            return View(orders);
        }

        public ActionResult Order(int id = 0)
        {
            var userId = User.Identity.GetUserId();

            var order = id == 0 ?
                GetNewOrder(userId) :
                _orderRepository.GetOrder(id, userId);

            var vm = PrepareOrderVm(order, userId);

            return View(vm);
        }

        private EditOrderViewModel PrepareOrderVm(Order order, string userId)
        {
            return new EditOrderViewModel
            {
                Order = order,
                Heading = order.Id == 0 ? "Dodawanie zamówienia" : "Edycja zamówienia",
                Clients = _clientRepository.GetClients(userId),
                MethodOfPayments = _orderRepository.GetMethodsOfPayment()
            };
        }

        private Order GetNewOrder(string userId)
        {
            return new Order
            {
                UserId = userId,
                CreatedDate = DateTime.Now,
                PaymentDeadline = DateTime.Now.AddDays(7)
            };
        }




        public ActionResult OrderItem(int orderId, int orderItemId = 0)
        {
            var userId = User.Identity.GetUserId();

            var orderItem = orderItemId == 0 ? GetNewItem(orderId, orderItemId) :
                _orderRepository.GetOrderItem(orderItemId, userId);

            var vm = PrepareOrderItemVm(orderItem);

            return View(vm);
        }


        private EditOrderItemViewModel PrepareOrderItemVm(OrderItem orderItem)
        {
            return new EditOrderItemViewModel
            {
                OrderItem = orderItem,
                Heading = orderItem.Id == 0 ? "Dodawanie produktu do zamówienia" : "Pozycja",
                Products = _productRepository.GetProducts()
            };
        }


        private OrderItem GetNewItem(int orderId, int orderItemId)
        {
            return new OrderItem
            {
                OrderId = orderId,
                Id = orderItemId
            };
        }




        [HttpPost]
        public ActionResult Order(Order order)
        {
            var userId = User.Identity.GetUserId();
            order.UserId = userId;


            if (!ModelState.IsValid)
            {
                var vm = PrepareOrderVm(order, userId);
                return View("Order", vm);
            }

            if (order.Id == 0)
            {
                _orderRepository.Add(order);
            }
            else
            {
                _orderRepository.Update(order);
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult OrderItem(OrderItem orderItem)
        {
            var userId = User.Identity.GetUserId();

            var product = _productRepository.GetProduct(orderItem.ProductId);


            if (!ModelState.IsValid)
            {
                var vm = PrepareOrderItemVm(orderItem);
                return View("OrderItem", vm);
            }

            orderItem.Value = orderItem.Number * product.Value;

            if (orderItem.Id == 0)
            {
                _orderRepository.AddItem(orderItem, userId);
            }
            else
            {
                _orderRepository.UpdateItem(orderItem, userId);
            }

            _orderRepository.UpdateOrderValue(orderItem.OrderId, userId);



            return RedirectToAction("Order", new { id = orderItem.OrderId });
        }








        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                _orderRepository.Delete(id, userId);
            }
            catch (Exception exception)
            {

                return Json(new { Success = false, Message = exception.Message });
            }


            return Json(new { Success = true });
        }


        [HttpPost]
        public ActionResult DeleteOrder(int id, int orderId)
        {
            var orderValue = 0m;

            try
            {
                var userId = User.Identity.GetUserId();
                _orderRepository.DeleteItem(id, userId);
                orderValue = _orderRepository.UpdateOrderValue(orderId, userId);
            }
            catch (Exception exception)
            {

                return Json(new { Success = false, Message = exception.Message });
            }


            return Json(new { Success = true, InvoiceValue = orderValue });
        }





        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}