using DSoft.Fetchify.Api.Client.Enums;
using DSoft.Fetchify.Api.Client.Models;
using DSoft.Fetchify.Api.Client.Models.Options;
using DSoft.Fetchify.Api.Client.Models.Response;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DSoft.Fetchify.Api.Client
{
	internal class PostCodeLookupProvider : IPostCodeLookupProvider
	{
		#region Fields
		private HttpClient _httpClient;
		private PostCodeLookupProviderOptions _options = PostCodeLookupProviderOptions.Defaults;
		#endregion

		#region Constructors


		public PostCodeLookupProvider(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		#endregion

		#region Public Methods
		public async Task<QueryResult> GetPostCodeAddressesAsync(string postCode, AddressMode mode, string apiKey, bool includeGeocode = false)
		{
			var result = new QueryResult();

			var urlBase = (mode == AddressMode.Basic) ? _options.BasicApiUrl : _options.RapidApiUrl;

			var url = $"{urlBase}?postcode={postCode}&response=data_formatted&key={apiKey}";

			if (includeGeocode)
				url += "&include_geocode=true";

			var sResult = await GetResultAsync(url, mode);

			if (sResult != null)
			{
				if (!string.IsNullOrWhiteSpace(sResult.ErrorCode))
				{
					switch (sResult.ErrorCode)
					{
						case "0001":
							result.Status = QueryStatus.PostCodeNotFound;
							break;
						case "0002":
							result.Status = QueryStatus.InvalidPostCodeFormat;
							break;
						case "7001":
							result.Status = QueryStatus.DemoLimitExceeded;
							break;
						case "8001":
							result.Status = QueryStatus.InvalidOrNoAccessToken;
							break;
						case "8003":
							result.Status = QueryStatus.AccountCrediteAllowanceExceeded;
							break;
						case "8004":
							result.Status = QueryStatus.AccessDeniedDueToAccessRules;
							break;
						case "8005":
							result.Status = QueryStatus.AccessDeniedAccountSuspended;
							break;
						case "9001":
							result.Status = QueryStatus.InternalServerError;
							break;
						default:
							result.Status = QueryStatus.Unknown;
							break;
					}

					return result;
				}

				switch (mode)
				{
					case AddressMode.Rapid:
						{
							var response = sResult as RapidPostCodeResponse;

							if (response.DeliveryPoints.Any())
							{
								//If the node list contains address nodes then move on.
								int i = 0;

								foreach (var node in response.DeliveryPoints)
								{
									var address = new Address()
									{
										AddressID = i,
										Line1 = node.Line1,
										Line2 = node.Line2,
										Line3 = node.Line3,
										Department = node.DepartmentName,
										Organisation = node.OrganisationName,

										County = response.TraditionalCounty,
										PostCode = response.Postcode,
										Town = response.Town,
										Country = "United Kingdom",
									};

									if (response.Geocode != null)
									{
										address.GeoLocation = new GeoLocation()
										{
											Longitude = response.Geocode.Longitude,
											Latitude = response.Geocode.Latitude,
										};

										if (response.Geocode.OrdnanceSurvey != null)
											address.Nation = response.Geocode.OrdnanceSurvey.CountryText;
									}

									result.Addresses.Add(address);
									i++;
								}
							}
							else
							{
								result.Status = QueryStatus.PostCodeNotFound;
							}


						}
						break;
					case AddressMode.Basic:
						{
							var response = sResult as BasicPostCodeResponse;

							if (response.Thoroughfares.Any())
							{
								//If the node list contains address nodes then move on.
								int i = 0;

								foreach (var node in response.Thoroughfares)
								{
									var address = new Address()
									{
										AddressID = i,
										Line1 = node.Line1,
										Line2 = node.Line2,
										Line3 = node.Line3,
										County = response.TraditionalCounty,
										PostCode = response.Postcode,
										Town = response.Town,
										Country = "United Kingdom",
									};

									if (response.Geocode != null)
									{
										address.GeoLocation = new GeoLocation()
										{
											Longitude = response.Geocode.Longitude,
											Latitude = response.Geocode.Latitude,
										};


										if (response.Geocode.OrdnanceSurvey != null)
											address.Nation = response.Geocode.OrdnanceSurvey.CountryText;

									}

									result.Addresses.Add(address);
									i++;
								}
							}
							else
							{
								result.Status = QueryStatus.PostCodeNotFound;
							}
						}
						break;
				}

			}
			else
			{
				result.Status = QueryStatus.Unknown;
			}

			return result;
		}

		public void Dispose()
		{

		}

		#endregion

		#region Private Methods

		private async Task<Stream> GetResponseAsync(string url)
		{
			var response = await _httpClient.GetStreamAsync(url);

			return response;
		}

		private async Task<ErrorableResponse> GetResultAsync(string url, AddressMode mode)
		{
			var jStream = await GetResponseAsync(url);

			if (jStream == null)
				throw new Exception("No result from server");

			ErrorableResponse result;

			if (mode.Equals(AddressMode.Rapid))
				result = await JsonSerializer.DeserializeAsync<RapidPostCodeResponse>(jStream);
			else if (mode.Equals(AddressMode.Basic))
				result = await JsonSerializer.DeserializeAsync<BasicPostCodeResponse>(jStream);
			else
				throw new Exception("Unexpected Address Mode");

			return result;

		}

		#endregion



	}
}
