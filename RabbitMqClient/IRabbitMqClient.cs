using PurchaseService.DTOs;

namespace PurchaseService.RabbitMqClient
{
    public interface IRabbitMqClient
    {
        void PublishOrder(ProductDTO productDto);
    }
}
