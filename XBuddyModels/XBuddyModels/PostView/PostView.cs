using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBuddyModels.PostView
{
    public record PostView(Guid PostId, Guid? UserId);
}
