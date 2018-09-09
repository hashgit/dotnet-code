using dotnet_code_challenge.Providers.Models;
using System.Threading.Tasks;

namespace dotnet_code_challenge.Providers
{
    public interface IDataFeed
    {
        Task<FixtureResponse<Participant>> GetParticipants();
    }
}
