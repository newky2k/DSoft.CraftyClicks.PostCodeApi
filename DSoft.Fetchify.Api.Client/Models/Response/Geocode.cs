using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DSoft.Fetchify.Api.Client.Models.Response
{
	internal class Geocode
	{
		[JsonPropertyName("lat")]
		public double Latitude { get; set; }

		[JsonPropertyName("lng")]
		public double Longitude { get; set; }

		[JsonPropertyName("os")]
		public OrdnanceSurvey OrdnanceSurvey { get; set; }
	}
}
