using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DSoft.Fetchify.Api.Client.Models.Response
{
	internal abstract class ErrorableResponse
	{
		[JsonPropertyName("error_code")]
		public string ErrorCode { get; set; }

		[JsonPropertyName("error_msg")]
		public string ErrorMesssge { get; set; }
	}
}
