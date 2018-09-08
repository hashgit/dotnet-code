namespace dotnet_code_challenge
{
    public static class Converters
    {
        public static double ToDouble(this string str)
        {
            if (double.TryParse(str, out double d))
            {
                return d;
            }

            return 0;
        }
    }
}
