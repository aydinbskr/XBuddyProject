using Mediator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBuddy.Application.Infrastructure.Models.MultiTenant;
using XBuddy.Application.Services;
using XBuddy.Infra.SqlServer.Context;
using XBuddyModels.Queries.Feed;

namespace XBuddy.Application.Features.Queries
{

    public class GetUserFeedQuery : IRequest<List<GetUserFeedViewModel>>, IMultiTenant
    {

        public string TenantId { get; set; }
    }
    public class GetUserFeedQueryHandler : IRequestHandler<GetUserFeedQuery, List<GetUserFeedViewModel>>
    {
        private readonly XBuddyDbContext xBuddyDbContext;
        private readonly ITenantMappingService tenantMappingService;

        public GetUserFeedQueryHandler(XBuddyDbContext xBuddyDbContext, ITenantMappingService tenantMappingService)
        {
            this.xBuddyDbContext = xBuddyDbContext;
            this.tenantMappingService = tenantMappingService;
        }

        public async ValueTask<List<GetUserFeedViewModel>> Handle(GetUserFeedQuery request, CancellationToken cancellationToken)
        {
            var tenantUserId = tenantMappingService.GetUserByTenantId(request.TenantId);

            var feed = await xBuddyDbContext.Follows
            .Where(f => f.FollowerUserId == tenantUserId)
            .SelectMany(i => i.FollowingUser.Tweets)
            .OrderBy(i => i.CreatedDate)
            .Select(t => new GetUserFeedViewModel
            {
                Id = t.Id,
                Content = t.Content,
                UserId = t.UserId,
                UserName = t.User.UserName,
                LikesCount = t.Likes.Count,
                IsLiked = t.Likes.Any(l => l.UserId == tenantUserId),
                CreatedAt= t.CreatedDate,
                ViewCount = t.ViewCount
            }).ToListAsync();

            return feed;
        }
    } 
}
