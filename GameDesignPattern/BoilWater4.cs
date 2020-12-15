using System;

namespace DelegateExample
{
    class Hello
    {
        public delegate void HelloDelegate(string name);
        // 声明一个事件
        public event HelloDelegate helloDelegateEvent;

        public void HelloFunc(string name, string face)
        {
            if (face == "颜值高")
            {
                // 触发事件
                helloDelegateEvent(name);
            }
        }

        public void EnglishHello(string name)
        {
            Console.WriteLine("Hello," + name);
        }

        public void ChineseHello(string name)
        {
            Console.WriteLine("你好，" + name);
        }
    }

    class Client
    {
        public static void Main1(string[] args)
        {
            Hello hello = new Hello();
            hello.helloDelegateEvent += hello.ChineseHello;
            //hello.helloDelegateEvent("迪丽热巴"); 会报错，提示helloDelegate只能出现“+=”和“-=”左边
            hello.HelloFunc("迪丽热巴", "颜值高");
            hello.HelloFunc("张三", "Chou");
        }
    }
}

// 输出结果：
// 你好，迪丽热巴