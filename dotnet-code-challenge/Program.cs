using dotnet_code_challenge.Providers;
using System;
using System.Linq;

namespace dotnet_code_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            PrintHorsesOrdered(FeedProviderType.Wolferhampton);
            PrintHorsesOrdered(FeedProviderType.Caulfield);

            Console.ReadKey();
        }

        static async void PrintHorsesOrdered(FeedProviderType type)
        {
            var manager = new DataFeedProvider();
            var participants = await manager.GetParticipants(type);

            if (participants.IsValid)
            {
                // sorting can be pushed down to the business object
                // if it is a business requirement or just a display requirement?
                var sortedList = participants.Data.OrderBy(x => x.Price);
                foreach (var e in sortedList)
                {
                    Console.WriteLine($"{e.Name} {e.Price}");
                }
            }
            else
            {
                Console.WriteLine(participants.Error);
            }
        }
    }
}
