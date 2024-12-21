namespace Domain.Models
{
    public class GlobalResponseModel
    {
        public GlobalResponseModel(string requestUrl,
                                   object? data,
                                   string? error,
                                   bool status,
                                   int httpStatusCode,
                                   string? message)
        {
            RequestUrl = requestUrl ?? throw new ArgumentNullException(nameof(requestUrl));
            Error = error;
            IsSuccess = status;
            HttpStatusCode = httpStatusCode;
            Message = message;
            Data = data;
        }

        public string RequestUrl { get; set; }
        public string? Error { get; set; }
        public bool IsSuccess { get; set; }
        public int HttpStatusCode { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
