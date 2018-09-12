using DSoft.CraftyClicks.PostCodeApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftyClicksExampleApp
{
    static class Program
    {
        //static List<ClsAddress> addressList = new List<ClsAddress>();
        //static CraftyClicksRapidAddressLoookup _mCraftyClicks = new CraftyClicksRapidAddressLoookup();

        
        static async Task Main(string[] args)
        {

            Console.Write("Please enter the postcode:");

            string _inputPostCode = Console.ReadLine().Trim();

            var options = PostCodeLookupProviderOptions.Defaults;

            using (var lookupProvider = new PostCodeLookupProvider(options))
            {
                var result = await lookupProvider.GetPostCodeAddressesAsync(_inputPostCode, AddressMode.Rapid);

                if (result.Status != QueryStatus.OK)
                {
                    Console.Write("Error " + result.Status.ToString());
                }
                else
                {
                    foreach (var node in result.Addresses)
                    {
                        Console.Write("Address Line 1 " + node.AddressLine1 + Environment.NewLine);
                        Console.Write("Address Line 2 " + node.AddressLine2 + Environment.NewLine);
                        Console.Write("County " + node.County + Environment.NewLine);
                        Console.Write("Post Code " + node.PostCode + Environment.NewLine);

                    }
                }

            }

            Console.Read();
            

        }
}
}
