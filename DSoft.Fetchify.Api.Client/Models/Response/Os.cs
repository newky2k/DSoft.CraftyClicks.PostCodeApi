using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DSoft.Fetchify.Api.Client.Models.Response
{
	internal class OrdnanceSurvey
	{
		[JsonPropertyName("easting")]
		public string Easting { get; set; }

		[JsonPropertyName("northing")]
		public string Northing { get; set; }

		[JsonPropertyName("country_code")]
		public string CountryCode { get; set; }

		[JsonPropertyName("country_text")]
		public string CountryText { get; set; }

		[JsonPropertyName("nhs_regional_ha_code")]
		public string NhsRegionalHaCode { get; set; }

		[JsonPropertyName("nhs_regional_ha_text")]
		public string NhsRegionalHaText { get; set; }

		[JsonPropertyName("nhs_ha_code")]
		public string NhsHaCode { get; set; }

		[JsonPropertyName("nhs_ha_text")]
		public string NhsHaText { get; set; }

		[JsonPropertyName("administrative_county_code")]
		public string AdministrativeCountyCode { get; set; }

		[JsonPropertyName("administrative_county_text")]
		public string AdministrativeCountyText { get; set; }

		[JsonPropertyName("administrative_district_code")]
		public string AdministrativeDistrictCode { get; set; }

		[JsonPropertyName("administrative_district_text")]
		public string AdministrativeDistrictText { get; set; }

		[JsonPropertyName("administrative_ward_code")]
		public string AdministrativeWardCode { get; set; }

		[JsonPropertyName("administrative_ward_text")]
		public string AdministrativeWardText { get; set; }
	}
}
