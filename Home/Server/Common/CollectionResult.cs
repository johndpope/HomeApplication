using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home.Server.Common
{
    public class CollectionResult<T>
    {
        public List<T> Results { get; set; }
        public Exception Error { get; set; }
    }
}
