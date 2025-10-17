namespace NbaTracker.Common;

public static class ExceptionAssitance
{
    public static IEnumerable<Exception> GetAllExceptions(this Exception exception)
    {
        var innerException = exception;
        do
        {
            yield return innerException;
            innerException = innerException.InnerException;
        }
        while (innerException != null);
    }
}
