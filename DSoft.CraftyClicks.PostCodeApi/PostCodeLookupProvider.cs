using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DSoft.CraftyClicks.PostCodeApi
{
    public class PostCodeLookupProvider : IPostCodeLookupProvider, IDisposable
	{
        private PostCodeLookupProviderOptions _options;


        public PostCodeLookupProvider(PostCodeLookupProviderOptions options)
        {
            _options = options;
        }



        public async Task<QueryResult> GetPostCodeAddressesAsync(string postCode, AddressMode mode)
        {
            var result = new QueryResult();

            var urlBase = (mode == AddressMode.Basic) ? _options.BasicApiUrl : _options.RapidApiUrl;

            var url = String.Format(urlBase + "?postcode={0}&response=data_formatted&key={1}", postCode, _options.ApiKey);

            var jsonString = await GetResponseAsync(url);


            var jsonResponseObject = JsonConvert.DeserializeObject<dynamic>(jsonString);


            if (jsonResponseObject != null)
            {
                switch (mode)
                {
                    case AddressMode.Rapid:
                        {
                            if (jsonResponseObject.delivery_points != null)
                            {
                                //If the node list contains address nodes then move on.
                                int i = 0;

                                foreach (var node in jsonResponseObject.delivery_points)
                                {
                                    ClsAddress address = new ClsAddress()
                                    {
                                        AddressID = i,
                                        AddressLine1 = node.line_1,
                                        AddressLine2 = node.line_2,
                                        Department = node.department_name,
                                        Organisation = node.organisation_name,

                                        County = jsonResponseObject.traditional_county,
                                        PostCode = jsonResponseObject.postcode,
                                        Town = jsonResponseObject.town
                                    };

                                    result.Addresses.Add(address);
                                    i++;
                                }
                            }
                            else
                            {
                                foreach (var node in jsonResponseObject)
                                {
                                    // Get the details of the error message and return it the user.
                                    switch ((string)node.Value)
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
                            }

                            
                        }
                        break;
                    case AddressMode.Basic:
                        {
                            if (jsonResponseObject.thoroughfare_count > 0 )
                            {
                                //If the node list contains address nodes then move on.
                                int i = 0;

                                foreach (var node in jsonResponseObject.thoroughfares)
                                {
                                    ClsAddress address = new ClsAddress()
                                    {
                                        AddressID = i,
                                        AddressLine1 = node.line_1,
                                        AddressLine2 = node.line_2,
                                        Department = node.department_name,
                                        Organisation = node.organisation_name,

                                        County = jsonResponseObject.traditional_county,
                                        PostCode = jsonResponseObject.postcode,
                                        Town = jsonResponseObject.town
                                    };

                                    result.Addresses.Add(address);
                                    i++;
                                }
                            }
                            else
                            {
                                foreach (var node in jsonResponseObject)
                                {
                                    // Get the details of the error message and return it the user.
                                    switch ((string)node.Value)
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

        private async Task<String> GetResponseAsync(string url)
        {
            //Complete XML HTTP Request
            var request = WebRequest.Create(url);

            //Complete XML HTTP Response
            var response = await request.GetResponseAsync();

            //Declare and set a stream reader to read the returned XML
            var reader = new StreamReader(response.GetResponseStream());



            string json = reader.ReadToEnd();

            return json;
        }

        public void Dispose()
        {
            
        }


    }
}
