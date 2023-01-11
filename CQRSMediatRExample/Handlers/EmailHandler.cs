using CQRSMediatRExample.Notifications;
using CQRSMediatRExample.Persistence;
using MediatR;

namespace CQRSMediatRExample.Handlers
{
    public class EmailHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly FakeDbStore fakeDbStore;

        public EmailHandler(FakeDbStore fakeDbStore)
        {
            this.fakeDbStore = fakeDbStore;
        }

        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await this.fakeDbStore.EventOccurred(notification.Product, "Email sent");
            await Task.CompletedTask;
        }
    }
}
