namespace E_learning.ApiRes
{
    public class ApiException : ApiErrorRes
    {
        public ApiException(int statusCode, string errorMessage = null, string details = null) : base(statusCode, errorMessage)
        {
            Details = details;
        }
        public string Details { get; set; } 
    }
}
