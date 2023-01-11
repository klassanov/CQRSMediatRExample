using CQRSMediatRExample.Notifications;
using CQRSMediatRExample.Persistence;
using MediatR;

namespace CQRSMediatRExample.Handlers
{
    public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly FakeDbStore fakeDbStore;

        public CacheInvalidationHandler(FakeDbStore fakeDbStore)
        {
            this.fakeDbStore = fakeDbStore;
        }

        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await this.fakeDbStore.EventOccurred(notification.Product, "Cache invalidation");
            await Task.CompletedTask;
        }
    }
}
