using MagicVillaUtility;
using MagicVillaWeb.Interfaces;
using MagicVillaWeb.Models;
using MagicVillaWeb.Models.Dto;

namespace MagicVillaWeb.Services
{
    public class VillaNumberService : BaseService, IVillaNumberService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string villaUrl;
        public VillaNumberService(IHttpClientFactory clientFactory, IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }

        public Task<T> CreateAsync<T>(VillaNumberCreateDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.POST,
                Data = dto,
                Url = $"{villaUrl}/api/VillaNumberAPI"
            });
        }

        public Task<T> DeleteAsync<T>(int villaNo)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.DELETE,
                Url = $"{villaUrl}/api/VillaNumberAPI/{villaNo}"
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = $"{villaUrl}/api/VillaNumberAPI"
            });
        }

        public Task<T> GetAsync<T>(int villaNo)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.GET,
                Url = $"{villaUrl}/api/VillaNumberAPI/{villaNo}"
            });
        }

        public Task<T> UpdateAsync<T>(VillaNumberUpdateDto dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = StaticDetails.ApiType.PUT,
                Data = dto,
                Url = $"{villaUrl}/api/VillaNumberAPI/{dto.VillaNo}"
            });
        }
    }
}
