namespace Captcha.Api.Models;

public enum ResponseStateEnum
{
    RRKBUG = -2,
    NOTFOUND = -1,
    FAILED = 0,
    SUCCESS = 1,
    NOTAUTHORIZED = 2
}
