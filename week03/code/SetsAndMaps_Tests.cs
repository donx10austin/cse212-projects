using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SetsAndMapsTests {
    static bool IsAnagram(string word1, string word2) {
        // 1. Normalize: remove spaces and lowercase
        string clean1 = word1.Replace(" ", "").ToLower();
        string clean2 = word2.Replace(" ", "").ToLower();

        // 2. Length check
        if (clean1.Length != clean2.Length) {
            return false;
        }

        // 3. Dictionary to track character frequencies
        Dictionary<char, int> counts = new Dictionary<char, int>();

        foreach (char c in clean1) {
            if (counts.ContainsKey(c)) {
                counts[c]++;
            } else {
                counts[c] = 1;
            }
        }

        // 4. Decrement for the second word
        foreach (char c in clean2) {
            if (!counts.ContainsKey(c)) {
                return false; // Character in word2 not in word1
            }
            counts[c]--;
        }

        // 5. Final check: all values must be 0
        foreach (var entry in counts) {
            if (entry.Value != 0) {
                return false;
            }
        }

        return true;
    }

    [TestMethod]
    public void TestIsAnagram() {
        Assert.IsTrue(IsAnagram("listen", "silent"));
        Assert.IsTrue(IsAnagram("evil", "vile"));
        Assert.IsFalse(IsAnagram("hello", "world"));
    }
}