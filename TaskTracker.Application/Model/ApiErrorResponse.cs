namespace TaskTracker.API.Model
{
    public class ApiErrorResponse
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;

    }
}
