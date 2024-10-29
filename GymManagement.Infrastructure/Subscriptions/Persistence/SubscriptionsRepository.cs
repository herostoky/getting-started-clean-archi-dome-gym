using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

public class SubscriptionsRepository: ISubscriptionsRepository
{
    private static readonly IList<Subscription> _subscriptions = new List<Subscription>();
    public Task AddSubscriptionAsync(Subscription subscription)
    {
        _subscriptions.Add(subscription);
        return Task.CompletedTask;
    }
}