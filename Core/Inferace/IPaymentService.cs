using System.Threading.Tasks;
using skinet.Core.Entities;

namespace Core.Inferace
{
    public interface IPaymentService
    {
        Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
    }
}