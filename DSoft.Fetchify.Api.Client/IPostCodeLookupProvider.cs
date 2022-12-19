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
		/// <param name="postCode">Post code to query</param>
		/// <param name="mode">Basic or Rapid address query</param>
		/// <param name="apiKey">Fetchify Api key</param>
		/// <param name="includeGeocode">(Optional) Should the Latitude and Longitude co-ordinates be returned</param>
		/// <returns></returns>
		Task<QueryResult> GetPostCodeAddressesAsync(string postCode, AddressMode mode, string apiKey, bool includeGeocode = false);
	}
}
