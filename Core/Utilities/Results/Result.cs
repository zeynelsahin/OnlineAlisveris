namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        protected Result(bool success)
        {
            Success = success;
            Message = string.Empty;
        }

        protected Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        public bool Success { get; }
        public string Message { get; } 
    }
}