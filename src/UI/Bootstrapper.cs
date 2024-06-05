using System.IO;
using System.Reflection;
using System.Windows;
using Assignment.Infrastructure.Data.Extensions;
using Caliburn.Micro;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment.UI;

internal class Bootstrapper : BootstrapperBase
{
    public static IServiceProvider ServiceProvider => _serviceProvider.Value;
    private static readonly Lazy<IServiceProvider> _serviceProvider = new(CreateServiceProvider);

    public Bootstrapper()
    {
        Initialize();
    }

    //protected override async void Configure()
    //{
    //    base.Configure();
    //    await ServiceProvider.InitialiseDatabaseAsync();
    //}

    protected override async void OnStartup(object sender, StartupEventArgs e)
    {
        await ServiceProvider.InitialiseDatabaseAsync();
        await DisplayRootViewForAsync<MainViewModel>();
    }

    protected override object GetInstance(Type service, string key)
    {
        var instance = ServiceProvider.GetService(service);
        instance ??= base.GetInstance(service, key);
        return instance;
    }

    protected override IEnumerable<Assembly> SelectAssemblies()
    {
        yield return Assembly.GetExecutingAssembly();
    }

    private static IServiceProvider CreateServiceProvider()
    {
        var config = CreateConfiguration();
        return new ServiceCollection()
           .AddUIServices()
           .AddApplicationServices()
           .AddInfrastructureServices(config)
           .BuildServiceProvider();
    }

    private static IConfigurationRoot CreateConfiguration()
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
            .Build();
    }
}
