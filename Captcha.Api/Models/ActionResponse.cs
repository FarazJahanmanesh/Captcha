namespace Captcha.Api.Models;

public class ActionResponse<T> : IActionResponse
{
    public ActionResponse()
    {
        Errors = new List<string>();
    }
    public int Status { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public ResponseStateEnum State { get; set; }
    public List<string> Errors { get; set; }
}
public class ActionResponse : IActionResponse
{
    public ActionResponse()
    {
        Errors = new List<string>();
    }
    public int Status { get; set; }
    public string Message { get; set; }
    public ResponseStateEnum State { get; set; }
    public List<string> Errors { get; set; }
}
public interface IActionResponse
{
    int Status { get; set; }
    string Message { get; set; }
    ResponseStateEnum State { get; set; }
    List<string> Errors { get; set; }
}