using Core.Entities.OrderAggregate;
using skinet.Core.Specification;

namespace Core.Specification
{
    public class OrderByPaymentIntentIdSpecification : BaseSpecification<Order>
    {
        public OrderByPaymentIntentIdSpecification(string paymentIntentId) 
        : base(o => o.PaymentIntentId == paymentIntentId)
        {
        }
    }
}