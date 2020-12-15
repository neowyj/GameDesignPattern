using System;

namespace ShowInterface
{
    interface Chinese
    {
        void SayHello();
    }

    interface English
    {
        void SayHello();
    }

    // 当多个接口中含有相同方法时，必须采用显式接口。
    // 显式接口必须采用接口.方法形式进行实现，调用时也必须将对象转化为对应的类型才行。
    class People: Chinese, English
    {
        void Chinese.SayHello()
        {
            Console.WriteLine("哈喽");
        }

        void English.SayHello()
        {
            Console.WriteLine("Hello");
        }
    }

    class Client
    {
        public static void Main1(string[] args)
        {
            People people = new People();
            ((Chinese)people).SayHello();
        }
    }
}