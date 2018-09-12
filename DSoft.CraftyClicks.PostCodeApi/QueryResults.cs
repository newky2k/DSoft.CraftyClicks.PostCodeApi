using System;
using System.Collections.Generic;
using System.Text;

namespace DSoft.CraftyClicks.PostCodeApi
{
    public class QueryResult
    {
        public QueryStatus Status { get; set; }

        public List<ClsAddress> Addresses { get; set; }

        public QueryResult()
        {
            Addresses = new List<ClsAddress>();
        }
    }
}
