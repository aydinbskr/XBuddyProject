using Mediator;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using XBuddy.Application.Extensions;
using XBuddy.Application.Features.Base;
using XBuddy.Application.Infrastructure.Models.MultiTenant;
using XBuddy.Application.Services;
using XBuddy.Infra.SqlServer.Context;
using XBuddyModels.Constants;
using XBuddyModels.Paging;
using XBuddyModels.Queries.Feed;

namespace XBuddy.Application.Features.Queries
{

    public class GetUserFeedQuery : CacheablePagedQuery<GetUserFeedViewModel>
    {
        public override string CacheKey => Constants.CacheKeys.UserFeed;
    }
    public class GetUserFeedQueryHandler : IRequestHandler<GetUserFeedQuery, PagedResponse<GetUserFeedViewModel>>
    {
        private readonly XBuddyDbContext xBuddyDbContext;
        private readonly ITenantMappingService tenantMappingService;

        public GetUserFeedQueryHandler(XBuddyDbContext xBuddyDbContext, ITenantMappingService tenantMappingService)
        {
            this.xBuddyDbContext = xBuddyDbContext;
            this.tenantMappingService = tenantMappingService;
        }

        public async ValueTask<PagedResponse<GetUserFeedViewModel>> Handle(GetUserFeedQuery request, CancellationToken cancellationToken)
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
                CreatedAt = t.CreatedDate,
                ViewCount = t.ViewCount
            })
            .GetPage(request.PageNumber, request.PageSize);

            return feed;
        }
    } 
}
