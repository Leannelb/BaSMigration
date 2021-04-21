using System;
using System.Linq.Expressions;
using Core.Entities.OrderAggregate;

namespace Core.Specifications
{
    public class OrdersByPaymentIntentIdWithItemSpecification : BaseSpecification<Order>
    {
        public OrdersByPaymentIntentIdWithItemSpecification(string paymentIntentId) 
            : base(o => o.PaymentIntentId == paymentIntentId)
        {
        }
    }
}