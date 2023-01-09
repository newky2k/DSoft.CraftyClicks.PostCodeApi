using DSoft.Fetchify.Api.Client.Models.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DSoft.Fetchify.Api.Client
{
	/// <summary>
	/// Factory class for creating instances of the Fetchify providers
	/// </summary>
	public static class FetchifyProviderFactory
	{
		private static HttpClient httpClient = new HttpClient();

		/// <summary>
		/// Creates an instance of the post code lookup provider.
		/// </summary>
		/// <returns>IPostCodeLookupProvider.</returns>
		public static IPostCodeLookupProvider CreatePostCodeLookupProvider()
		{
			return new PostCodeLookupProvider(httpClient);
		}
	}
}
