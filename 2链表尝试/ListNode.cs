using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2链表尝试
{
    public class ListNode
    {
        //创建链表单节点
        SingleListNode head;                     //头
        //定义链表长度
        int count;

        //创建一个结构函数，来初始化这两个值
        public ListNode()
        {
            this.head = null;           //目前的链表为单节点，头部节点无指向，所以定义为null
            this.count = 0;              //单节点长度为0
        }

        /// <summary>
        /// 用于判断这个链表是否是空链表
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.count == 0;
        }

        /// <summary>
        /// 用于查看链表长度
        /// </summary>
        /// <returns></returns>
        public int Count()
        { return this.count; }

        /// <summary>
        /// 用于添加数据 (指定位置)
        /// </summary>
        /// <param name="index">这个节点的指向（第几个节点）,相当于数组下标</param>
        /// <param name="value">这个节点的值</param>
        /// <returns></returns>
        public int Add(int index, int value)
        {
            if (index < 0) { throw new ArgumentOutOfRangeException("Index：" + index); }  //如果给的指针不正确
            if (index > count) { index = count; }

            SingleListNode current = this.head;     //创建一个新节点，等于空的单节点


            if (this.IsEmpty() || index == 0)  //如果这个链表是空的 ,则这个新创建的节点变成头部节点,这个头部节点指向空
            { this.head = new SingleListNode(value, this.head); }

            else
            {
                for (int i = 0; i < index - 1; i++)         //如果不是空的，我们通过for循环，循环到我们想要插入节点的地方的前一个结点
                {
                    current = current.Next;
                }                                                                                                                                                                      // （value2,current.Next)                                               
                current.Next = new SingleListNode(value, current.Next);                  //current.Next  相当于 current.Next  =  (value,current.NextNext)                                       ↑         ↓         
                                                                                         //这里的等式相当于把  current = (value,current.Next) 中的current.Next的指向值折了一下，current =  (value1,▲）    (value,current.NextNext）                   
            }
            count++;
            return value;
        }
        /// <summary>
        /// 用于添加数据（当未给定插入位置）
        /// </summary>
        /// <returns></returns>
        public int Add(int value)
        {
            return Add(count, value);          //在链表最后添加数据          
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="index">目标</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public int Remove(int index)        //index 是下标
        {
            if (index < 0) { throw new ArgumentOutOfRangeException("Index：" + index); }  //如果给的指针不正确

            if (this.IsEmpty()) { return -1; }       //如果链表是空的

            //创建一个新的结点
            SingleListNode  current = this.head;
            int result = 0;

            if (index== 0)      //如果要去除头部结点，这时候要将第二个结点变成头部结点
            {
                result = current.Val;
                this.head = current.Next;
            }
            else
            {
                for (int i=0; index-1 > i; i++) 
                {
                    current = current.Next;
                }
                result = current.Next.Val;

                current.Next = current.Next.Next;           //对下一个数据的指向直接跳到下下一个

            }
            count--;
            return result;
        }

        public void Clear()
        {
            this.head = null;
            count = 0;
        }
    }
}
