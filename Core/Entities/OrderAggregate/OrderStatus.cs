using System.Runtime.Serialization;

namespace Core.Entities.OrderAggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,

        [EnumMember(Value = "Payment Recieved")]
        PaymentRecieved,

        [EnumMember(Value = "Payment Failed")]
        PaymentFailed,

        // [EnumMember(Value = "Shipped")]
        // Shipped,

        // [EnumMember(Value = "Complete")]
        // Complete
    }
}