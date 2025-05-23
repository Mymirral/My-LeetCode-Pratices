


using System.Diagnostics.Tracing;

public class Program
{
    static void Main(string[] args)
    {
        int num = Convert.ToInt32(Console.ReadLine());
        Solution s = new Solution();
        Console.WriteLine(s.IntToRoman(num));

    }
}

public class Solution
{
    public string IntToRoman(int num)
    {
        List<int> nums = new List<int>();
        int numLen = num.ToString().Length;
        for (int i = numLen; i>0;i--) 
        {
            int x = Convert.ToInt32(Math.Pow(10,i-1));
            nums.Add(num/x);
            num = num%x;
        }
        switch (numLen) 
        {
            case 4: return ToRoman4(nums[0]) + ToRoman3(nums[1]) + ToRoman2(nums[2]) + ToRoman1(nums[3]);
            case 3: return ToRoman3(nums[0]) + ToRoman2(nums[1]) + ToRoman1(nums[2]);
            case 2: return ToRoman2(nums[0]) + ToRoman1(nums[1]);
            case 1: return ToRoman1(nums[0]);
                default: return "";
        }
    }

    public string ToRoman1(int num) 
    {
        switch (num) 
        {
            case 1: return "I";
            case 2: return "II";
            case 3: return "III";
            case 4: return "IV";
            case 5: return "V";
            case 6: return "VI";
            case 7: return "VII";
            case 8: return "VIII";
            case 9: return "IX";
            default: return "";
        }
        
    }
    public string ToRoman2(int num) 
    {
        switch (num) 
        {
            case 1: return "X";
            case 2: return "XX";
            case 3: return "XXX";
            case 4: return "XL";
            case 5: return "L";
            case 6: return "LX";
            case 7: return "LXX";
            case 8: return "LXXX";
            case 9: return "XC";
            default: return "";
        }
    }
    public string ToRoman3(int num) 
    {
        switch (num) 
        {
            case 1: return "C";
            case 2: return "CC";
            case 3: return "CCC";
            case 4: return "CD";
            case 5: return "D";
            case 6: return "DC";
            case 7: return "DCC";
            case 8: return "DCCC";
            case 9: return "CM";
            default: return "";
        }
    }
    public string ToRoman4(int num) 
    {
        switch (num) 
        {
            case 1: return "M";
            case 2: return "MM";
            case 3: return "MMM";
            default: return "";
        }
    }
}