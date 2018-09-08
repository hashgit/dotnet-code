using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using dotnet_code_challenge.Providers.Models;
using System.Linq;

namespace dotnet_code_challenge.Providers.Caulfield
{
    public class CaulfieldFeed : IDataFeed
    {
        private const string FeedPath = "FeedData/Caulfield_Race1.xml";

        public FixtureResponse<Participant> GetParticipants()
        {
            try
            {
                var feed = File.ReadAllText(FeedPath);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(new StringReader(feed));

                var horses = new List<Horse>();
                var horsePrices = new List<HorsePrice>();

                foreach (XmlNode race in xmlDoc.SelectNodes("/meeting/races/race"))
                {
                    foreach(XmlNode horseNode in race.SelectNodes("horses/horse"))
                    {
                        var horse = new Horse { Name = horseNode.Attributes.GetNamedItem("name")?.Value };
                        var numberT = horseNode.SelectSingleNode("number");
                        horse.Number = numberT?.InnerText;

                        horses.Add(horse);
                    }

                    foreach(XmlNode priceNode in race.SelectNodes("prices/price/horses/horse"))
                    {
                        var horsePrice = new HorsePrice
                        {
                            Number = priceNode.Attributes.GetNamedItem("number")?.Value,
                            Price = priceNode.Attributes.GetNamedItem("Price")?.Value.ToDouble() ?? 0
                        };

                        horsePrices.Add(horsePrice);
                    }
                }

                var participants = horsePrices
                    .Select(x => new Participant { Price = x.Price, Name = horses.FirstOrDefault(h => h.Number == x.Number)?.Name })
                    .ToList();


                return new FixtureResponse<Participant> { Data = participants };
            }
            catch (FileNotFoundException fnfe)
            {
                // log it
                return FixtureResponse<Participant>.AsErrorResponse(fnfe.Message);
            }
            catch(Exception e)
            {
                // log it
                return FixtureResponse<Participant>.AsErrorResponse(e.Message);
            }
        }
    }
}
