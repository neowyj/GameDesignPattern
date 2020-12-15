using System;
using System.Collections.Generic;

namespace AbstractFactoryPattern2
{
    // 创建一个形状接口
    public interface Shape
    {
        void Draw();
    }

    public class Rectangle : Shape
    {
        public void Draw()
        {
            Console.WriteLine("Draw a Rectangle.");
        }
    }

    public class Square : Shape
    {
        public void Draw()
        {
            Console.WriteLine("Draw a Square.");
        }
    }

    public class Circle : Shape
    {
        public void Draw()
        {
            Console.WriteLine("Draw a Circle.");
        }
    }

    // 创建一个颜色接口
    public interface Color
    {
        void Fill();
    }

    public class Red: Color
    {
        public void Fill()
        {
            Console.WriteLine("Fill Red.");
        }
    }

    public class Green: Color
    {
        public void Fill()
        {
            Console.WriteLine("Fill Green.");
        }
    }

    public class Blue: Color
    {
        public void Fill()
        {
            Console.WriteLine("Fill Blue.");
        }
    }

    // 创建一个抽象工厂
    public abstract class AbstractFactory
    {
        public abstract Shape GetShape(string shape);
        public abstract Color GetColor(string color);
    }

    public class ShapeFactory : AbstractFactory
    {
        public override Shape GetShape(string shape)
        {
            if (shape == null)
            {
                return null;
            }
            else if (shape == "Rectangle")
            {
                return new Rectangle();
            }
            else if (shape == "Square")
            {
                return new Square();
            }
            else if (shape == "Circle")
            {
                return new Circle();
            }
            return null;
        }

        public override Color GetColor(string color)
        {
            return null;
        }
    }

    public class ColorFactory : AbstractFactory
    {
        public override Color GetColor(string color)
        {
            if (color == null)
            {
                return null;
            }
            else if (color == "Red")
            {
                return new Red();
            }
            else if (color == "Green")
            {
                return new Green();
            }
            else if (color == "Blue")
            {
                return new Blue();
            }
            return null;
        }

        public override Shape GetShape(string shape)
        {
            return null;
        }
    }

    public class FactoryProducer
    {
        public static AbstractFactory GetFactory(string factory)
        {
            if (factory == null)
            {
                return null;
            }
            else if (factory == "ShapeFactory")
            {
                return new ShapeFactory();
            }
            else if (factory == "ColorFactory")
            {
                return new ColorFactory();
            }
            return null;
        }
    }

    public class AbstractFactoryPatternDemo
    {
        public static void Main2(string[] args)
        {
            AbstractFactory shapeFactory = FactoryProducer.GetFactory("ShapeFactory");
            AbstractFactory colorFactory = FactoryProducer.GetFactory("ColorFactory");

            Shape shape1 = shapeFactory.GetShape("Rectangle");
            shape1.Draw();

            Shape shape2 = shapeFactory.GetShape("Square");
            shape2.Draw();

            Shape shape3 = shapeFactory.GetShape("Circle");
            shape3.Draw();



            Color color1 = colorFactory.GetColor("Red");
            color1.Fill();

            Color color2 = colorFactory.GetColor("Green");
            color2.Fill();

            Color color3 = colorFactory.GetColor("Blue");
            color3.Fill();
        }
    }
}