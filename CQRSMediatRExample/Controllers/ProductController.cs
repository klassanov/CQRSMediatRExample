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

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await this.mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> PostProduct([FromBody] Product p)
        {
            var result = await this.mediator.Send(new AddProductCommand(p));

            await this.mediator.Publish(new ProductAddedNotification(result));

            //Does not require  Name = "GetProductById" above GetProductById method, but even if there is a name, it doesn't bother
            return CreatedAtAction(nameof(GetProductById), new { Id = result.Id }, result);

            //Requires Name = "GetProductById" above GetProductById method
            //return CreatedAtRoute(nameof(GetProductById), new { Id = result.Id }, result);
        }
    }
}
