using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Problem 1: Find symmetric pairs (e.g., "am" & "ma") in O(n) time.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var results = new List<string>();

        foreach (var word in words)
        {
            // Reverse the 2-character word
            string reversed = new string(new char[] { word[1], word[0] });

            // If reverse is in set and not a self-match (like "aa")
            if (seen.Contains(reversed) && word != reversed)
            {
                results.Add($"{reversed} & {word}");
            }
            else
            {
                seen.Add(word);
            }
        }
        return results.ToArray();
    }

    /// <summary>
    /// Problem 2: Summarize degrees from column 4 of a CSV file.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length >= 4)
            {
                string degree = fields[3].Trim();
                // Tally the count
                degrees[degree] = degrees.GetValueOrDefault(degree, 0) + 1;
            }
        }
        return degrees;
    }

    /// <summary>
    /// Problem 3: Anagram check using a frequency dictionary.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        string s1 = word1.Replace(" ", "").ToLower();
        string s2 = word2.Replace(" ", "").ToLower();

        if (s1.Length != s2.Length) return false;

        var counts = new Dictionary<char, int>();
        foreach (char c in s1) counts[c] = counts.GetValueOrDefault(c, 0) + 1;

        foreach (char c in s2)
        {
            if (!counts.ContainsKey(c) || counts[c] == 0) return false;
            counts[c]--;
        }
        return true;
    }

    /// <summary>
    /// Problem 5: USGS Earthquake Daily Summary JSON parsing.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var summaries = new List<string>();
        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                summaries.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
            }
        }
        return summaries.ToArray();
    }
}