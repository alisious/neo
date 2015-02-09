using Kseo2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kseo2.BusinessLayer
{
    public class SearchResult<T> where T :Entity
    {
        public int ResultsCounter { get; internal set; }
        public IList<T> Results { get; internal set; }

        public SearchResult()
        {
            Results = new List<T>();
            ResultsCounter = -1;
        }
    }
}
