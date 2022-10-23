namespace Easyfood.Shared.Common.Response
{
    public class ResponseData<T>
    {
        public T Data { get; set; }

        public ResponseData(T data)
        {
            Data = data;
        }
    }
}