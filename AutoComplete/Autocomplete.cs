using System.Collections.Generic;

namespace AutoComplete;

public class Autocomplete : Trie
{
    public List<string> GetMatches(string prefix)
    {
        var possibleCompleteWords = new List<string>();
        if (!IsPrefix(prefix.ToCharArray())) return possibleCompleteWords;
        var tempNode = GetLastNodeOfPrefix(prefix.ToCharArray());
        if (tempNode.IsEndOfWord)
        {
            possibleCompleteWords.Add(prefix);
        }
        AddEveryPossibleCompleteWord(tempNode, prefix, possibleCompleteWords);

        return possibleCompleteWords;
    }

    private void AddEveryPossibleCompleteWord(TrieNode tempNode, string partialWord, List<string> possibleCompleteWords)
    {
        foreach (var letter in tempNode.ChildNodes.Keys)
        {
            var possibility = partialWord;
            possibility += letter;
            if (tempNode.ChildNodes[letter].IsEndOfWord)
            {
                possibleCompleteWords.Add(possibility);
            }
            AddEveryPossibleCompleteWord(tempNode.ChildNodes[letter], possibility, possibleCompleteWords);
        }
    }

    private TrieNode GetLastNodeOfPrefix(char[] chars)
    {
        var tempNode = Root;
        foreach (var c in chars)
        {
            if (tempNode.ChildNodes.ContainsKey(c))
                tempNode = tempNode.ChildNodes[c];
        }

        return tempNode;
    }

    private bool IsPrefix(char[] chars)
    {
        var tempNode = Root;
        foreach (var c in chars)
        {
            if (!tempNode.ChildNodes.ContainsKey(c))
                return false;

            tempNode = tempNode.ChildNodes[c];
        }
        return true;
    }
}
