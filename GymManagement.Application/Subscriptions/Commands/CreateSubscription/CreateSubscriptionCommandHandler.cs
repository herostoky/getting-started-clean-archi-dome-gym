using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain;
using MediatR;

namespace GymManagement.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommandHandler(ISubscriptionsRepository subscriptionsRepository)
    : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Subscription>>
{
    public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        // Create a subscription
        var subscription = new Subscription()
        {
            Id = Guid.NewGuid(),
        };
        
        // Add it to database
        await subscriptionsRepository.AddSubscriptionAsync(subscription);

        // await unitOfWork.CommitChangesAsync();
        
        // Return subscription
        return subscription;
    }
}