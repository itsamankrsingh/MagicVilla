using MagicVillaWeb.Models;

namespace MagicVillaWeb.Interfaces
{
    public interface IBaseService
    {
        APIResponse response { get; set; }
        Task<T> SendAsync<T>(APIRequest request);
    }
}
