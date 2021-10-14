using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ThmsRynr.CatFact
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(s =>
                {
                    s.AddSingleton<ICatFactService, CatFactService>();
                })
                .Build();

            host.Run();
        }
    }
}