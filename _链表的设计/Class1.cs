using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z链表的设计
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            MyLinkedList list = new MyLinkedList();
           
            list.AddAtTail(1);
            list.AddAtTail(3);
            Console.WriteLine(list.Get(1));
        }
    }
}
