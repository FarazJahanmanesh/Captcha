using Captcha.Api.Models;
using Captcha.Api.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Captcha.Api.Controller.V1
{
    public class CaptchaController : ControllerBase
    {
        public async Task<IActionResult> GetCaptcha()
        {
            var response = new ActionResponse<GetCaptchaResponse>();

            return Ok();
        }
    }
}
