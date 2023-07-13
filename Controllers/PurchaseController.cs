using CompraService.Models;
using Microsoft.AspNetCore.Mvc;
using PurchaseService.Repositories.Interfaces;
using PurchaseService.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompraService.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly PurchaseServices _purchaseService;

        public PurchaseController(IPurchaseRepository purchaseRepository, PurchaseServices purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost]
        [Route("buy")]
        public async Task<IActionResult> Buy(int Id)
        {
            var response = await _purchaseService.Buy(Id);

            return response is true ? (Ok()) : (BadRequest());
        }

        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetProducts()
        {
            List<Product> response = await _purchaseService.GetProductsAsync();

            return Ok(response);
        }
    }
}
