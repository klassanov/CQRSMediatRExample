using CQRSMediatRExample.Models;
using CQRSMediatRExample.Persistence;
using CQRSMediatRExample.Queries;
using MediatR;

namespace CQRSMediatRExample.Handlers
{
    public class ProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly FakeDbStore fakeDbStore;

        public ProductByIdHandler(FakeDbStore fakeDbStore)
        {
            this.fakeDbStore = fakeDbStore;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) 
            => await this.fakeDbStore.GetProductById(request.Id);
    }
}
