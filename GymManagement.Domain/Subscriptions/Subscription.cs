using System.ComponentModel.DataAnnotations;

namespace GymManagement.Domain.Subscriptions;

public class Subscription
{
    [Key]
    public Guid Id { get; set; }
    public SubscriptionType Type { get; set; }
}
