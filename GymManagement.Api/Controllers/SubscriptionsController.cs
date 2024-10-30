using GymManagement.Application.Services;
using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
using GymManagement.Application.Subscriptions.Queries.GetSubscription;
using GymManagement.Contracts.Subscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController(ISender requestSender)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateSubscription(CreateSubscriptionRequest request)
    {
        var command = new CreateSubscriptionCommand(request.SubscriptionType.ToString(), request.AdminId);
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
                    Enum.Parse<SubscriptionType>(subscription.Type.ToString()))),
            error => Problem(error.Description)
        );
    }
}