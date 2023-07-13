using CompraService.Database;
using CompraService.Models;
using PurchaseService.DTOs;
using PurchaseService.RabbitMqClient;
using PurchaseService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PurchaseService.Services
{
    public class PurchaseServices
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IRabbitMqClient _rabbitMqClient;

        public PurchaseServices(IPurchaseRepository purchaseRepository, IRabbitMqClient rabbitMqClient)
        {
            _purchaseRepository = purchaseRepository;
            _rabbitMqClient = rabbitMqClient;
        }

        private ProductDTO ConvertProductToProductDTO(Product product)
        {
            return new ProductDTO()
            {
                Client_Id = product.Client_Id,
                Product_Id = product.Product_Id,
                Product_Name = product.Product_Name,
                Product_Price = product.Product_Price,
                OrderDate = DateTime.Now
            };
        }




        public async Task<bool> Buy(int Id)
        {
            await _purchaseRepository.DecreaseAmount(Id);
            var product = await _purchaseRepository.GetProduct(Id);
            var productDto = ConvertProductToProductDTO(product);

            _rabbitMqClient.PublishOrder(productDto);

            return true;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _purchaseRepository.GetProducts();
        }
    }
}
