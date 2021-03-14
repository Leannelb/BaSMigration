using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;

namespace Core.Interfaces
{
    public class IOrderService
    {
        Task<Order> CreateOrderAsync(string buyerEmail,
                                     int deliveryMethod,
                                     string basketId,
                                     Address shippingAddress);
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);
        Task<Order> GetOrdrByIdAsync(int id, string BuyerEmail);
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsyc();
    }
}