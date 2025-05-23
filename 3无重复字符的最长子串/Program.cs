

//题目：给定一个字符串 s ，请你找出其中不含有重复字符的"最长"子串的长度。


//我的初步想法，使用List<>的方法或者用Dictionary<>的方法

//使用循环的判断方法，从第一个字符串开始读取，遇到重复，停止读取，记录这一次最长的读取数

//当然，并不是只读取一次就能读出最长，要重复到字符串结束

//上面是我第一次做的想法，当然现在看是错的

//现在用另一种做法：

namespace 无重复最长字串
{
    class Code
    {   
     
        static void Main(string[] args)
        {           
            string input = Console.ReadLine();
            int len = Solution.LengthOfLongestSubstring(input);
            Console.WriteLine(len);
        }
    }

    public static class Solution
    {
        //以下是方法
        public static int LengthOfLongestSubstring(string s)           //注：字符串是只读的char数组
        {
            //我打算采用List的方法来做        因为，在下面循环第一步的时候，我想到了题目中的一个点，只要出现重复，就已经不用再计算次数了


            //定义一下需要用到的数据
            int Maxlen = 0;         //最长的字串长度
            int start = 0;        //从当前开始计算
            int end = 0;            //从这里结束
            List<char> list = new List<char>();                   //<当前的字母>,我这里在写的时候，忘记new List<object>()后面的这个括号了

            //开始循环
            #region 我的第一个方法，有根本性错误！

            /*
            int PassFirstChar = 1;      //错误判断3 的一个解决变量
            //我的想法是：判断条件里面再重新定义一个值
            for (int i = 0; i < s.Length; i++)                  //循环次数就规定为字符串长度吧，当然这里可以优化一下：当剩下该读取的字符串的个数已经小于等于当前重复字串最长长度的时候就可以结束循环了
            {

                //读取和判断，读取字符串当前的字母，并且判断List列表里面有没有包含这个字母

                //判断
                if (list.Contains(s[i]))            //这里修改过判断条件，原来是 if (list.Contains(s[i]))
                {
                    //错误判断3解决方法
                    if (PassFirstChar-- == 1 && s[i] == list[0] ) {  continue; }       //先判断再--

                    //如果包含了的话，要做下面的事情
                    end = i;        //这里的结束标记变成本次循环次数
                    if (end - start > Maxlen) { Maxlen = end - start; }         //判断一下字串最长会不会比原来的更长，会的话重新赋值
                    start = i;      //重新定下标
                    list.Clear();   //清空List数组里面的数
                    list.Add(s[i]);
                }
                else { list.Add(s[i]); }
            }

            Maxlen = list.Count > Maxlen ? list.Count : Maxlen;     //我写来写去，发现好像这样就好了，再末尾的时候判断一下数组个数是不是比不重复字串长。。。
            
            */
            #endregion

            //这一次我的想法是起始点定在 “重复数前者的下一个数”（好好理解一下） 上

            for (int i = 0;i<s.Length;i++)  //大方面见我第一个方法
            {
                //历遍
                if (list.Contains(s[i]))        //如果list包含了当前历遍的char，进入条件
                {    
                    end = i;    //以当前的数为结束点
                    Maxlen = end - start > Maxlen ? end - start : Maxlen;       //赋值
                    start = start> list.LastIndexOf(s[i]) + 1?start: list.LastIndexOf(s[i]) +1 ;       //“重复数前者的下一个数”为起点继续进行
                }
                list.Add(s[i]);
            }
            list.RemoveRange(0,start);              //注意RemoveRange的用法    这里删掉重复数之前的所有数（包括重复数），是为了判断结束之前都没有重复数的情况下，个数会不会大于中间的无重复数字串
            Maxlen = Maxlen > list.Count ? Maxlen : list.Count;


            return Maxlen;  //最后返回最长的字串长度
        }







        /*总结：一开始我用for循环，在里面用了list[i] = s[i] 的判断方法，然后报错了，因为清空list后，不能直接从后面的值开始赋值，一定要从0开始赋值
        *     导致我在for循环和while里面捣鼓了好久，后面一拍脑门，我tm傻逼啊，直接用list.Add不就好了吗，哈哈哈哈

        *     判题错误1：没有考虑只输入一个数的情况
        *     判题错误2：没有考虑在结束时标定结束下标，同时这里重新提醒一下，for循环在一次循环结束后，是先i++，再进行判断的，
        *               嗨呀，这个在一开始啊，乱写乱写发现总是会有一个错的，后面也是突然想到，直接在结束的时候，判断一下数组里面的数的个数会不会比程序里面计算的无重复字符串长，会的话重新赋值就好了啊，我怎么这么傻逼呢哈哈哈
        *     判题错误3：我写的方法是从下一个重复的数据到上一个重复的之间的数的个数，这种方法会出现一种问题：首字母和后面的数一样时，会出现次数不正确，
        *               比如：asdfgahjkl,按照我的方法，算的是a sdfg a 之间的个数，但实际上少了。想办法解决，我初步想法是，给第二个“和首字母相同的字母”一个“免死”，即第一次判断到里面包含的时候，先给他跳过
        *
        *     以上为第一次入手时出现的各种问题，发现是根本上出现问题，即方法不对，虽然错了，但是很多地方得到了很多启发！
        *
        *     整体题目并不难，不过我因为按照我第一个想法写出来的程序会有非常多问题，因为这个程序是用在记录两个相同字母之间的个数，虽然修修补补，但是依旧不能解决根本问题！！问题根本就是计算的起始点定错了
        *
        *
        *     看了题解，这道题其实就是滑动窗口，就这么看，我的第二种想法其实就很类似滑动窗口的做法，只不过哥们我定点有点不太一样
        *
        *      暴力解法：比如例1：  abcabcbb
        *      取第一个数  (a)bcabcbb        取第二个数   a(b)cabcbb    同理第三个数第四个数...  
        *                 (ab)cabcbb                    a(bc)abcbb                             
        *                 (abc)abcbb                    a(bca)bcbb
        *                 a(bca)bcbb                    ab(cab)cbb   
        *                 ab(cab)cbb                    abc(abc)bb
        *                 abc(abc)bb                    abcab(cb)b
        *                 abcab(cb)b                    abcabcb(b)
        *                 abcabcb(b)
        *                 
        *                 
        *    我的做法是:做一个List列表,往里面放数据     (左括号代表start   ）右括号代表end     !!start绝对不会比自己小
        *                    ↓还没放进去，先做判断
        *                   (a
        *                   (ab
        *                   (abc ↓还没放进去，先做判断
        *                   (abc)a
        *                   a(bca)b
        *                   ab(cab)c
        *                   abc(abc)b
        *                   abcab(cb)b
        *                   abcabcb(b)          全部放进去后，在循环过程中获得（）中间最多3个数，删除“（”左括号前所有数，
        *                   剩一个b             比较一下剩下的数的个数和循环中得到的谁大，大的留下
        *                   
        *                   
        */

    }
}
