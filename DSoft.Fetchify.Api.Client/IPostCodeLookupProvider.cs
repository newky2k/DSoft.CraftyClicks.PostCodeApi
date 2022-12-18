using DSoft.Fetchify.Api.Client.Enums;
using DSoft.Fetchify.Api.Client.Models;
using System;
using System.Threading.Tasks;

namespace DSoft.Fetchify.Api.Client
{
	public interface IPostCodeLookupProvider : IDisposable
	{
		/// <summary>
		/// Get the addresses associated with a post code address
		/// </summary>
		/// <param name="postCode"></param>
		/// <param name="mode"></param>
		/// <returns></returns>
		Task<QueryResult> GetPostCodeAddressesAsync(string postCode, AddressMode mode, bool includeGeocode = false);
	}
}
