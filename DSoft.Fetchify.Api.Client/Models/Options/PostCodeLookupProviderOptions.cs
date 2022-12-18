using System;
using System.Collections.Generic;
using System.Text;

namespace DSoft.Fetchify.Api.Client.Models.Options
{
	public class PostCodeLookupProviderOptions
	{
		public string ApiKey { get; set; }

		public string BasicApiUrl { get; set; }

		public string RapidApiUrl { get; set; }


		public static PostCodeLookupProviderOptions Defaults
		{
			get
			{
				return new PostCodeLookupProviderOptions()
				{
					BasicApiUrl = "http://pcls1.craftyclicks.co.uk/json/basicaddress",
					RapidApiUrl = "http://pcls1.craftyclicks.co.uk/json/rapidaddress",
				};
			}
		}
	}
}
