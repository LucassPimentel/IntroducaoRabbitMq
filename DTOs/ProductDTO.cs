using System;
using System.ComponentModel.DataAnnotations;

namespace PurchaseService.DTOs
{
    public class ProductDTO
    {
        [Key]
        public int Product_Id { get; set; }
        public int Client_Id { get; set; }
        public string Product_Name { get; set; }
        public double Product_Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
