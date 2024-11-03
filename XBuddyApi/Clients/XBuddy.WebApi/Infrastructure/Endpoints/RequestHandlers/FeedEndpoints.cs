using Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XBuddy.Application.Features.Queries;
using XBuddy.WebApi.Infrastructure.Middleware;
using XBuddyModels.Helpers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace XBuddy.WebApi.Infrastructure.Endpoints.RequestHandlers
{

    public static class FeedEndpoints
    {
        public static void RegisterFeedMappings(this WebApplication app)
        {
            app.MapGet("feed".AdjustTenantRoute(), HandleFeed).AddEndpointFilter<MultiTenantIdEndpointFilter>();
        }


        private static async Task<IResult> HandleFeed(HttpContext context,
            [FromServices] IMediator mediator,
            [AsParameters] GetUserFeedQuery query)
        {
            //query. Tenant Id = multiTenantservice.GetCurrentTenantId();
            var res = await mediator.Send(query);
            return Results.Ok(res);
        }
    }
}
