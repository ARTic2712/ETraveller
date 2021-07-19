namespace ETraveller.Common.Models
{
    public class ProviderResult<T>
    {
        public bool IsSuccess { get;}
        public string ErrorMessage { get; }
        public T Data { get; set; }

        public ProviderResult(bool IsSuccess, T Data, string ErrorMessage)
        {
            this.IsSuccess = IsSuccess;
            this.Data = Data;
            this.ErrorMessage = ErrorMessage;
        }
    }
}
