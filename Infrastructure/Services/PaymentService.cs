using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.OrderAggregate;
using Core.Inferace;
using Core.Specification;
using Microsoft.Extensions.Configuration;
using skinet.Core.Entities;
using skinet.Core.Inferace;
using Stripe;
using Order = Core.Entities.OrderAggregate.Order;
using Product = Core.Entities.Product;

namespace Infrastructure.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IBasketRepository basketRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration config;
        public PaymentService(IBasketRepository basketRepository, IUnitOfWork unitOfWork, IConfiguration config)
        {
            this.config = config;
            this.unitOfWork = unitOfWork;
            this.basketRepository = basketRepository;
        }

        public async Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId)
        {
            StripeConfiguration.ApiKey = this.config["StripeSettings:SecretKey"];

            var basket = await this.basketRepository.GetBasketAsync(basketId);

            if(basket == null)
            {
                return null;
            }
            
            var shippingPrice = 0m;

            if(basket.DeliveryMethodId.HasValue)
            {
                var deliveryMethod = await this.unitOfWork.Repository<DeliveryMethod>().GetByIdAsync((int)basket.DeliveryMethodId);
                shippingPrice = deliveryMethod.Price;
            }

            foreach (var item in basket.Items)
            {
                var productItem = await this.unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                if(item.Price != productItem.Price)
                {
                    item.Price = productItem.Price;
                }
            }

            var service = new PaymentIntentService();

            PaymentIntent intent;

            if(string.IsNullOrEmpty(basket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long) basket.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long)shippingPrice * 100,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> {"card"}
                };
                intent = await service.CreateAsync(options);
                basket.PaymentIntentId = intent.Id;
                basket.ClientSecret = intent.ClientSecret;
            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                   Amount = (long) basket.Items.Sum(i => i.Quantity * (i.Price * 100)) + (long)shippingPrice * 100
                };
                await service.UpdateAsync(basket.PaymentIntentId, options);
            }

            await this.basketRepository.UpdateBasketAsync(basket);

            return basket;
        }

        public async Task<Core.Entities.OrderAggregate.Order> UpdateOrderPaymentFailed(string paymentIntentId)
        {
           var spec = new OrderByPaymentIntentIdSpecification(paymentIntentId);
           var order = await this.unitOfWork.Repository<Core.Entities.OrderAggregate.Order>().GetEntityWithSpec(spec);

           if(order == null)
           {
               return null;
           }

           order.Status = OrderStatus.PaymentFailed;
           await this.unitOfWork.Complete();

           return order;
        }

        public async Task<Core.Entities.OrderAggregate.Order> UpdateOrderPaymentSucceeded(string paymentIntentId)
        {
           var spec = new OrderByPaymentIntentIdSpecification(paymentIntentId);
           var order = await this.unitOfWork.Repository<Order>().GetEntityWithSpec(spec);

           if(order == null)
           {
               return null;
           }

           order.Status = OrderStatus.PaymentReceived;
           this.unitOfWork.Repository<Order>().Update(order);

           await this.unitOfWork.Complete();

           return order;
        }
    }
}