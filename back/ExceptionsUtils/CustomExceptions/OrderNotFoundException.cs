namespace OrderTest.ExceptionsUtils.CustomExceptions
{
    public class OrderNotFoundException(int status, string message) : BaseException(status, message)
    {
    }
}
