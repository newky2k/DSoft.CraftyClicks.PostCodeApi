using DSoft.Fetchify.Api.Client;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
	/// <summary>
	/// Class IServiceCollectionExtensions.
	/// </summary>
	public static class IServiceCollectionExtensions
	{
		/// <summary>
		/// Adds the fetchify providers.
		/// </summary>
		/// <param name="services">The services.</param>
		/// <returns>IServiceCollection.</returns>
		public static IServiceCollection AddFetchifyProviders(this IServiceCollection services)
		{
			services.TryAddScoped<IPostCodeLookupProvider, PostCodeLookupProvider>();
			services.AddHttpClient<PostCodeLookupProvider>();


			return services;
		}
	}
}
