using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Core.Specifications;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IGenericRepository<Order> _orderRepo;
        private readonly IGenericRepository<DeliveryMethod> _dmRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IBasketRepository _basketRepoi;

        public OrderService(IGenericRepository<Order> orderRepo, IGenericRepository<DeliveryMethod> dmRepo, IGenericRepository<Product> productRepo,
        IBasketRepository basketRepoi)
        {
            _basketRepoi = basketRepoi;
            _productRepo = productRepo;
            _dmRepo = dmRepo;
            _orderRepo = orderRepo;
        }

        public Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            // get basket from repo
            var basket = await _basketRepo.GetBasketAsync(basketId)
            
            // get products from the repop
            var items = new List<OrderItem>();
            foreach(var item in basket.Items)
            {
                var productItem = await _productRepo.GetByIdAsync(item.Id);
                var itemOrdered = await ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl();
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }

            // get delivery method fromthe repo
            var deliveryMethod = await _dmRepo.GetByIdAsync(deliveryMethodId);

            // calc subtotal
            // 
            var subtotal = items.Sum(item => item.Price * item.Quantity);            // create order
            
            // create order
            var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subtotal);

            // TODO save to db
            
            // return order
        }
    }
}