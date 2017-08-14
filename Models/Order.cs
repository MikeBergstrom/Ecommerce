using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using ecommerce.Models;
 
namespace ecommerce.Models
{
    public class Order : BaseEntity
    {
        public int OrderId {get; set;}
        public int UserId {get; set;}
        public User User {get;set;}
        public int ProductId {get; set;}
        public Product Product {get; set;}
        [Required]
        public int Quantity {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get; set;}
    }
}