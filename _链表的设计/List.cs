


/*
    实现 MyLinkedList 类：

    MyLinkedList() 初始化 MyLinkedList 对象。
    int get(int index) 获取链表中下标为 index 的节点的值。如果下标无效，则返回 -1 。
    void addAtHead(int val) 将一个值为 val 的节点插入到链表中第一个元素之前。在插入完成后，新节点会成为链表的第一个节点。
    void addAtTail(int val) 将一个值为 val 的节点追加到链表中作为链表的最后一个元素。
    void addAtIndex(int index, int val) 将一个值为 val 的节点插入到链表中下标为 index 的节点之前。如果 index 等于链表的长度，那么该节点会被追加到链表的末尾。如果 index 比长度更大，该节点将 不会插入 到链表中。
    void deleteAtIndex(int index) 如果下标有效，则删除链表中下标为 index 的节点。

 */

//单向链表

//创建一个单结点
public class Node
{

    //一个单节点包括两个东西：
    int val = 0;      //这个结点的值
    Node next;      //下一个结点

    //给他们添加属性(用于访问),记得用public标记
    public int Value { get { return val; } set { this.val = value; } }
    public Node Next { get { return next; } set { this.next = value; } }

    //添加单节点的构造函数
    public Node(int value, Node next)
    {
        this.Value = value;
        this.Next = next;
    }
}
public class MyLinkedList
{
    //先创建一个 “指向为空”的节点 和 count（链表有效个数）    
    Node head = null;
    int count;

    //先把Get方法放到最后做，不然我想法会乱
    public MyLinkedList()
    {

    }

    //首先是添加头节点：
    public void AddAtHead(int val)
    {
        //  比如现在是  b->c->d->空    要创建一个 a -> b
        //  需要把 a 变成 “现在” 的头部节点 指向 “原来” 的头部节点
        //  创建一个头部节点，指向为“上一个”头部节点

        this.head = new Node(val, this.head);
        //解释这条代码：
        //首先执行的是Node的构造函数，这个时候 head 仍然是个空节点，所以指向的下一个节点是空节点
        //再赋值给head，将这个节点变成 值为val，指向一个空节点的节点
        //所以，有效节点只有一个，实际节点是两个！！在后面尾部添加数据时是这一点很关键

        //第二种情况：即 count != 0                
        count++;    //有效个数+1
    }

    public void AddAtTail(int val)
    {
        //两种情况 空和非空
        //第一种 空
        if (count == 0) { AddAtHead(val); return; }

        //第二种，非空，这个就 a little more complicate
        //a->b->c->空    要创建一个 c->d->空   相当于在最后一个“指向空”的节点之前添加一个节点
        //所以第一步，是到达空节点之前的节点
        //用循环的方式到达
        //捋一捋，如果 count 的值是 n，实际节点有n+1个， i从1 开始循环，实际上循环到 n 时，就到了空节点的上一个节点

        else
        {
            //新建一个节点，让他等于头部节点，这样我们能够一步步走到最后一个
            Node current = this.head;
            for (int i = 0; i < count-1; i++)
            {
                current = current.Next;
                //因为上面我们让current = head 头部节点，所以current这个节点，可以获得head的下一个节点是哪一个节点，即current.Next （实际上就是head.Next）
                //循环下去，就到空节点之前
            }
            current.Next = new Node(val, current.Next);
            //这个应该不用再解释了？ 参考上面头部函数
        }
        count++;
    }

    public void AddAtIndex(int index, int val)
    {
        //有了添加尾部节点的思路，这个就easy了
        //但是需要有多的判断条件：
        //index < 0
        //index > count
        //以上两种情况不添加进入链表
        if (index < 0 || index > count) { return; }
        else if(index == 0) { AddAtHead(val);return; }
        //其他，同添加尾部节点
        else
        {
            Node current = this.head;
            for (int i = 1; i < index; i++)     //因为我们知道，下标 等于 第几个数-1，所以这里循环也可以是 (int i = 0; i < index-1; i++)  即循环到目标节点的上一个节点
            {
                current = current.Next;
            }
            current.Next = new Node(val, current.Next);
        }
        count++;
    }

    public void DeleteAtIndex(int index)
    {
        if(index < 0 || index >= count) {  return; }    //无此下标

        Node current = this.head; //为了后面的循环先创建一个空节点

        //要删除一个节点，首先考虑节点位置

        //1、节点是头部节点
        if (index == 0)
        {
            //比如 a->b->c 要把 a 删掉， 只需要把 b 变成头节点
            this.head = head.Next;  //b是a的下一个(把a变成b)
        }
        //2、节点不是头部节点
        else
        {
            //比如 a->b->c 要把 b 删掉， 只需要把 a 的指向变成 c
            //循环到目标节点的上一个节点
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            //当current 是 要删除节点的上一个节点的时候，把它的指向改到下下个,即本来的     a->b->c 直接忽略了b ，从a->c
            current.Next = current.Next.Next;
        }
        count--;
    }

    public int Get(int index)
    {
        if (index < 0 || index >= count) { return -1; }    //无此下标
        //要获得目标（下标）节点的值
        //循环到那个目标返回就好
        if (index == 0)
        {
            return head.Value;
        }
        else
        {
            Node current = this.head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }
    }
}