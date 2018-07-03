using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home.Server.Common
{
    public class DataResult<T>
    {
        public T Result { get; set; }
        public Exception Error { get; set; }
    }
}
