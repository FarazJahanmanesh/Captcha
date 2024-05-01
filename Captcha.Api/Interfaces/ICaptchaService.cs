namespace Captcha.Api.Interfaces;

public interface ICaptchaService
{
    string GenerateCaptcha(string captchaStr);
}
