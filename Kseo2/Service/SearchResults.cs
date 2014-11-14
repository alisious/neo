using Kseo2.Model;
using System;
using System.Collections.Generic;

namespace Kseo2.Service
{
    //powinno być: internal
    public class SearchResult<T> where T :class
    {
        public int ResultsCounter { get; internal set; }
        public IList<T> Results { get; internal set; }

        public SearchResult()
        {
            Results = new List<T>();
            ResultsCounter = -1;
        }
    }

    public class PersonSearchResult : SearchResult<Person> { }
    

}
