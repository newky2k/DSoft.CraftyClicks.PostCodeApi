using DSoft.Fetchify.Api.Client.Models.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DSoft.Fetchify.Api.Client
{
	public static class PostCodeLookupProviderFactory
	{
		private static HttpClient httpClient = new HttpClient();

		public static IPostCodeLookupProvider Create()
		{
			return new PostCodeLookupProvider(httpClient);
		}
	}
}
