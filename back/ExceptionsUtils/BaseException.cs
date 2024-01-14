namespace OrderTest.ExceptionsUtils
{
    public class BaseException(int status, string message) : Exception(message)
    {
        public int StatusCode { get; set; } = status;
    }
}
