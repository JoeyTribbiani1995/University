using System.IO;
using Microsoft.AspNetCore.Hosting;
using Autofac.Extensions.DependencyInjection;

namespace University.API
{

#pragma warning disable CS1591
    public class Program
    {
        public static void Main(string[] args)
        {
            // ASP.NET Core 1.1 - 2.0:
            // The ConfigureServices call here allows for
            // ConfigureContainer to be supported in Startup with
            // a strongly-typed ContainerBuilder.
            // AddAutofac() is a convenience method for
            // services.AddSingleton<IServiceProviderFactory<ContainerBuilder>>(new AutofacServiceProviderFactory())
            var host = new WebHostBuilder()
                .UseKestrel()
                .ConfigureServices(services => services.AddAutofac())
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
#pragma warning restore CS1591
}
