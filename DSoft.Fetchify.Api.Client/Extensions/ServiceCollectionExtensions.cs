using DSoft.Fetchify.Api.Client;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection AddFetchifyProviders(this IServiceCollection services)
		{
			services.TryAddScoped<IPostCodeLookupProvider, PostCodeLookupProvider>();

			return services;
		}
	}
}
