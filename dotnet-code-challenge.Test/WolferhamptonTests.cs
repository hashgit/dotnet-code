using dotnet_code_challenge.Providers.Wolferhampton;
using Xunit;

namespace dotnet_code_challenge.Test
{
    public class WolferhamptonFeedTests
    {
        [Fact]
        public void CanReadJson()
        {
            var provider = new WolferhamptonFeed();
            var response = provider.GetParticipants();

            Assert.True(response.IsValid);
            Assert.Equal(2, response.Data.Count);
        }
    }
}
