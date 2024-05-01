using Captcha.Api.Interfaces;
using Captcha.Api.Services.Captcha;
namespace Captcha.Api.Extensions;

public static class IOC
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.RegisterCaptcha();
        return services;
    }
    private static IServiceCollection RegisterCaptcha(this IServiceCollection services)
    {
        services.AddScoped<ICaptchaService, CaptchaService>();
        return services;
    }
}
