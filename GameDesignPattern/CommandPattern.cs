using System;
using System.Collections.Generic;

namespace GameDesignPattern
{
    public interface Order
    {
        void execute();
    }

    class Stock
    {
        private string name;
        private int quantity;

        public Stock(string name, int quantity)
        {
            this.name = name;
            this.quantity = quantity;
        }

        public void Buy()
        {
            Console.WriteLine("stock:" + name + "," + "quantity:" + quantity + " brought.");
        }

        public void Sell()
        {
            Console.WriteLine("stock:" + name + "," + "quantity:" + quantity + " sold.");
        }
    }

    class BuyStock: Order
    {
        private Stock stock;

        public BuyStock(Stock stock)
        {
            this.stock = stock;
        }

        public void execute()
        {
            stock.Buy();
        }
    }

    class SellStock : Order
    {
        private Stock abcStock;

        public SellStock(Stock abcStock)
        {
            this.abcStock = abcStock;
        }

        public void execute()
        {
            abcStock.Sell();
        }
    }

    public class Broker
    {
        private List<Order> orderList = new List<Order>();

        public void TakeOrder(Order order) // 要想让接口作为参数，访问修饰符必须设置为public。
        {
            orderList.Add(order);
        }

        public void ExecuteOrder()
        {
            foreach (var o in orderList)
            {
                o.execute();
            }

            orderList.Clear(); // Clear函数就是清除List和Dictionary的所有元素
        }
    }

    public class CommandPatternDemo
    {
        public static void Main1(string[] args)
        {
            Stock stock = new Stock("ABC", 10);

            BuyStock buyStockOrder = new BuyStock(stock);
            SellStock sellStockOrder = new SellStock(stock);

            Broker broker = new Broker();
            broker.TakeOrder(buyStockOrder);
            broker.TakeOrder(sellStockOrder);

            broker.ExecuteOrder();
        }
    }
}
