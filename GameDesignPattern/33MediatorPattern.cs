using System;
using System.Collections.Generic;

namespace MediatorPattern
{
    //抽象中介者
    interface Mediator
    {
        void Register(Customer customer);
        void Relay(Customer customer); //转发
    }

    //具体中介者
    class LianJia : Mediator
    {
        private List<Customer> customers = new List<Customer>();

        public void Register(Customer customer)
        {
            if (!customers.Contains(customer))
            {
                customers.Add(customer);
                customer.SetMediator(this);
            }
        }

        public void Relay(Customer customer)
        {
            string name = customer.GetName();

            foreach (Customer ctm in customers)
            {
                if ((!ctm.Equals(customer)) && (ctm.GetType() != customer.GetType()))
                {
                    ctm.Receive(name);
                }
            }
        }
    }

    //抽象同事类
    abstract class Customer
    {
        protected string name;
        protected Mediator mediator;

        public Customer(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetMediator(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public abstract void Receive(string name);
        public abstract void Send();
    }

    //具体同事类
    class Seller : Customer
    {
        public Seller(string name): base(name)
        {

        }

        public override void Receive(string name)
        {
            Console.WriteLine(this.name + "收到"+ name +"的买房需求");
        }

        public override void Send()
        {
            Console.WriteLine(this.name + "发出卖房需求");
            mediator.Relay(this); //请中介者转发
        }
    }

    //具体同事类
    class Buyer : Customer
    {
        public Buyer(string name): base(name)
        {
            
        }

        public override void Receive(string name)
        {
            Console.WriteLine(this.name + "收到" + name + "的卖房需求");
        }
        public override void Send()
        {
            Console.WriteLine(this.name + "发出买房需求");
            mediator.Relay(this); //请中介者转发
        }
    }

    public class Client
    {
        public static void Main1(string[] args)
        {
            Mediator lianJia = new LianJia();
            Customer s1, s2, s3, b1, b2, b3;

            s1 = new Seller("Seller1");
            s2 = new Seller("Seller2");
            s3 = new Seller("Seller3");

            b1 = new Buyer("Buyer1");
            b2 = new Buyer("Buyer2");
            b3 = new Buyer("Buyer3");

            lianJia.Register(s1);
            lianJia.Register(s2);
            lianJia.Register(s3);

            lianJia.Register(b1);
            lianJia.Register(b2);
            lianJia.Register(b3);

            lianJia.Relay(s1);
            Console.WriteLine();
            lianJia.Relay(b1);
        }
    }
}
