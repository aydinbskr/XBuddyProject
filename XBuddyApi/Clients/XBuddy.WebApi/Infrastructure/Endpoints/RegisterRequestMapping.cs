using XBuddy.WebApi.Infrastructure.Endpoints.RequestHandlers;

namespace XBuddy.WebApi.Infrastructure.Endpoints
{

    public static class RegisterRequestMapping
    {

        public static void RegisterMappings(this WebApplication app)
        {
            FeedEndpoints.RegisterFeedMappings(app);
        }
    }
}
