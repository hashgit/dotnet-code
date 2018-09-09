using dotnet_code_challenge.Providers.Caulfield;
using dotnet_code_challenge.Providers.Models;
using dotnet_code_challenge.Providers.Wolferhampton;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_code_challenge.Providers
{
    public class DataFeedProvider
    {
        private IDictionary<FeedProviderType, IDataFeed> providers = new Dictionary<FeedProviderType, IDataFeed>()
        {
            { FeedProviderType.Wolferhampton, new WolferhamptonFeed() },
            { FeedProviderType.Caulfield, new CaulfieldFeed() }
        };

        public async Task<FixtureResponse<Models.Participant>> GetParticipants(FeedProviderType type)
        {
            if (providers.TryGetValue(type, out IDataFeed provider))
            {
                return await provider.GetParticipants();
            }

            throw new System.ArgumentException("Value not recognised", "type");
        }
    }
}
