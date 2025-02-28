using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AmazonMVC.Models;

namespace AmazonMVC.Controllers
{
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private static List<Order> _orders = new List<Order>();
        private static int _orderIdCounter = 1;

        [HttpGet]
        [Route("")] 
        public IActionResult Index()
        {
            return View(_orders);
        }

        [HttpGet]
        [Route("user/{userId:int}")] 
        public IActionResult UserOrders(int userId)
        {
            var userOrders = _orders.Where(o => o.UserId == userId).ToList();
            if (!userOrders.Any())
            {
                TempData["Message"] = "No orders found for this user.";
            }
            return View("Index", userOrders);
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] int ProductId, [FromForm] int Quantity, [FromForm] string ShippingAddress)
        {
            // Find the product
            var product = ProductController._products.FirstOrDefault(p => p.ProductId == ProductId);
            if (product == null)
            {
                ModelState.AddModelError("", "Product not found");
                return RedirectToAction("Index", "Product");
            }

            // Validate quantity
            if (Quantity <= 0 || Quantity > product.StockQuantity)
            {
                ModelState.AddModelError("Quantity", "Invalid quantity");
                return RedirectToAction("Details", "Product", new { id = ProductId });
            }

            if (string.IsNullOrWhiteSpace(ShippingAddress))
            {
                ModelState.AddModelError("ShippingAddress", "Shipping address is required");
                return RedirectToAction("Details", "Product", new { id = ProductId });
            }

            var order = new Order
            {
                OrderId = _orderIdCounter++,
                OrderDate = DateTime.Now,
                ShippingAddress = ShippingAddress,
                OrderStatus = "Pending",
                TotalAmount = product.Price * Quantity,
                UserId = 1  
            };

            var orderDetail = new OrderDetail
            {
                OrderDetailId = order.OrderId,
                OrderId = order.OrderId,
                ProductId = ProductId,
                Quantity = Quantity,
                UnitPrice = product.Price
            };

            product.StockQuantity -= Quantity;

            _orders.Add(order);
            
            TempData["Success"] = $"Order placed successfully! Order ID: {order.OrderId}";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("{id:int}")] 
        public IActionResult Details(int id)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
    }
} 