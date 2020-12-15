using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    public abstract class Subject
    {
        private List<Observer> observers = new List<Observer>();
        protected string state;

        public void Add(Observer observer)
        {
            observers.Add(observer);
        }

        public void Remove(Observer observer)
        {
            observers.Remove(observer);
        }

        public void Notify(string state)
        {
            foreach (var o in observers)
            {
                o.Update(state);
            }
        }

        public abstract string GetState();
        public abstract void SetState(string state);
    }

    public class BigTrumpet: Subject
    {
        public override string GetState()
        {
            return state;
        }

        public override void SetState(string state)
        {
            this.state = state;
            Notify(state);
        }
    }

    public abstract class Observer
    {
        public abstract void Update(string state);
    }

    public class Player: Observer
    {
        private string name;

        public Player(string name)
        {
            this.name = name;
        }

        public override void Update(string state)
        {
            Console.WriteLine(name + "收到来自大喇叭的消息：" + state);
        }
    }

    public class client
    {
        public static void Main1(string[] args)
        {
            Subject bt = new BigTrumpet();

            Observer p1 = new Player("Player1");
            Observer p2 = new Player("Player2");
            Observer p3 = new Player("Player3");

            bt.Add(p1);
            bt.Add(p2);
            bt.Add(p3);

            bt.SetState("周年庆抽奖活动开始了！");
        }
    }
}
     