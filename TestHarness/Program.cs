using DSoft.Fetchify.Api.Client;
using DSoft.Fetchify.Api.Client.Enums;
using DSoft.Fetchify.Api.Client.Models.Options;

namespace TestHarness
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			Console.Write("Please enter the postcode:");

			//string _inputPostCode = Console.ReadLine().Trim();

			string _inputPostCode = "AA11AB";

			using (var lookupProvider = PostCodeLookupProviderFactory.Create())
			{
				var result = await lookupProvider.GetPostCodeAddressesAsync(_inputPostCode, AddressMode.Rapid, null, true);

				if (result.Status != QueryStatus.OK)
				{
					Console.Write("Error " + result.Status.ToString());
				}
				else
				{
					foreach (var node in result.Addresses)
					{
						Console.Write("Line 1: " + node.Line1 + Environment.NewLine);
						Console.Write("Line 2: " + node.Line2 + Environment.NewLine);
						Console.Write("Line 3: " + node.Line3 + Environment.NewLine);
						Console.Write("Town: " + node.Town + Environment.NewLine);
						Console.Write("County: " + node.County + Environment.NewLine);
						Console.Write("Post Code: " + node.PostCode + Environment.NewLine);

					}
				}

			}

			Console.Read();
		}
	}
}