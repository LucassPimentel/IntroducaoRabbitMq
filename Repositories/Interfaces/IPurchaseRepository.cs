using CompraService.Models;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading.Tasks;

namespace PurchaseService.Repositories.Interfaces
{
    public interface IPurchaseRepository
    {
        public Task DecreaseAmount(int id);
        Task<Product> GetProduct(int id);
        Task<List<Product>> GetProducts();
    }
}