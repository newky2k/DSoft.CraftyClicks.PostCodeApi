using DSoft.Fetchify.Api.Client.Enums;
using DSoft.Fetchify.Api.Client.Models;
using DSoft.Fetchify.Api.Client.Models.Options;
using DSoft.Fetchify.Api.Client.Models.Response;
using Microsoft.Extensions.Options;
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
		private PostCodeLookupProviderOptions _options;
		#endregion

		#region Constructors


		public PostCodeLookupProvider(PostCodeLookupProviderOptions options, HttpClient httpClient)
		{
			_options = options;
			_httpClient = httpClient;
		}

		public PostCodeLookupProvider(IOptions<PostCodeLookupProviderOptions> options)
		{
			_options = options.Value;
		}

		#endregion

		#region Public Methods
		public async Task<QueryResult> GetPostCodeAddressesAsync(string postCode, AddressMode mode, bool includeGeocode = false)
		{
			var result = new QueryResult();

			var urlBase = (mode == AddressMode.Basic) ? _options.BasicApiUrl : _options.RapidApiUrl;

			var url = $"{urlBase}?postcode={postCode}&response=data_formatted&key={_options.ApiKey}";

			if (includeGeocode)
				url += "&include_geocode=true";

			var jStream = await GetResponseAsync(url);

			if (jStream != null)
			{
				switch (mode)
				{
					case AddressMode.Rapid:
						{
							var response = await JsonSerializer.DeserializeAsync<RapidPostCodeResponse>(jStream);

							if (!string.IsNullOrWhiteSpace(response.ErrorCode))
							{
								switch (response.ErrorCode)
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
							}
							else if (response.DeliveryPoints.Any())
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
										Town = response.Town
									};

									if (response.Geocode != null)
									{
										address.GeoLocation = new GeoLocation()
										{
											Longitude = response.Geocode.Longitude,
											Latitude = response.Geocode.Latitude,
										};

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
							var response = await JsonSerializer.DeserializeAsync<BasicPostCodeResponse>(jStream);

							if (!string.IsNullOrWhiteSpace(response.ErrorCode))
							{
								switch (response.ErrorCode)
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
							}
							else if (response.Thoroughfares.Any())
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
										Town = response.Town
									};

									if (response.Geocode != null)
									{
										address.GeoLocation = new GeoLocation()
										{
											Longitude = response.Geocode.Longitude,
											Latitude = response.Geocode.Latitude,
										};

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

		#endregion



	}
}
