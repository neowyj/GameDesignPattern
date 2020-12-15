using System;
using System.Collections.Generic;

namespace AbstractFactoryPattern
{
    //抽象构件
    interface Component
    {
        void Add(Component c);
        void Remove(Component c);
        Component GetChild(int i);
        void Operation();
    }

    //树叶构件
    class Leaf : Component
    {
        private string name;

        public Leaf(string name)
        {
            this.name = name;
        }

        public void Add(Component c) { }

        public void Remove(Component c) { }

        public Component GetChild(int i)
        {
            return null;
        }

        public void Operation()
        {
            Console.WriteLine("I am " + name);
        }
    }

    //树枝构件
    class Composite : Component
    {
        private string name;

        public Composite(string name)
        {
            this.name = name;
        }

        private List<Component> children = new List<Component>();

        public void Add(Component c)
        {
            children.Add(c);
        }

        public void Remove(Component c)
        {
            children.Remove(c);
        }

        public Component GetChild(int i)
        {
            return children[i];
        }

        public void Operation()
        {
            Console.WriteLine("I am " + name);
            foreach (Component component in children)
            {
                component.Operation();
            }
        }    
    }

    public class Client
    {
        public static void Main1(string[] args)
        {
            Component ceo = new Composite("CEO");
            Component cfo = new Composite("CFO");
            Component cto = new Composite("CTO");
            Component cmo = new Composite("CMO");

            Component f1 = new Leaf("F1");
            Component f2 = new Leaf("F2");
            Component t1 = new Leaf("T1");
            Component t2 = new Leaf("T2");
            Component m1 = new Leaf("M1");
            Component m2 = new Leaf("M2");

            ceo.Add(cfo);
            ceo.Add(cto);
            ceo.Add(cmo);
            cfo.Add(f1);
            cfo.Add(f2);
            cto.Add(t1);
            cto.Add(t2);
            cmo.Add(m1);
            cmo.Add(m2);
            ceo.Operation();
            // 除了new隐藏函数与对象的类型有关外，不管是override还是类本身的方法始终都只与构造函数有关。
            // 继承自同一个接口类型，不同子类实例化得到的对象，即使调用相同的接口，自身的方法实现也不同。如，树叶和树枝节点的Operation方法不同。
            // 组合模式实际上就是树状结构，然后不断循环地调用节点的方法，最终整个树的方法都执行完。添加节点时，从上往下，从左到右进行添加。
        }
    }
}


