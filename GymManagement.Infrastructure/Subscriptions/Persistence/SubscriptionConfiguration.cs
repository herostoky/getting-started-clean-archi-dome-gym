using GymManagement.Domain.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagement.Infrastructure.Subscriptions.Persistence;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.HasKey(subscription => subscription.Id);
        
        builder.Property(subscription => subscription.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(Subscription.AdminIdFieldName)
            .HasColumnName("AdminId");
        
        builder.Property(subscription => subscription.Type)
            .HasConversion(
                type => type.Value,
                value => SubscriptionType.FromValue(value));
    }
}