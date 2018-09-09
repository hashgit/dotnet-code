using dotnet_code_challenge.Providers.Caulfield;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class CaulfieldFeedTests
    {
        [Fact]
        public async void CanReadXml()
        {
            var provider = new CaulfieldFeed();
            var response = await provider.GetParticipants();

            Assert.True(response.IsValid);
            Assert.Equal(2, response.Data.Count);
        }
    }
}
