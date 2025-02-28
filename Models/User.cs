using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmazonMVC.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Address { get; set; }
        
        // Navigation property
        public virtual ICollection<Order> Orders { get; set; }
    }
}