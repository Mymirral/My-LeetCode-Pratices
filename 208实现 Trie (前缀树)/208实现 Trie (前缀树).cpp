#include <string>
#include <unordered_map>

using namespace std;

class Trie {

    struct trienode
    {
        char letter;
        bool end;
        unordered_map<char, trienode*> next;

        trienode() : letter(NULL), end(false){};
        trienode(char c) : letter(c), end(false){};
    };

public:

    trienode* head;

    Trie() {
        head = new trienode();
    }

    void insert(string word) {

        trienode* node = head;

        for (auto letter : word)
        {
            if (!node->next[letter])
            {
                node->next[letter] = new trienode(letter);
            }
            node = node->next[letter];
        }

        node->end = true;
    }

    bool search(string word) {
        trienode* node = head;

        for (int i = 0; i < word.size(); i++)
        {
            if (!node->next[word[i]]) break;
            node = node->next[word[i]];
            if (i == word.size() - 1)
            {
                return node->end;
            }
        }
        return false;
    }

    bool startsWith(string prefix) {
        trienode* node = head;

        for (int i = 0; i < prefix.size(); i++)
        {
            if (!node->next[prefix[i]]) break;
            node = node->next[prefix[i]];
            if (prefix.size() - 1 == i)
            {
                return true;
            }
        }
        return false;
    }
};

/**
 * Your Trie object will be instantiated and called as such:
 * Trie* obj = new Trie();
 * obj->insert(word);
 * bool param_2 = obj->search(word);
 * bool param_3 = obj->startsWith(prefix);
 */