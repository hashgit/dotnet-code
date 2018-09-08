using dotnet_code_challenge.Providers.Caulfield;
using dotnet_code_challenge.Providers.Models;
using dotnet_code_challenge.Providers.Wolferhampton;
using System.Collections.Generic;

namespace dotnet_code_challenge.Providers
{
    public class DataFeedProvider
    {
        private IDictionary<FeedProviderType, IDataFeed> providers = new Dictionary<FeedProviderType, IDataFeed>()
        {
            { FeedProviderType.Wolferhampton, new WolferhamptonFeed() },
            { FeedProviderType.Caulfield, new CaulfieldFeed() }
        };

        public FixtureResponse<Models.Participant> GetParticipants(FeedProviderType type)
        {
            if (providers.TryGetValue(type, out IDataFeed provider))
            {
                return provider.GetParticipants();
            }

            return FixtureResponse<Models.Participant>.AsErrorResponse($"Unknown provider type {type}");
        }
    }
}
