using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.Model
{
    public class SearchResult<T> where T:class
    {
        public SearchResult()
        {
            Results = new List<T>();
            Counter = 0;
        }
        public List<T> Results { get; set; }
        public int Counter { get; set; }
    }
}
