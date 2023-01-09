using System;
using System.Collections.Generic;
using System.Text;

namespace DSoft.Fetchify.Api.Client.Enums
{
	/// <summary>
	/// Enum QueryStatus
	/// </summary>
	public enum QueryStatus
	{
		/// <summary>
		/// The unknown
		/// </summary>
		Unknown,
		/// <summary>
		/// The post code not found
		/// </summary>
		PostCodeNotFound,
		/// <summary>
		/// The invalid post code format
		/// </summary>
		InvalidPostCodeFormat,
		/// <summary>
		/// The demo limit exceeded
		/// </summary>
		DemoLimitExceeded,
		/// <summary>
		/// The invalid or no access token
		/// </summary>
		InvalidOrNoAccessToken,
		/// <summary>
		/// The account credite allowance exceeded
		/// </summary>
		AccountCrediteAllowanceExceeded,
		/// <summary>
		/// The access denied due to access rules
		/// </summary>
		AccessDeniedDueToAccessRules,
		/// <summary>
		/// The access denied account suspended
		/// </summary>
		AccessDeniedAccountSuspended,
		/// <summary>
		/// The internal server error
		/// </summary>
		InternalServerError,
		/// <summary>
		/// The ok
		/// </summary>
		OK,
	}
}
