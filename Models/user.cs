using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using ecommerce.Models;
 
namespace ecommerce.Models
{
    public class User : BaseEntity
    {
        public int UserId {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public DateTime CreatedAt {get;set;}
        public DateTime Updatedat {get; set;}
        public List<Guest> Guest {get; set;}

        public User(){
            Guest= new List<Guest>();
        }

    }
}