using GymManagement.Domain;
using MediatR;
using ErrorOr;

namespace GymManagement.Application.Subscriptions.Queries.GetSubscription;

public record GetSubscriptionQuery(Guid Id): IRequest<ErrorOr<Subscription>>;