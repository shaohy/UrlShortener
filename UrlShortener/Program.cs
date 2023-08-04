using System;
using System.Collections.Generic;

public class UrlShortener
{
    private Dictionary<string, string> urlMap;

    public UrlShortener()
    {
        urlMap = new Dictionary<string, string>();
    }

    public string GetShortUrl(string longUrl)
    {
        if (longUrl.Length == 0)
        {
            throw new Exception("Long URL cannot be empty.");
        }

        string shortCode;
        string prefix;

        // Add a prefix "1", "2", or "3" based on the length of the original long URL
        if (longUrl.Length <= 10)
        {
            prefix = "1";
        }
        else if (longUrl.Length <= 30)
        {
            prefix = "2";
        }
        else
        {
            prefix = "3";
        }
        shortCode = prefix + GenerateShortCode();

        // Check if the key already exists, if yes, generate a new short code
        while (urlMap.ContainsKey(shortCode))
        {
            shortCode = GenerateShortCode();
        }
        urlMap[shortCode] = longUrl;

        return $"https://www.domainName.com/{shortCode}";
    }

    public string GetLongUrl(string shortUrl)
    {
        // Extract the short code from the short URL
        string shortCode = shortUrl.Substring(shortUrl.LastIndexOf('/') + 1);

        // Retrieve the long URL from the mapping
        if (urlMap.TryGetValue(shortCode, out string longUrl))
        {
            return longUrl;
        }
        else
        {
            throw new Exception("Short URL not found.");
        }
    }

    private static string GenerateShortCode()
    {
        // Generate short codes by getting the first 7 digits from a new GUID
        return Guid.NewGuid().ToString().Substring(0, 7);
    }
}

class Program
{
    static void Main()
    {
        var urlShortener = new UrlShortener();
        ConvertLongToShort(urlShortener);
        ConvertShortToLong(urlShortener);
    }

    static void ConvertLongToShort(UrlShortener urlShortener)
    {
        string longUrl;

        do
        {
            Console.WriteLine("Enter the long URL (cannot be empty):");
            longUrl = Console.ReadLine();
        }
        while (string.IsNullOrEmpty(longUrl));

        try
        {
            string shortUrl = urlShortener.GetShortUrl(longUrl);
            Console.WriteLine($"Shortened URL: {shortUrl}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertShortToLong(UrlShortener urlShortener)
    {
        string shortUrl;

        do
        {
            Console.WriteLine("Enter the short URL (cannot be empty):");
            shortUrl = Console.ReadLine();
        }
        while (string.IsNullOrEmpty(shortUrl));

        try
        {
            string retrievedLongUrl = urlShortener.GetLongUrl(shortUrl);
            Console.WriteLine($"Retrieved Long URL: {retrievedLongUrl}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
