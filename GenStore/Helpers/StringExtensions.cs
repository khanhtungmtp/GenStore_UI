
namespace GenStore.Helpers
{
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input) =>
            input switch
            {
                null => throw new ArgumentNullException(nameof(input)),
                "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
                _ => input.First().ToString().ToUpper() + input.Substring(1)
            };

        public static string ReplaceLastOccurrence(this string source, string find, string replace)
        {
            int place = source.LastIndexOf(find);
            return source.Remove(place, find.Length).Insert(place, replace);
        }
    }

}
