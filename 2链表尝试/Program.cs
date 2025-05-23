using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2链表尝试
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ListNode LN = new ListNode();

            LN.Add(1);
            LN.Add(2);
            LN.Add(3);
            LN.Add(4);
            LN.Add(5);
            LN.Add(6);
            LN.Add(7);

            LN.Remove(5);

            LN.Clear();



            Console.WriteLine("Is it empty?-----" + LN.IsEmpty());
            Console.WriteLine("Count-----" + LN.Count());
        }
    }
}
