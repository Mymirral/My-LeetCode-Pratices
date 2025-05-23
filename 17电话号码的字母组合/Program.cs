

using System;
using System.ComponentModel;

public class Codes
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.LetterCombinations("234"));
        
    }
}
//我用到暴力历遍
//不过貌似可以用递归

public class Solution
{
    //不知道要多少个数。。。
    public IList<string> LetterCombinations(string digits)
    {
        Dictionary<char, IList<string>> num = new Dictionary<char, IList<string>>();
        IList<string> cb = new List<string>();
        num.Add('2',["a", "b", "c" ]);
        num.Add('3',["d", "e", "f"]);
        num.Add('4',["g", "h", "i"]);
        num.Add('5',["j", "k", "l"]);
        num.Add('6',["m", "n", "o"]);
        num.Add('7',["p", "q", "r" ,"s"]);
        num.Add('8',["t", "u", "v" ]);
        num.Add('9',["w", "x", "y","z" ]);

        if(digits.Length ==0)return cb;
        if(digits.Length == 1)
        {
             return num[digits[0]];
        }
        if(digits.Length == 2) 
        {
            foreach (var letter1 in num[digits[0]])
            {
                foreach (var letter2 in num[digits[1]])
                {
                    cb.Add(letter1+letter2);
                }
            }
        }
        if(digits.Length == 3) 
        {
            foreach (var letter1 in num[digits[0]])
            {
                foreach (var letter2 in num[digits[1]])
                {
                    foreach (var letter3 in num[digits[2]])
                    {
                        cb.Add(letter1 + letter2+letter3);
                    }
                }
            }
        }
        if(digits.Length == 4) 
        {
            foreach (var letter1 in num[digits[0]])
            {
                foreach (var letter2 in num[digits[1]])
                {
                    foreach (var letter3 in num[digits[2]])
                    {
                        foreach (var letter4 in num[digits[3]])
                        {
                            cb.Add(letter1 + letter2+letter3+letter4);
                        }
                    }
                }
            }
        }
        return cb;
        
    }

}