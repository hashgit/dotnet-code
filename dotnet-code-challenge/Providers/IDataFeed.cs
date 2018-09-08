using dotnet_code_challenge.Providers.Models;

namespace dotnet_code_challenge.Providers
{
    public interface IDataFeed
    {
        FixtureResponse<Participant> GetParticipants();
    }
}
