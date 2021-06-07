using System.Threading.Tasks;
using Core.Entities.OrderAggregate;
using skinet.Core.Entities;

namespace Core.Inferace
{
    public interface IPaymentService
    {
        Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
        Task<Order> UpdateOrderPaymentSucceeded(string paymentIntentId);
        Task<Order> UpdateOrderPaymentFailed(string paymentIntentId);
    }
}