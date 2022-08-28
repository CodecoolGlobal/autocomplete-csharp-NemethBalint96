using System.Collections.Generic;

namespace AutoComplete;

    public class TrieNode
    {
    public Dictionary<char, TrieNode> ChildNodes { get; set; } = new();
    public bool IsEndOfWord { get; set; }
}
