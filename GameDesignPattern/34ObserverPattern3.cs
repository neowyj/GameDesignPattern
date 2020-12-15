using System;

namespace ObserverPatternEvent
{
    // 定义事件参数类
    public class NotifyArgs: EventArgs
    {
        public string state;

        public NotifyArgs(string state)
        {
            this.state = state;
        }
    }

    public class BigTrumpet
    {
        private string state;

        // 定义事件需要的委托类型
        public delegate void NotifyHandler(object sender, NotifyArgs e);
        // 定义一个事件变量
        public event NotifyHandler NotifyEvent;

        public string GetState()
        {
            return state;
        }

        public void SetState(string state)
        {
            // 触发事件，并传递事件参数
            NotifyEvent(this, new NotifyArgs(state));
        }
    }

    public class Player
    {
        private string name;

        public Player(string name)
        {
            this.name = name;
        }

        // 新建一个事件处理函数
        public void OnNotify(object sender, NotifyArgs e)
        {
            Console.WriteLine(name + "收到来自大喇叭的消息：" + e.state);
        }
    }

    class client
    {
        public static void Main1(string[] args)
        {
            BigTrumpet bt = new BigTrumpet();

            Player p1 = new Player("Player1");
            Player p2 = new Player("Player2");
            Player p3 = new Player("Player3");

            // 注册（订阅）事件
            bt.NotifyEvent += p1.OnNotify;
            bt.NotifyEvent += p2.OnNotify;
            bt.NotifyEvent += p3.OnNotify;

            bt.SetState("周年庆抽奖活动开始了！");
        }
    }
}