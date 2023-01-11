using CQRSMediatRExample.Commands;
using CQRSMediatRExample.Models;
using CQRSMediatRExample.Persistence;
using MediatR;

namespace CQRSMediatRExample.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly FakeDbStore fakeDbStore;

        public AddProductHandler(FakeDbStore fakeDbStore)
        {
            this.fakeDbStore = fakeDbStore;
        }

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product  = await this.fakeDbStore.AddProduct(request.Product);
            return product;
        }
    }
}
