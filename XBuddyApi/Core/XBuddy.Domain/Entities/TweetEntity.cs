using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBuddy.Domain.Entities
{
    public class TweetEntity : BaseEntity<Guid>
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }

        public virtual ICollection<LikeEntity> Likes { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
