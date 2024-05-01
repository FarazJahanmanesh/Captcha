using Captcha.Api.Interfaces;
using Captcha.Api.Models;
using Captcha.Api.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Captcha.Api.Controller.V1
{
    public class CaptchaController : BaseController
    {
        private readonly ICaptchaService _captchaService;
        public CaptchaController(ICaptchaService captchaService)
        {
            _captchaService = captchaService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCaptcha()
        {
            var response = new ActionResponse<GetCaptchaResponse>();

            var captchaCode = CaptchaCode().Result;
            var result = _captchaService.GenerateCaptcha(captchaCode);
            if(result == null)
            {
                response.Data = new GetCaptchaResponse(result);
                response.Status = 200;
                response.Message = "captcha generate";
                response.State = ResponseStateEnum.SUCCESS;
                return Ok(response);
            }
            response.Status = 500;
            response.Message = "captcha not generate";
            response.State = ResponseStateEnum.FAILED;
            return BadRequest(response);
        }
        [NonAction]
        public async Task<string> CaptchaCode()
        {
            Random random = new Random();
            string combination = "123456789";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 6; i++)
                captcha.Append(combination[random.Next(combination.Length)]);
            string captchaStr = captcha.ToString();
            return captchaStr;
        }
    }
}
