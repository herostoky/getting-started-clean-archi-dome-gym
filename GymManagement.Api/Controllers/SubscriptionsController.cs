using GymManagement.Application.Services;
using GymManagement.Application.Subscriptions.Commands.CreateSubscription;
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
            subscriptionId => Ok(new SubscriptionResponse
                (subscriptionId, request.SubscriptionType)),
            error => Problem(error.Description)
        );
    }
}