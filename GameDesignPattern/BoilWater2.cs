using System;

namespace BoilWaterExample2
{
    class Program
    {
        static void Main1(string[] args)
        {
            Publishser pub = new Publishser();
            Subscriber sub = new Subscriber();
            NumberChangedEventHandler d;
            // 先注册这个事件接口，然后在事件源内在一定条件下才触发。
            //pub.NumberChanged += new NumberChangedEventHandler(sub.OnNumberChanged);
            //d = sub.OnNumberChanged;
            //d(100);
            pub.NumberChanged += sub.OnNumberChanged;
            pub.DoSomething();          // 应该通过DoSomething()来触发事件

            // 但是现在注册后，直接出发了。事件本质也是委托，事件可以接受委托和方法直接赋值，执行和函数一样。

            // 事件的本意是为了限制客户端直接触发事件，而是应该在事件发布者中一定条件下才触发事件。
            //pub.NumberChanged(100);     // 但可以被这样直接调用，对委托变量的不恰当使用

            // 引入事件后，这个事件就只能注册和注销，不能触发，触发就是直接执行函数。

        }
    }

    // 定义委托
    public delegate void NumberChangedEventHandler(int count);

    // 定义事件发布者
    public class Publishser
    {
        private int count;
        //public NumberChangedEventHandler NumberChanged;         // 声明委托变量

        // 事件发布者的事件既可以在类的外部接受事件处理方法的注册，又可以在类的内部触发事件。
        // 但是在类的内部触发事件前，先要检查外部的事件处理函数注册好没，然后再触发，并把当前事件发布者和事件参数（事件数据）传递给事件处理函数。
        public event NumberChangedEventHandler NumberChanged; // 声明一个事件

        public void DoSomething()
        {
            // 在这里完成一些工作 ...

            if (NumberChanged != null)
            {    // 触发事件
                count++;
                NumberChanged(count);
            }
        }
    }

    // 定义事件订阅者
    public class Subscriber
    {
        // 一般用“On事件名”表示事件处理函数，事件订阅者的事件处理函数应该注册到事件发布者的事件处理器中。
        public void OnNumberChanged(int count)
        {
            Console.WriteLine("Subscriber notified: count = {0}", count);
        }
    }
}