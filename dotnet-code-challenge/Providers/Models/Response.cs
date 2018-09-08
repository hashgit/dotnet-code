using System.Collections.Generic;

namespace dotnet_code_challenge.Providers.Models
{
    public class FixtureResponse<T>
    {
        public IList<T> Data { get; set; }
        public string Error { get; set; }

        public bool IsValid
        {
            get
            {
                return string.IsNullOrWhiteSpace(Error) && Data != null;
            }
        }

        public static FixtureResponse<T> AsErrorResponse(string error)
        {
            return new FixtureResponse<T>() { Error = error };
        }
    }
}
