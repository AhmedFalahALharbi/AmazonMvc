using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AmazonMVC.Models;

namespace AmazonMVC.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        public static List<Product> _products = new List<Product>
        {
            new Product
            {
                ProductId = 1,
                Name = "Laptop",
                Description = "High-performance laptop with latest specifications",
                Price = 999.99M,
                StockQuantity = 50
            },
            new Product
            {
                ProductId = 2,
                Name = "Smartphone",
                Description = "Latest smartphone with advanced features",
                Price = 699.99M,
                StockQuantity = 100
            },
            new Product
            {
                ProductId = 3,
                Name = "Headphones",
                Description = "Wireless noise-canceling headphones",
                Price = 199.99M,
                StockQuantity = 200,
            }
        };

        [HttpGet]
        [Route("")] 
        public IActionResult Index()
        {
            return View(_products);
        }

        [HttpGet]
        [Route("{id:int}")]  
        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpGet]
        [Route("search")]  
        public IActionResult Search(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return View("Index", _products);

            var searchResults = _products.Where(p => 
                p.Name.Contains(term, StringComparison.OrdinalIgnoreCase) || 
                p.Description.Contains(term, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            return View("Index", searchResults);
        }
    }
} 