using System;
using System.ComponentModel.DataAnnotations;

namespace AmazonMVC.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        
        public int OrderId { get; set; }
        
        public int ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        public decimal Subtotal => Quantity * UnitPrice;

        // Navigation properties
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
} 