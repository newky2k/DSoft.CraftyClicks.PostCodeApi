using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DSoft.Fetchify.Api.Client.Models.Response
{
	internal class RapidPostCodeResponse : ErrorableResponse
	{
		[JsonPropertyName("delivery_points")]
		public List<DeliveryPoint> DeliveryPoints { get; set; }

		[JsonPropertyName("delivery_point_count")]
		public int DeliveryPointCount { get; set; }

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
