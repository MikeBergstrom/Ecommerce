using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using ecommerce.Models;
 
namespace ecommerce.Models
{
    public class User : BaseEntity
    {
        public int UserId {get; set;}
        [Required]
        public string Name {get; set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get; set;}
        public List<Order> Orders {get; set;}

        public User(){
            Orders= new List<Order>();
        }

    }
}