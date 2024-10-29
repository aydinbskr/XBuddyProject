using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBuddy.Domain.Entities
{
    public class FollowEntity:BaseEntity<Guid>
    {
        public Guid FollowingUserId { get; set; }
        public Guid FollowerUserId { get; set; }
        
        public virtual UserEntity FollowerUser { get; set; }
        public virtual UserEntity FollowingUser { get; set; }
    }
}
