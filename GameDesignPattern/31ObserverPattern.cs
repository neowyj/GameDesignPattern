using System;
using System.Collections.Generic;

namespace GameDesignPattern2
{
    public class Subject
    {
        private List<Observer> observerList = new List<Observer>();
        private int state;

        public int GetState()
        {
            return state;
        }

        public void SetState(int state)
        {
            this.state = state;
            NotifyAllObserver();
        }

        public void Attach(Observer observer)
        {
            observerList.Add(observer);
        }

        public void NotifyAllObserver()
        {
            foreach (var observer in observerList)
            {
                observer.Update();
            }
        }
    }

    public abstract class Observer
    {
        protected Subject subject;
        public abstract void Update();
    }

    public class BinaryObserver : Observer
    {
        public BinaryObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.Attach(this);
        }

        public override void Update()
        {
            Console.WriteLine("BinaryObserver: " + subject.GetState().ToString());
        }
    }

    public class OctalObserver : Observer
    {
        public OctalObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.Attach(this);
        }

        public override void Update()
        {
            Console.WriteLine("OctalObserver: " + subject.GetState().ToString());
        }
    }

    public class HexaObserver : Observer
    {
        public HexaObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.Attach(this);
        }

        public override void Update()
        {
            Console.WriteLine("HexaObserver: " + subject.GetState().ToString());
        }
    }

    public class ObserverPatternDemo
    {
        public static void Main1(string[] args)
        {
            Subject subject = new Subject();

            new BinaryObserver(subject);
            new OctalObserver(subject);
            new HexaObserver(subject);

            Console.WriteLine("First State Change 10");
            subject.SetState(10);
            Console.WriteLine("Second State Change 15");
            subject.SetState(15);
        }
    }
}