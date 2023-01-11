using CQRSMediatRExample.Commands;
using CQRSMediatRExample.Models;
using CQRSMediatRExample.Notifications;
using CQRSMediatRExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatRExample.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await this.mediator.Send(new GetProductsQuery());
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult> PostProduct([FromBody] Product p)
        {
            var result = await this.mediator.Send(new AddProductCommand(p));

            // this.mediator.Publish(new ProductAddedNotification())

            return CreatedAtRoute(null, new { Id = result.Id }, result);
        }
    }
}
