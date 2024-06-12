using System.Net;

namespace IdentityWebAPI.Models
{
    public class ServiceResponse
    {
        public string? ServiceResponseMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccessStatusCode => (int)StatusCode >= 200 && (int)StatusCode < 300;
        public Dictionary<string, string>? Errors { get; set; }

        public ServiceResponse(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
        public ServiceResponse(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            ServiceResponseMessage = message;
        }
    }

    public class ServiceResponse<T> : ServiceResponse
    {
        public ServiceResponse(HttpStatusCode statusCode) : base(statusCode)
        {

        }
        public ServiceResponse(HttpStatusCode statusCode, string message) : base(statusCode, message)
        {

        }

        public T? Data { get; set; }
    }
}
