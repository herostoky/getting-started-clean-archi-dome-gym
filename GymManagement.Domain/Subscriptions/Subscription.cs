using System.ComponentModel.DataAnnotations;

namespace GymManagement.Domain.Subscriptions;

public class Subscription(SubscriptionType type, Guid adminId, Guid? id = null)
{
    private readonly Guid _adminId = adminId;
    
    [Key]
    public Guid Id { get; set; } = id ?? Guid.NewGuid();

    public SubscriptionType Type { get; set; } = type;
}
