using System;

namespace BoilWaterExample
{
    // A类的内部还可以新建B类，但不能用B类作为A类方法中的参数类型。
    public class BoiledEventArgs : EventArgs
    {
        public readonly int temperature;
        public BoiledEventArgs(int temperature)
        {
            this.temperature = temperature;
        }
    }

    class Heater
    {
        private int temperature;
        public string type = "001";
        public string area = "xian";

        //public delegate void BoilHandler(int temperature);
        //public event BoilHandler BoilEvent;

        
        public delegate void BoilEventHandler(object sender, BoiledEventArgs e);
        public event BoilEventHandler Boiled; // 这个事件接口用于接受观察者处理方法的注册并在事件源内部自动调用

        protected virtual void OnBoiled(BoiledEventArgs e)
        {
            // 执行观察者的事件处理方法前，先检查观察者是否注册事件处理方法，注册了再执行。
            if (Boiled != null)
            { // 如果有对象注册
                Boiled(this, e);  // 调用所有注册对象的方法，并发送事件源和事件数据，让观察者知道谁发出的，然后处理该事件数据。
            }
        }

        public void BoilWater()
        {
            for (int i = 0; i <= 100; i++)
            {
                temperature = i;
                // 当温度超过95时，就触发事件（执行这个事件）并执行观察者的事件处理方法。
                if (temperature > 95)
                {
                    //建立BoiledEventArgs 对象。
                    BoiledEventArgs e = new BoiledEventArgs(temperature);
                    OnBoiled(e);  // 调用 OnBolied方法
                }
            }
        }

        //public void BoilWater()
        //{
        //    for (int i = 0; i < 100; i++)
        //    {
        //        temperature = i;

        //        if (temperature > 95)
        //        {
        //            if (Boiled != null)
        //            {
        //                BoilEvent(temperature);
        //            }
        //            break;
        //        }
        //    }
        //}
    }

    //class Alerter
    //{
    //    public void MakeAlert(int temperature)
    //    {
    //        Console.WriteLine("Alert! " + temperature);
    //    }
    //}

    public class Alarm
    {
        public void MakeAlert(object sender, BoiledEventArgs e)
        {
            Heater heater = (Heater)sender;     //这里是不是很熟悉呢？
                                                //访问 sender 中的公共字段
            Console.WriteLine("Alarm：{0} - {1}: ", heater.area, heater.type);
            Console.WriteLine("Alarm: 嘀嘀嘀，水已经 {0} 度了：", e.temperature);
            Console.WriteLine();
        }
    }

    // 显示器
    public class Display
    {
        public static void ShowMsg(object sender, BoiledEventArgs e)
        {   //静态方法
            Heater heater = (Heater)sender;
            Console.WriteLine("Display：{0} - {1}: ", heater.area, heater.type);
            Console.WriteLine("Display：水快烧开了，当前温度：{0}度。", e.temperature);
            Console.WriteLine();
        }
    }

    //class Shower
    //{
    //    public void ShowMsg(int temperature)
    //    {
    //        Console.WriteLine("Show! " + temperature);
    //    }
    //}

    class Client
    {
        public static void Main1(string[] args)
        {
            //Heater heater = new Heater();
            //Alerter alerter = new Alerter();
            //Shower shower = new Shower();
            //heater.BoilEvent += alerter.MakeAlert;
            //heater.BoilEvent += shower.ShowMsg;
            //heater.BoilWater();

            Heater heater = new Heater();
            Alarm alarm = new Alarm();
            heater.Boiled += alarm.MakeAlert;   //注册方法
            //heater.Boiled += (new Alarm()).MakeAlert;      //给匿名对象注册方法
            //heater.Boiled += (new Heater.BoilEventHandler(alarm.MakeAlert));    //也可以这么注册
            heater.Boiled += Display.ShowMsg;       //注册静态方法

            heater.BoilWater();   //烧水，会自动调用注册过对象的方法
        }
    }
}