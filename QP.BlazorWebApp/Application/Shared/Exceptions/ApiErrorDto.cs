using System.Text.Json.Serialization;

namespace QP.BlazorWebApp.Application.Shared.Exceptions
{
    public class ApiErrorDto
    {
        [JsonPropertyName("errorType")]
        public string ErrorType { get; set; } = "";

        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; } = "";
    }

}
