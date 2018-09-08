using dotnet_code_challenge.Providers.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace dotnet_code_challenge.Providers.Wolferhampton
{
    public class WolferhamptonFeed : IDataFeed
    {
        private const string FeedPath = "FeedData/Wolferhampton_Race1.json";

        public FixtureResponse<Models.Participant> GetParticipants()
        {
            try
            {
                var json = File.ReadAllText(FeedPath);
                var model = JsonConvert.DeserializeObject<Fixture>(json);

                var participants = model.RawData?.Markets
                    ?.SelectMany(x => x.Selections?.Select(p => new Models.Participant() { Price = p.Price, Name = p.Tags?.Name } ))
                    .ToList();

                return new FixtureResponse<Models.Participant> { Data = participants };
            }
            catch (FileNotFoundException fnfe)
            {
                // log it
                return FixtureResponse<Models.Participant>.AsErrorResponse(fnfe.Message);
            }
            catch (Exception e)
            {
                // log it
                return FixtureResponse<Models.Participant>.AsErrorResponse(e.Message);
            }
        }
    }
}
