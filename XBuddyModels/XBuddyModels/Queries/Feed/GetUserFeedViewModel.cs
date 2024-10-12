using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBuddyModels.Queries.Feed
{

    public record GetUserFeedViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public int LikesCount { get; set; }
        public bool IsLiked { get; set; }
        public int ViewCount { get; set; }

        public DateTime CreatedAt { get; set; }
    }
   
}
