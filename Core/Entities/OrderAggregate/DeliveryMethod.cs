namespace Core.Entities.OrderAggregate
{
    public class DeliveryMethod : BaseEntity
    // allows the client to choose the delivery method
    {
        public string ShortName {get; set;}
        public string DeliveryTime {get; set;}
        public string Description {get; set;}
        public decimal Price {get; set;}
    }
}