using CQRSMediatRExample.Models;
using CQRSMediatRExample.Persistence;
using CQRSMediatRExample.Queries;
using MediatR;

namespace CQRSMediatRExample.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly FakeDbStore fakeDbStore;

        public GetProductsHandler(FakeDbStore fakeDbStore)
        {
            this.fakeDbStore = fakeDbStore;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await this.fakeDbStore.GetAllProducts();
        }
    }
}
