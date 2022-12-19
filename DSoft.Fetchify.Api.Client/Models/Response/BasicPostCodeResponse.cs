using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DSoft.Fetchify.Api.Client.Models.Response
{
	internal class BasicPostCodeResponse : ErrorableResponse
	{
		[JsonPropertyName("thoroughfares")]
		public List<Thoroughfare> Thoroughfares { get; set; }

		[JsonPropertyName("thoroughfare_count")]
		public int ThoroughfareCount { get; set; }

		[JsonPropertyName("postal_county")]
		public string PostalCounty { get; set; }

		[JsonPropertyName("traditional_county")]
		public string TraditionalCounty { get; set; }

		[JsonPropertyName("town")]
		public string Town { get; set; }

		[JsonPropertyName("postcode")]
		public string Postcode { get; set; }

		[JsonPropertyName("geocode")]
		public Geocode Geocode { get; set; }
	}
}
