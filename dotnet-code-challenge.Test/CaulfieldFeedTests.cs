using dotnet_code_challenge.Providers.Caulfield;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class CaulfieldFeedTests
    {
        [Fact]
        public void CanReadXml()
        {
            var provider = new CaulfieldFeed();
            var response = provider.GetParticipants();

            Assert.True(response.IsValid);
            Assert.Equal(2, response.Data.Count);
        }
    }
}
