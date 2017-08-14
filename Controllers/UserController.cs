using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ecommerce.Models;
using System.Linq;

namespace ecommerce.Controllers
{
    public class UserController : Controller
    {
        private UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }
        // GET: /Home/
        [HttpGet]
        [Route("Customers")]
        public IActionResult Customers()
        {
            ViewBag.users = _context.user.ToList();
            return View();
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(User user){
            if(ModelState.IsValid){
                var foundUser = _context.user.Where(u => u.Name == user.Name).ToList();
                if(foundUser.Count <0){
                    ViewBag.error ="Customer is already registered";
                    ViewBag.users = _context.user.ToList();
                    return View("Customers");
                } else {
                    user.CreatedAt = DateTime.Now;
                    user.UpdatedAt = DateTime.Now;
                    _context.Add(user);
                    _context.SaveChanges();
                    ViewBag.users = _context.user.ToList();
                    return View("Customers");
                }
            } else {
                ViewBag.error = "Customer Name is required";
                ViewBag.users = _context.user.ToList();
                return View("Customers");
            }
        }
        [HttpGet]
        [Route("deleteUser/{UserId}")]
        public IActionResult DeleteUser(int UserId){
            User user = _context.user.Where(u => u.UserId == UserId).FirstOrDefault();
            _context.user.Remove(user);
            _context.SaveChanges();
            ViewBag.users = _context.user.ToList();
            return View("Customers");
        }      
    }
}
