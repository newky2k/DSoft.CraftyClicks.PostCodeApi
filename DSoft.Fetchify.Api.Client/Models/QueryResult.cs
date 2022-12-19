using DSoft.Fetchify.Api.Client.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSoft.Fetchify.Api.Client.Models
{
	public class QueryResult
	{
		public QueryStatus Status { get; set; }

		public List<Address> Addresses { get; set; }

		public QueryResult()
		{
			Status = QueryStatus.OK;
			Addresses = new List<Address>();
		}
	}
}
