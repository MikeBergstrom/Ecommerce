using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ecommerce.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private UserContext _context;

        public ProductController(UserContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            List<Order> orders = _context.Orders
                                    .Include(order => order.User)
                                    .Include(ord => ord.Product)
                                    .OrderByDescending(o => o.CreatedAt)
                                    .ToList();
            ViewBag.orders = orders.Take(3);
            List<Product> products = _context.Product.OrderByDescending(p => p.CreatedAt).ToList();
            ViewBag.products = products.Take(4);
            List<User> customers = _context.User.OrderByDescending(u => u.CreatedAt).ToList();
            ViewBag.customers = customers.Take(3);
            return View();
        }
        [HttpGet]
        [Route("Products")]
        public IActionResult Products()
        {
            ViewBag.products = _context.Product.ToList();
            return View();
        }
        [HttpGet]
        [Route("Orders")]
        public IActionResult Orders()
        {
            List<Order> orders = _context.Orders
                                    .Include(order => order.User)
                                    .Include(ord => ord.Product)
                                    .OrderByDescending(o => o.CreatedAt)
                                    .ToList();
            ViewBag.orders = orders;
            ViewBag.products = _context.Product.ToList();
            ViewBag.customers = _context.User.ToList();
            return View();
        }
        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct(Product NewProduct)
        {
            if (ModelState.IsValid)
            {
                NewProduct.UpdatedAt = DateTime.Now;
                NewProduct.CreatedAt = DateTime.Now;
                _context.Add(NewProduct);
                _context.SaveChanges();
                return RedirectToAction("Products");
            }
            else
            {
                ViewBag.products = _context.Product.ToList();
                return View("Products");
            }
        }
        [HttpPost]
        [Route("AddOrder")]
        public IActionResult AddOrder(Order newOrder)
        {
            Product product = _context.Product.FirstOrDefault();
            if (product.Quantity >= newOrder.Quantity)
            {
                if (ModelState.IsValid)
                {
                    newOrder.CreatedAt = DateTime.Now;
                    newOrder.UpdatedAt = DateTime.Now;
                    product.Quantity -= newOrder.Quantity;
                    _context.Add(newOrder);
                    _context.SaveChanges();
                    return RedirectToAction("Orders");
                }
                else
                {
                    List<Order> orders = _context.Orders
                                    .Include(order => order.User)
                                    .Include(ord => ord.Product)
                                    .OrderByDescending(o => o.CreatedAt)
                                    .ToList();
                    ViewBag.orders = orders;
                    ViewBag.products = _context.Product.ToList();
                    ViewBag.customers = _context.User.ToList();
                    return View("Orders");
                }
            }
            else
            {
                List<Order> orders = _context.Orders
                                    .Include(order => order.User)
                                    .Include(ord => ord.Product)
                                    .OrderByDescending(o => o.CreatedAt)
                                    .ToList();
                ViewBag.orders = orders;
                ViewBag.error = "Not enough product quantity for that order";
                ViewBag.products = _context.Product.ToList();
                ViewBag.customers = _context.User.ToList();
                return View("Orders");
            }
        }
    }
}
