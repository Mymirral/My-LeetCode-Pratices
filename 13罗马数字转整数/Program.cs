

public class Codes
{
    static void Main(string[] args)
    {
        string s = Console.ReadLine();
        Solution solution = new Solution();
        Console.WriteLine(solution.RomanToInt(s));
    }
}

public class Solution
{
    public int RomanToInt(string s)
    {
        int result = 0;
        char[] ss = s.ToCharArray();
        for (int i = 0; i < ss.Length; i++)
        {
            if (i == ss.Length-1)
            {
                switch (ss[i])
                {
                    case 'I': result += 1; break;
                    case 'V': result += 5; break;
                    case 'X': result += 10; break;
                    case 'L': result += 50; break;
                    case 'C': result += 100; break;
                    case 'D': result += 500; break;
                    case 'M': result += 1000; break;

                }
            }
            else
            {
                switch (ss[i])
                {
                    case 'I': if (ss[i + 1] == 'V' || ss[i + 1] == 'X') { result -= 1; } else { result += 1; } break;
                    case 'V': result += 5; break;
                    case 'X': if (ss[i + 1] == 'L' || ss[i + 1] == 'C') { result -= 10; } else { result += 10; } break;
                    case 'L': result += 50; break;
                    case 'C': if (ss[i + 1] == 'D' || ss[i + 1] == 'M') { result -= 100; } else { result += 100; } break;
                    case 'D': result += 500; break;
                    case 'M': result += 1000; break;

                }
            }
        }
        return result;

    }
}