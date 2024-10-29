using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBuddy.Domain.Entities
{
    public class UserEntity:BaseEntity<Guid>
    {
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public virtual ICollection<FollowEntity> Followers { get; set; }
        public virtual ICollection<FollowEntity> Followings { get; set; }
        public virtual ICollection<LikeEntity> Likes { get; set; }
        public virtual ICollection<TweetEntity> Tweets { get; set; }
        public virtual TenantMappingEntity TenantMapping { get; set; }
    }
}
