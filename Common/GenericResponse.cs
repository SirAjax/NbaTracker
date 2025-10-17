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
            ResponseErrorMessage = msg;

            if (ex != null)
            {
                ResponseException = ex;
                ResponseErrorMessages!.AddRange(ex.GetAllExceptions().Select(x => x.Message).ToList());

                if (string.IsNullOrEmpty(ResponseErrorMessage))
                {
                    ResponseErrorMessage = string.IsNullOrWhiteSpace(ex.Message) ? ex.Message : msg;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(msg))
                    {
                        ResponseErrorMessage = msg;
                        ResponseErrorMessages.Add(msg);
                    }
                }
            }
        }
    }
}
