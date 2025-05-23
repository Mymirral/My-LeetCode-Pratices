

/*
 * 首先，链表由两个东西组成
 * 1是数据，2是指向下一个数据的指针
 * 
 * 所以,首先定义一个结点
*/

/*
 * C#里面，链表的实现方式：    
 * 设置一个单结点，比如自定义一个类名： 结点，
 * 结点类里面有两个数据：     1 这个结点代表的值（数据）    2 下一个结点类（指针）
 * 
 * 现在用抽象的方式表现一下： 用结点类定义一些对象
 * 
 *      结点  One =  1（数据） +  结点  Two（指针）
 *      结点  Two =  2（数据） +  结点  Three（指针）
 *      结点  Three = 3（数据） +  结点  Null（指针）
 *      
 *      现在调用链表，查看结点1
 *      One =  1  +  Two
 *                    ↓
 *                    2  +  Three
 *                            ↓
 *                            3   +   Null
 *                                     ↓
 *                                （没有数据了） 
 */




//单节点
public class SingleListNode
{

    //private// 
    int val;       //这个节点的数据  定义为int只能存int值

    SingleListNode next;       //指向下一个数据的指针

    
    public int Val
    {
        get { return val; }
        set { this.val = value; }
    }
    public SingleListNode Next
    {
        get { return this.next; }
        set { this.next = value; }
    }


    public SingleListNode(int val, SingleListNode next)         //用于接收这个节点数据的结构函数
    {
        this.val = val;         //赋值
        this.next = next;
    }
}
