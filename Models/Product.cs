using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using ecommerce.Models;
 
namespace ecommerce.Models
{
    public class Product : BaseEntity
    {
        
        public int ProductId {get; set;}
        [Required]
        public string Name {get; set;}
        public string Image {get; set;}
        [Required]
        public string Description {get; set;}
        [Required]
        public int Quantity {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get; set;}
        public List<Order> Orders {get; set;}

        public Product(){
            Orders= new List<Order>();
        }

    }
}