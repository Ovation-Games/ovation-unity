using System.Collections.Generic;
using System.Threading.Tasks;
using Ovation.Models;

namespace Ovation.Api
{
    internal class AchievementService
    {
        private readonly OvationApiClient _client;

        internal AchievementService(OvationApiClient client)
        {
            _client = client;
        }

        internal async Task<ApiResult<List<Achievement>>> GetAchievementsAsync()
        {
            return await _client.GetAllPagesAsync<Achievement>("/achievements");
        }

        internal async Task<ApiResult<Achievement>> GetAchievementAsync(string slug)
        {
            return await _client.GetAsync<Achievement>($"/achievements/{slug}");
        }
    }
}
