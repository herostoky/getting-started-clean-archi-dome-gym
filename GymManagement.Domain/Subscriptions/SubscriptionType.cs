using Ardalis.SmartEnum;

namespace GymManagement.Domain.Subscriptions;

public class SubscriptionType(string name, int value)
    : SmartEnum<SubscriptionType>(name, value)
{
    private static readonly SubscriptionType Free = new(nameof(Free), 0);
    private static readonly SubscriptionType Starter = new(nameof(Starter), 1);
    private static readonly SubscriptionType Pro = new(nameof(Pro), 2);
}