using System;
using System.Collections.Generic;

namespace TransportPattern
{
    interface Transport
    {
        void TransportMethod();
    }

    class Car: Transport
    {
        public void TransportMethod()
        {
            Console.WriteLine("Car Go!");
        }
    }

    class Train: Transport
    {
        public void TransportMethod()
        {
            Console.WriteLine("Train Go!");
        }
    }

    class Airplane: Transport
    {
        public void TransportMethod()
        {
            Console.WriteLine("Airplane Go!");
        }
    }

    class Travel
    {
        private Transport transport;

        public void SetTransport(Transport transport)
        {
            this.transport = transport;
        }

        public void TransportMethod()
        {
            transport.TransportMethod();
        }
    }

    class Client
    {
        public static void Main1(string[] args)
        {
            Travel c = new Travel();

            // 策略一
            Transport car = new Car();
            c.SetTransport(car);
            c.TransportMethod();

            // 策略二
            Transport train = new Train();
            c.SetTransport(train);
            c.TransportMethod();

            // 策略三
            Transport airplane = new Airplane();
            c.SetTransport(airplane);
            c.TransportMethod();
        }
    }
}