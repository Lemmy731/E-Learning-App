namespace E_learning
{
    public class ApiErrorRes
    {
        public ApiErrorRes(int statusCode, string errorMessage = null)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage ?? DefaultErrorMessage(statusCode);
        }

        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; } 
        private string DefaultErrorMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "you have made a bad request",
                401 => "you are not authorized",
                404 => "resource not found",
                500 => "internal server error",
                _ => "an error as occurred"
            };

        }
    }
}
