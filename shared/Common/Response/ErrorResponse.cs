namespace Easyfood.Shared.Common.Response
{
    public class ErrorResponse
    {
        public string Type { get; private set; }

        public string Error { get; private set; }

        public string Detail { get; private set; }

        public string Instance { get; private set; }

        public string TraceId { get; private set; }

        public ErrorResponse(string type, string error, string detail, string instance, string traceId)
        {
            Type = type;
            Error = error;
            Detail = detail;
            Instance = instance;
            TraceId = traceId;
        }

        public ErrorResponse(string error, string instance, string traceId)
        {
            Type = Detail = Error = error;
            Instance = instance;
            TraceId = traceId;
        }
    }
}