using System.Net;

namespace TatlaCas.Asp.Util.FormsAttributes;

public class PostResult
{
    public string Message { get; set; }
    public HttpStatusCode Status { get; set; }
}