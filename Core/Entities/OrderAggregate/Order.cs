using System;
using System.Collections.Generic;

namespace Core.Entities.OrderAggregate
{
    public class Order : BaseEntity
    // when they derive fom BaseEntity, this gives it an id
    {
        public Order()
        {
        }

        public Order(IReadOnlyList<OrderItem> orderItems, string buyerEmail, Address shipToAddress, DeliveryMethod deliveryMethod, decimal subtotal)
        {
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            OrderItems = orderItems;
            Subtotal = subtotal;
            // order Date, Status & PaymentID are set elsewhere. Initalised below
        }

        // get the order via the buyerEmail
        public string BuyerEmail {get;set;}
        // Time of order got from pc at time not changable via timezone
        public DateTimeOffset OrderData {get;set;} = DateTimeOffset.Now;
        public Address ShipToAddress {get;set;}
        public DeliveryMethod DeliveryMethod {get;set;}
        public IReadOnlyList<OrderItem> OrderItems {get; set;}
        public decimal Subtotal {get; set;}
        public OrderStatus Status {get; set;} = OrderStatus.Pending;
        public string PaymentIntentId {get; set;}
        
        public decimal GetTotal() {
            return Subtotal + DeliveryMethod.Price;
        }
    }
}