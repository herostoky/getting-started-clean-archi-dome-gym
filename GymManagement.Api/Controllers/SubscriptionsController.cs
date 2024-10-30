using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Application.Subscriptions.Queries.GetSubscription;
using GymManagement.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DomainSubscriptionType = GymManagement.Domain.Subscriptions.SubscriptionType;

namespace GymManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController(ISender requestSender)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
    {
        if(!DomainSubscriptionType.TryFromName(request.SubscriptionType.ToString(), out var subscriptionType))
        {
            return Problem(statusCode: StatusCodes.Status400BadRequest,
                detail: $"Subscription type is not valid: {request.SubscriptionType}");
        }
        var command = new CreateSubscriptionCommand(subscriptionType, request.AdminId);
        var createSubscriptionResult = await requestSender.Send(command);

        return createSubscriptionResult.MatchFirst(
            subscription => Ok(new SubscriptionResponse
                (subscription.Id, request.SubscriptionType)),
            error => Problem(error.Description)
        );
    }
    [HttpGet]
    public async Task<IActionResult> GetSubscriptionById(Guid subscriptionId)
    {
        var command = new GetSubscriptionQuery(subscriptionId);
        var subscriptionResult = await requestSender.Send(command);

        return subscriptionResult.MatchFirst(
            subscription => Ok(new SubscriptionResponse
                (subscription.Id, 
                    Enum.Parse<SubscriptionType>(subscription.Type.Name))),
            error => Problem(error.Description)
        );
    }
}