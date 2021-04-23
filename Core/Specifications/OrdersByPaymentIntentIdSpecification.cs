using System;
using System.Linq.Expressions;
using Core.Entities.OrderAggregate;

namespace Core.Specifications
{
    public class OrdersByPaymentIntentIdSpecification : BaseSpecification<Order>
    {
        public OrdersByPaymentIntentIdSpecification(string paymentIntentId) 
            : base(o => o.PaymentIntentId == paymentIntentId)
        {
        }
    }
}