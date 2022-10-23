using System.Text.Json.Serialization;

namespace Easyfood.Shared.Common.Request
{
    public class PaginationRequest
    {
        [JsonPropertyName("_page")]
        public int Page { get; set; } = 0;
    }
}