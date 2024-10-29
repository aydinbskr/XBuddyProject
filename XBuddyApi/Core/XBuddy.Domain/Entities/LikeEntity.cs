using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBuddy.Domain.Entities
{
    public class LikeEntity : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public Guid TweetId { get; set; }

        public virtual UserEntity User { get; set; }
        public virtual TweetEntity Tweet { get; set; }
    }
}
