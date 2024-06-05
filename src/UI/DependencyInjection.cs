using Assignment.Application.Common.Interfaces;
using Assignment.UI.Features.PopupServices;
using Assignment.UI.Features.TodoManagements;
using Assignment.UI.Features.WeatherForecasts;
using Caliburn.Micro;
using Microsoft.Extensions.DependencyInjection;

namespace Assignment.UI;

public static class DependencyInjection
{
    public static IServiceCollection AddUIServices(this IServiceCollection services)
    {
        return services.AddTransient<IUser, CurrentUser>()
            .AddTransient<IWindowManager, WindowManager>()
            .AddTransient<MainViewModel>()
            .AddTransient<TodoManagmentViewModel>()
            .AddTransient<WeatherForecastViewModel>()
            .AddSingleton<IDialogService, DialogService>()
            .AddTransient<MessageDialogViewModel>();
    }
}
