using GymManagement.Domain;

namespace GymManagement.Application.Common.Interfaces;

public interface ISubscriptionsRepository
{
    void AddSubscription(Subscription subscription);
}