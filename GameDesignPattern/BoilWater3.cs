using System;
using System.Threading;
using System.Collections.Generic;

namespace BoilWaterExample3
{
    public delegate string GeneralEventHandler(int num);

    // 定义事件发布者
    public class Publishser
    {
        // 事件在类外部只能出现在+=和-=左边，即事件只能用于注册和注销，不能直接出发（执行事件函数）。
        // 而委托除了可以注册和注销，还可以直接执行委托方法。因此，采用事件是为了避免在类外部不经过任何条件直接触发。
        // 使事件只能在类内部触发。但如果将事件设置为private，事件和委托就没有区别了，事件只是对委托的一种包装，本质还是委托。
        private GeneralEventHandler numberChanged;

        // 声明一个事件访问器后，该事件只能用于注册和注销，不能用于触发事件。
        public event GeneralEventHandler NumberChanged 
        {
            add
            {
                numberChanged += value;
            }
            remove
            {
                numberChanged -= value;
            }
        }
            

        public void Register(GeneralEventHandler method)
        {
            // 将事件设置为私有外界就无法直接注册事件了，只能通过公有方法来实现，我们可以设置为赋值=，这样只能注册一个，注册多个就会覆盖。
            numberChanged = method; 
        }

        // 取消注册
        public void UnRegister(GeneralEventHandler method)
        {
            numberChanged -= method;
        }

        public List<string> DoSomething()
        {
            List<string> strList = new List<string>();
            if (numberChanged == null) return strList;

            // GetInvocationList方法用于获取当前委托变量中的委托链表，即一个委托数组。
            Delegate[] delArray = numberChanged.GetInvocationList();

            foreach (Delegate del in delArray)
            {
                // 进行一个向下转换，要想调用具体的委托方法，必须把系统委托转换为具体的委托类型。
                // 向下转换，是把大类型转换成小类型，这样才能调用小类型中的方法。
                GeneralEventHandler method = (GeneralEventHandler)del;
                try
                {
                    //strList.Add(method(100));       // 调用方法并获取返回值
                    // DynamicInvoke可以调用任何类型的委托方法，参数为参数数组，即任意数量任意类型的参数，返回值为一个object。
                    //strList.Add((string)del.DynamicInvoke(100));
                    method.BeginInvoke(100, null, null);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return strList;
            //if (numberChanged != null)
            //{    // 触发事件
            //    string rtn = numberChanged();
            //    Console.WriteLine(rtn);     // 打印返回的字符串，输出为Subscriber3
            //}
        }
    }

    // 定义事件订阅者
    public class Subscriber1
    {
        public string OnNumberChanged(int num)
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
            return "Subscriber1";
        }
    }

    // 定义事件订阅者
    public class Subscriber2
    {
        public string OnNumberChanged(int num)
        {
            //return "Subscriber2";
            throw new Exception("Subscriber2 Failed");
        }
    }

    // 定义事件订阅者
    public class Subscriber3
    {
        public string OnNumberChanged(int num)
        {
            return "Subscriber3";
        }
    }

    class Program
    {
        static void Main1(string[] args)
        {
            Publishser pub = new Publishser();
            Subscriber1 sub1 = new Subscriber1();
            Subscriber2 sub2 = new Subscriber2();
            Subscriber3 sub3 = new Subscriber3();

            //pub.NumberChanged += new GeneralEventHandler(sub1.OnNumberChanged);
            //pub.NumberChanged += new GeneralEventHandler(sub2.OnNumberChanged);
            //pub.NumberChanged += new GeneralEventHandler(sub3.OnNumberChanged);
            //pub.Register(new GeneralEventHandler(sub1.OnNumberChanged)); // 被第二个处理方法覆盖了。
            //pub.Register(new GeneralEventHandler(sub2.OnNumberChanged));

            //  被第二个处理方法覆盖了。因为事件访问器中的add方法只能注册一个，多了就会被覆盖。
            pub.NumberChanged += new GeneralEventHandler(sub1.OnNumberChanged); 
            pub.NumberChanged += new GeneralEventHandler(sub2.OnNumberChanged);
            pub.NumberChanged += new GeneralEventHandler(sub3.OnNumberChanged);
            //pub.DoSomething();  // 触发事件

            List<string> list = pub.DoSomething();  //调用方法，在方法内触发事件

            Console.WriteLine("return control");

            foreach (string str in list)
            {
                Console.WriteLine(str);
            }
        }
    }
}