using DSoft.Fetchify.Api.Client;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        public static ServiceProvider Provider { get; private set; }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            var services = new ServiceCollection();

            services.AddFetchifyProviders();
            //services.AddHttpClient();

            Provider = services.BuildServiceProvider();

        }

        [TestMethod]
        public void TestDI()
        {
            var service = Provider.GetRequiredService<IPostCodeLookupProvider>();
        }
    }
}