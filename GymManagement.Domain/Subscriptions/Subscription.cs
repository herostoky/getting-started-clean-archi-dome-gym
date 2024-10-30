using System.ComponentModel.DataAnnotations;

namespace GymManagement.Domain.Subscriptions;

public class Subscription
{
    private readonly Guid _adminId;
    public const string AdminIdFieldName = nameof(_adminId);
    
    public Guid Id { get; private set; }

    public SubscriptionType Type { get; private set; }

    public Subscription(SubscriptionType type, Guid adminId, Guid? id = null)
    {
        _adminId = adminId;
        Id = id ?? Guid.NewGuid();
        Type = type;
    }
    private Subscription()
    { }
}
