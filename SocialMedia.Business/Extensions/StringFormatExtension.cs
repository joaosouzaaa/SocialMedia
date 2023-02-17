using System.Text.RegularExpressions;

namespace SocialMedia.Business.Extensions
{
    public static class StringFormatExtension
    {
        public static string FormatTo(this string value, params object[] args) =>
            string.Format(value, args);

        public static List<string> ScrapHashtags(this string value) =>
            value.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(word => word.StartsWith("#"))
                .Select(word => Regex.Replace(word.TrimStart('#'), @"[^a-zA-Z]+$", "").ToUpper())
                .ToList();
    }
}
