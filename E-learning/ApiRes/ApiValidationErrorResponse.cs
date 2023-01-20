namespace E_learning.ApiRes
{
    public class ApiValidationErrorResponse : ApiErrorRes
    {
        public ApiValidationErrorResponse() : base(400)
        {
        }
        public IEnumerable<string> Errors { get; set; } 
    }
}
