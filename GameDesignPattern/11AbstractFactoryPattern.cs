using System;
using System.Collections.Generic;

// 苹果、华为、小米（增加）
namespace AbstractFactoryPattern
{
    public interface Phone
    {
        void Call();
    }

    public interface Computer
    {
        void Work();
    }

    public interface Pad
    {
        void Play();
    }

    public interface AbstractFactory
    {
        Phone GetPhone();
        Computer GetComputer();
        Pad GetPad();
    }

    public class FactoryProducer
    {
        public static AbstractFactory GetFactory(string company)
        {
            if (company == "Apple")
            {
                return new AppleFactory();
            }
            else if (company == "Huawei")
            {
                return new HuaweiFactory();
            }
            else if (company == "Xiaomi")
            {
                return new XiaomiFactory();
            }
            return null;
        }
    }

    public class AppleFactory : AbstractFactory
    {
        public Phone GetPhone()
        {
            return new iPhone();
        }

        public Computer GetComputer()
        {
            return new MacBook();
        }

        public Pad GetPad()
        {
            return new iPad();
        }
    }

    public class HuaweiFactory : AbstractFactory
    {
        public Phone GetPhone()
        {
            return new HuaweiPhone();
        }

        public Computer GetComputer()
        {
            return new MateBook();
        }

        public Pad GetPad()
        {
            return new HuaweiPad();
        }
    }

    public class XiaomiFactory : AbstractFactory
    {
        public Phone GetPhone()
        {
            return new XiaomiPhone();
        }

        public Computer GetComputer()
        {
            return new XiaomiComputer();
        }

        public Pad GetPad()
        {
            return new XiaomiPad();
        }
    }

    public class iPhone : Phone
    {
        public void Call()
        {
            Console.WriteLine("iPhone Call");
        }
    }

    public class MacBook : Computer
    {
        public void Work()
        {
            Console.WriteLine("MacBook Work");
        }
    }

    public class iPad : Pad
    {
        public void Play()
        {
            Console.WriteLine("iPad Play");
        }
    }

    public class HuaweiPhone : Phone
    {
        public void Call()
        {
            Console.WriteLine("HuaweiPhone Call");
        }
    }

    public class MateBook : Computer
    {
        public void Work()
        {
            Console.WriteLine("MateBook Work");
        }
    }

    public class HuaweiPad : Pad
    {
        public void Play()
        {
            Console.WriteLine("HuaweiPad Play");
        }
    }

    public class XiaomiPhone : Phone
    {
        public void Call()
        {
            Console.WriteLine("XiaomiPhone Call");
        }
    }

    public class XiaomiComputer : Computer
    {
        public void Work()
        {
            Console.WriteLine("XiaomiCompuer Work");
        }
    }

    public class XiaomiPad : Pad
    {
        public void Play()
        {
            Console.WriteLine("XiaomiPad Play");
        }
    }

    public class AbstractFactoryPatternDemo
    {
        public static void Main1(string[] args)
        {
            AbstractFactory appleFactory = FactoryProducer.GetFactory("Apple");
            AbstractFactory huaweiFactory = FactoryProducer.GetFactory("Huawei");
            //AbstractFactory xiaomiFactory = FactoryProducer.GetFactory("Xiaomi");

            Phone applePhone = appleFactory.GetPhone();
            applePhone.Call();
            Computer appleComputer = appleFactory.GetComputer();
            appleComputer.Work();
            Pad applePad = appleFactory.GetPad();
            applePad.Play();


            Phone huaweiPhone = huaweiFactory.GetPhone();
            huaweiPhone.Call();
            Computer huaweiComputer = huaweiFactory.GetComputer();
            huaweiComputer.Work();
            Pad huaweiPad = huaweiFactory.GetPad();
            huaweiPad.Play();

            //Console.WriteLine();

            //Phone xiaomiPhone = xiaomiFactory.GetPhone();
            //xiaomiPhone.Call();
            //Computer xiaomiComputer = xiaomiFactory.GetComputer();
            //xiaomiComputer.Work();
            //Pad xiaomiPad = xiaomiFactory.GetPad();
            //xiaomiPad.Play();
        }
    }
}
