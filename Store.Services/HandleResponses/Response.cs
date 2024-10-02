namespace Store.Services.HandleResponses
{
    public class Response
    {
        public Response(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessageForStatusCode(int statusCode)
            => StatusCode switch
            {
                100 => "Continue",
                101 => "Switching Protocols",
                200 => "OK",
                201 => "Created",
                202 => "Accepted",
                204 => "No Content",
                400 => "Bad Request",
                302 => "Found",
                404 => "Not Found",
                500 => "Internal Server Error",
                429 => "Too Many Requests",
                _ => "UnKnown Status"
            };

    }
}
