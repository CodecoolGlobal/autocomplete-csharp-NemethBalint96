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
            // This function is optional
            throw new NotImplementedException();
        }
    }
}
