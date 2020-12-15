using System;
using System.Collections.Generic;

namespace GameDesignPattern
{
    public interface Shape
    {
        void Draw();
    }

    public class Circle : Shape
    {
        private String color;
        private int x;
        private int y;
        private int radius;

        public Circle(string color)
        {
            this.color = color;
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public void setRadius(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            Console.WriteLine("Draw a circle: " + color +","+ radius +","+ x +","+ y);
        }
    }

    public class ShapeFactory
    {
        public static Dictionary<string, Shape> circleDict = new Dictionary<string, Shape>();

        public static Shape GetCircle(string color)
        {
            Circle circle = null;

            if (!circleDict.ContainsKey(color))
            {
                circle = new Circle(color);
                circleDict.Add(color, circle);
                Console.WriteLine("Create a circle");
            }
            
            return circle;
        }
    }

    public class FlyweightPatternDemo
    {
        public static string[] colors = { "Red", "Green", "Blue", "White", "Black" };
        private static Random random = new Random();

        public static void Main1(string[] args)
        {
            DrawCircle();
        }

        private static void DrawCircle()
        {
            Circle circle = (Circle)ShapeFactory.GetCircle(getRandomColor());
            circle.setX(getRandomX());
            circle.setY(getRandomY());
            circle.setRadius(100);
            circle.Draw();
        }

        private static string getRandomColor()
        {
            return colors[(int)random.Next(1, colors.Length)];
        }

        private static int getRandomX()
        {
            return (int)random.Next(1, 100);
        }

        private static int getRandomY()
        {
            return (int)random.Next(1, 100);
        }
    }
}