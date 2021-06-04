using System.Threading.Tasks;
using Core.Inferace;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using skinet.API.Controllers;
using skinet.API.Errors;
using skinet.Core.Entities;

namespace API.Controllers
{
    public class PaymentController : BaseApiController
    {
        private readonly IPaymentService paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [Authorize]
        [HttpPost("{basketId}")]
        public async Task<ActionResult<CustomerBasket>> CreateOrUpdatePaymentIntent(string basketId)
        {
            var basket = await this.paymentService.CreateOrUpdatePaymentIntent(basketId);

            if(basket == null) return BadRequest(new ApiResponse(400, "Problem with your basket"));

            return basket;
        }
    }
}