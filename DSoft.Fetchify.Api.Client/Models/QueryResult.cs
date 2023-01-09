using DSoft.Fetchify.Api.Client.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DSoft.Fetchify.Api.Client.Models
{
	/// <summary>
	/// Class QueryResult.
	/// </summary>
	public class QueryResult
	{
		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>The status.</value>
		public QueryStatus Status { get; set; }

		/// <summary>
		/// Gets or sets the addresses.
		/// </summary>
		/// <value>The addresses.</value>
		public List<Address> Addresses { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="QueryResult"/> class.
		/// </summary>
		public QueryResult()
		{
			Status = QueryStatus.OK;
			Addresses = new List<Address>();
		}
	}
}
