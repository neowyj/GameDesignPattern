using System;

namespace DelegateAndEvent
{
    // 委托类型也是一个类，类的内部可以声明其他类，但根据单一职责原则，所以类里面只包好字段、属性和方法。
    public delegate void GreetingDelegate(string name);

    public class GreetManager
    {
        //public GreetingDelegate d;
        public event GreetingDelegate MarkGreet;

        public void GreetPeople(string name)
        {
            //if (d != null)
            //{
            //    d(name);
            //}
            MarkGreet(name);
        }
    }

    public class Client
    {
        // 在一个类内部使用它的静态方法就不需要加类名，因为在内部使用静态方法时，系统会自动寻找当前类的静态方法。
        public static void ChineseGreeting(string name)
        {
            Console.WriteLine("你好，" + name);
        }

        public static void EnglishGreeting(string name)
        {
            Console.WriteLine("Hello, " + name);
        }

        public static void Main1(string[] args)
        {
            // 1、
            //GreetManager gm = new GreetManager();
            //gm.GreetPeople("Neo", ChineseGreeting);
            //gm.GreetPeople("Neo", EnglishGreeting);

            // 2、方法可以直接赋值给对应的委托变量。（第一次赋值初始化）
            //GreetingDelegate d;
            //d = ChineseGreeting;
            //d += EnglishGreeting;
            //d("Neo");

            // 3、委托采用构造函数初始化时，必须传入对应的方法。
            //GreetingDelegate d = new GreetingDelegate(ChineseGreeting);
            //d += EnglishGreeting;
            //// 委托变量可以赋值和注册
            //GreetingDelegate d2;
            //d2 = d;
            //d("Neo");
            //d2("Neo");

            // 4、一个委托变量可以绑定多个方法，然后将这个委托变量作为函数参数，就可以按方法绑定顺序执行多个方法。
            //GreetManager gm = new GreetManager();
            //gm.d = ChineseGreeting;
            //gm.d += EnglishGreeting;
            //// 在类内部调用最终执行的委托，这个委托为最终要执行的委托。
            //gm.GreetPeople("Neo");

            // 5、事件是对委托变量的进一步封装，类似于属性对字段的封装，用于保护委托不被外界修改。
            // 因此事件的权限很低，只能被注册+=和注销-=方法。即事件永远只能出现在注册+=和注销-=的左边。
            // 事件event本身也是一个委托类型，所以它可以直接注册方法。
            GreetManager gm = new GreetManager();
            GreetingDelegate d = new GreetingDelegate(ChineseGreeting);
            //gm.MarkGreet = ChineseGreeting;
            // 委托可以注册到事件。
            gm.MarkGreet += d;
            gm.MarkGreet += EnglishGreeting;
            gm.GreetPeople("Neo");
        }
    }
}