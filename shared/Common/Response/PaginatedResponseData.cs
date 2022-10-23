namespace Easyfood.Shared.Common.Response
{
    public class PaginatedResponseData<T>
    {
        public T Data { get; private set; }

        public int TotalItems { get; private set; }

        public int TotalPages { get; private set; }

        public int CurrentPage { get; private set; }

        public PaginatedResponseData(T data, int totalItems, int totalPages, int currentPage)
        {
            Data = data;
            TotalItems = totalItems;
            TotalPages = totalPages;
            CurrentPage = currentPage;
        }
    }
}