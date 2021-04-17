using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.MyServices
{
    public class PaymentService : IPaymentService
    {
        public Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId)
        {
            throw new System.NotImplementedException();
        }
    }
}