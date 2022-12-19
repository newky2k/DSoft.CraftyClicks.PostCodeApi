using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace DSoft.Fetchify.Api.Client.Models.Response
{
	internal class DeliveryPoint
	{
		[JsonPropertyName("organisation_name")]
		public string OrganisationName { get; set; }

		[JsonPropertyName("department_name")]
		public string DepartmentName { get; set; }

		[JsonPropertyName("line_1")]
		public string Line1 { get; set; }

		[JsonPropertyName("line_2")]
		public string Line2 { get; set; }

		[JsonPropertyName("line_3")]
		public string Line3 { get; set; }

		[JsonPropertyName("udprn")]
		public string Udprn { get; set; }

		[JsonPropertyName("dps")]
		public string Dps { get; set; }
	}
}