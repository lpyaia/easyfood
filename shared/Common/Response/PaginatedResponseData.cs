using Easyfood.Shared.Common.Request;

namespace Easyfood.Shared.Common.Response
{
    public class PaginatedResponseData<T>
    {
        public T Data { get; private set; }

        public int TotalItems { get; private set; }

        public int TotalPages { get; private set; }

        public int CurrentPage { get; private set; }

        public int PageSize => PaginationRequest.PageSize;

        internal PaginatedResponseData(T data, int totalItems, int currentPage)
        {
            Data = data;
            TotalItems = totalItems;
            TotalPages = (int)Math.Ceiling((decimal)(totalItems / PageSize));
            CurrentPage = currentPage;
        }
    }

    public static class PaginatedResponseData
    {
        public static PaginatedResponseData<T> Response<T>(T data, int totalItems, int currentPage)
        {
            return new PaginatedResponseData<T>(data, totalItems, currentPage);
        }
    }
}