/*
 * @lc app=leetcode.cn id=966 lang=csharp
 *
 * [966] 元音拼写检查器
 */

// @lc code=start
public class Solution
{
    public string[] Spellchecker(string[] wordlist, string[] queries)
    {
        ISet<string> match = new HashSet<string>();
        IDictionary<string, string> matchIgnoreCase = new Dictionary<string, string>();
        IDictionary<string, string> matchIgnoreVowel = new Dictionary<string, string>();
        foreach (string word in wordlist)
        {
            match.Add(word);
            string wordLower = word.ToLower();
            matchIgnoreCase.TryAdd(wordLower, word);
            string ignoreVowel = IgnoreVowel(wordLower);
            matchIgnoreVowel.TryAdd(ignoreVowel, word);
        }
        int length = queries.Length;
        string[] answer = new string[length];
        for (int i = 0; i < length; i++)
        {
            string query, queryLower, queryLowerIgnoreVowel;
            if (match.Contains(query = queries[i]))
            {
                answer[i] = query;
            }
            else if (matchIgnoreCase.ContainsKey(queryLower = query.ToLower()))
            {
                answer[i] = matchIgnoreCase[queryLower];
            }
            else if (matchIgnoreVowel.ContainsKey(queryLowerIgnoreVowel = IgnoreVowel(queryLower)))
            {
                answer[i] = matchIgnoreVowel[queryLowerIgnoreVowel];
            }
            else
            {
                answer[i] = "";
            }
        }
        return answer;
    }

    public string IgnoreVowel(string str)
    {
        char[] array = str.ToCharArray();
        int length = array.Length;
        for (int i = 0; i < length; i++)
        {
            if (IsVowel(array[i]))
            {
                array[i] = '.';
            }
        }
        return new string(array);
    }

    public bool IsVowel(char c)
    {
        return c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U' || c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }
}
// @lc code=end

