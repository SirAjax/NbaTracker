namespace NbaTracker.Common
{
    public interface IGenericResponse<T>
    {
        Task SetExceptionAsync(Exception? ex = null, string msg = "");
        void SetException(Exception? ex = null, string msg = "");
    }

    public class GenericResponse<T> : IGenericResponse<T>
    {
        public bool Error { get; set; }
        public Exception? ResponseException { get; set; }
        public string? ResponseErrorMessage { get; set; }
        public List<string> ResponseErrorMessages { get; set; } = new List<string>();
        public T? Value { get; set; }

        public async Task SetExceptionAsync(Exception? ex = null, string msg = "")
        {
            await Task.Run(() => SetException(ex, msg));
        }

        public void SetException(Exception? ex = null, string msg = "")
        {
            Error = true;

            if (ex != null)
            {
                ResponseException = ex;

                if (!string.IsNullOrEmpty(msg))
                {
                    ResponseErrorMessage = ex.Message;

                    if (string.IsNullOrWhiteSpace(msg))
                    {
                        ResponseErrorMessage = msg;
                    }
                }
                else
                {
                    ResponseErrorMessage = msg;
                    ResponseErrorMessages.Add(msg);
                }
            }
        }
    }
}
