using System;

namespace ObjectAdapterPattern
{
    public interface Target
    {
        void Out5V();
        void Out10V();
        void Out15V();
    }

    public class Adaptee
    {
        public void Out220V()
        {
            Console.WriteLine("220V");
        }
    }

    public abstract class AbstractAdapter : Target
    { 
        public virtual void Out5V()
        {

        }

        public virtual void Out10V()
        {

        }

        public virtual void Out15V()
        {

        }
    }

    public class Adapter5V: AbstractAdapter
    {
        private Adaptee adaptee;

        public Adapter5V(Adaptee adaptee)
        {
            this.adaptee = adaptee;
        }

        public override void Out5V()
        {
            adaptee.Out220V();
            Console.WriteLine("5v");
        }
    }

    public class Client
    {
        public static void Main1(string[] args)
        {
            Adaptee adaptee = new Adaptee();
            Target target = new Adapter5V(adaptee);
            target.Out5V();
        }
    }
}
