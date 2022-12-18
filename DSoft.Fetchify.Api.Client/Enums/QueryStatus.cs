using System;
using System.Collections.Generic;
using System.Text;

namespace DSoft.Fetchify.Api.Client.Enums
{
	public enum QueryStatus
	{
		Unknown,
		PostCodeNotFound,
		InvalidPostCodeFormat,
		DemoLimitExceeded,
		InvalidOrNoAccessToken,
		AccountCrediteAllowanceExceeded,
		AccessDeniedDueToAccessRules,
		AccessDeniedAccountSuspended,
		InternalServerError,
		OK,
	}
}
