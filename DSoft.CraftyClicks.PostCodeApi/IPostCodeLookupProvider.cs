using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DSoft.CraftyClicks.PostCodeApi
{
	public interface IPostCodeLookupProvider
	{
		/// <summary>
		/// Get the addresses associated with a post code address
		/// </summary>
		/// <param name="postCode"></param>
		/// <param name="mode"></param>
		/// <returns></returns>
		Task<QueryResult> GetPostCodeAddressesAsync(string postCode, AddressMode mode);
	}
}
