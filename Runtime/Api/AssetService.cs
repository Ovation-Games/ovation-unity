using System.Threading.Tasks;
using Ovation.Models;

namespace Ovation.Api
{
    internal class AssetService
    {
        private readonly OvationApiClient _client;

        internal AssetService(OvationApiClient client)
        {
            _client = client;
        }

        internal async Task<ApiResult<Asset>> GetAssetAsync(string assetId)
        {
            return await _client.GetAsync<Asset>($"/assets/{assetId}");
        }
    }
}
