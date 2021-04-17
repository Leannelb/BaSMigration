using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public class IPaymentService
    {
        Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
    }
}