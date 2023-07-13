using CompraService.Database;
using CompraService.Models;
using Microsoft.EntityFrameworkCore;
using PurchaseService.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompraService.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly DatabaseContext _databaseContext;
        public PurchaseRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task DecreaseAmount(int id)
        {
            var product = await _databaseContext.Product.FindAsync(id);
            product.Amount -= 1;

            _databaseContext.Update(product);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _databaseContext.Product.FindAsync(id);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _databaseContext.Product.ToListAsync();
        }
    }
}
