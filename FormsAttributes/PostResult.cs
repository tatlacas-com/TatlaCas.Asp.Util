using System.Net;

namespace TatlaCas.Asp.Utils.FormsAttributes
{
    public class PostResult
    {
        public string Message { get; set; }
        public HttpStatusCode Status { get; set; }
    }
    
}