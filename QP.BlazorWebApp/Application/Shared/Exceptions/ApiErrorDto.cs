namespace QP.BlazorWebApp.Application.Shared.Exceptions
{
    public class ApiErrorDto
    {
        public string Code { get; set; } = "";
        public int Status { get; set; }
        public string Message { get; set; } = "";
    }

}
