using System.Collections.Generic;

namespace AutoComplete;

    public class Trie
    {
        public TrieNode Root;

        public Trie()
        {
        Root = new TrieNode();
        }

        public void Insert(string word)
        {
        var chars = word.ToCharArray();
        var tempNode = Root;
        foreach (var c in chars)
        {
            if (!tempNode.ChildNodes.ContainsKey(c))
                tempNode.ChildNodes.Add(c, new TrieNode());

            tempNode = tempNode.ChildNodes[c];
        }

        tempNode.IsEndOfWord = true;
        }

        public bool Remove(string word)
        {
        var chars = word.ToCharArray();
        var tempNode = Root;
        if (!IsExist(chars)) return false;
        for (var i = 0; i < chars.Length; i++)
        {
            if (tempNode.ChildNodes.Keys.Count != 1) continue;
            tempNode.ChildNodes = new Dictionary<char, TrieNode>();
            return true;
        }

        return false;
    }

    private bool IsExist(char[] chars)
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
