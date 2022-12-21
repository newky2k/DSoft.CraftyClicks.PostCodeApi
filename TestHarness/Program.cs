using DSoft.Fetchify.Api.Client;
using DSoft.Fetchify.Api.Client.Enums;
using DSoft.Fetchify.Api.Client.Models.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System.Mvvm;

namespace TestHarness
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			//create a service host and use DSoft.System.Mvvm.ServiceHost to store the result
			ServiceHost.Host = new HostBuilder()
						.ConfigureServices(ConfigureServices)
						.Build();

			Console.Write("Please enter the postcode:");

			string _inputPostCode = "IP2 8QH";// Console.ReadLine().Trim();

			Console.Write("Enter your API Key/Token:");

			string inputApiKey = "f8e2e-71bdb-8102c-08a62";// Console.ReadLine().Trim();

			//string _inputPostCode = "AA11AB";

			//Example using Factory

			//using (var lookupProvider = FetchifyProviderFactory.CreatePostCodeLookupProvider())
			//{
			//	var result = await lookupProvider.GetPostCodeAddressesAsync(_inputPostCode, AddressMode.Rapid, inputApiKey, true);

			//	if (result.Status != QueryStatus.OK)
			//	{
			//		Console.Write("Error " + result.Status.ToString());
			//	}
			//	else
			//	{
			//		foreach (var node in result.Addresses)
			//		{
			//			Console.Write("Line 1: " + node.Line1 + Environment.NewLine);
			//			Console.Write("Line 2: " + node.Line2 + Environment.NewLine);
			//			Console.Write("Line 3: " + node.Line3 + Environment.NewLine);
			//			Console.Write("Town: " + node.Town + Environment.NewLine);
			//			Console.Write("County: " + node.County + Environment.NewLine);
			//			Console.Write("Post Code: " + node.PostCode + Environment.NewLine);

			//		}
			//	}

			//}

			//Example using DI and Service Host
			var lookupProvider = ServiceHost.GetRequiredService<IPostCodeLookupProvider>();

			var result = await lookupProvider.GetPostCodeAddressesAsync(_inputPostCode, AddressMode.Basic, inputApiKey, true);

			if (result.Status != QueryStatus.OK)
			{
				Console.Write("Error " + result.Status.ToString());
			}
			else
			{
				foreach (var node in result.Addresses)
				{
					Console.Write(node.ToString());

				}
			}

			Console.Read();
		}

		private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
		{
			services.AddFetchifyProviders();
		}
	}
}