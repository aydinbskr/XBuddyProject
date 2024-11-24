using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace XBuddyModels.Paging
{

    public class PagedResponse<T>(IList<T> data, Page pageInfo)
    {

        public PagedResponse() : this([], new Page())
        {
        }
        public IList<T> Data { get; set; } = data;
        public Page PageInfo { get; set; } = pageInfo;
    }
}
