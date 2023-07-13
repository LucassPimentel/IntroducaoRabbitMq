using System.ComponentModel.DataAnnotations;

namespace CompraService.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }
        public int Client_Id { get; set; }
        public string Product_Name { get; set; }
        public double Product_Price { get; set; }
        public int Amount { get; set; }
    }
}