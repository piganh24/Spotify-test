using System.Net;

namespace Core.Helpers
{
    [Serializable]
    public class HttpExceptionWorker : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public HttpExceptionWorker(HttpStatusCode code)
        {
            StatusCode = code;
        }
        public HttpExceptionWorker(string message, HttpStatusCode code) : base(message)
        {
            StatusCode = code;
        }
        public HttpExceptionWorker(string message, HttpStatusCode code, Exception inner) : base(message, inner)
        {
            StatusCode = code;
        }
        protected HttpExceptionWorker(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}