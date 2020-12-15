using System;
using System.Collections.Generic;

namespace PrototypePattern // 同一命名空间下不能有相同的类名
{
    public abstract class Shape : ICloneable
    {
        public string ID { get; set; }
        public string TYPE { get; set; }

        public abstract void Draw();

        public object Clone()
        {
            object clone = null;
            clone = this.MemberwiseClone();
            return clone;
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle()
        {
            TYPE = "Rectangle";
        }

        public override void Draw() // 接口方法是直接实现，必须是public类型。而virtual和abstract方法必须用override来重写。
        {
            Console.WriteLine("Draw a Rectangle.");
        }
    }

    public class Square : Shape
    {
        public Square()
        {
            TYPE = "Square";
        }

        public override void Draw()
        {
            Console.WriteLine("Draw a Square.");
        }
    }

    public class Circle : Shape
    {
        public Circle()
        {
            TYPE = "Circle";
        }

        public override void Draw()
        {
            Console.WriteLine("Draw a Circle.");
        }
    }

    public class ShapeClone
    {
        private static Dictionary<string, Shape> shapeDict = new Dictionary<string, Shape>();

        public static Shape getShape(string shapeId)
        {
            Shape cachedShape = shapeDict[shapeId];
            return (Shape)cachedShape.Clone();
        }

        public static void AddShape()
        {
            Circle circle = new Circle();
            circle.ID = "1";
            shapeDict.Add(circle.ID, circle);

            Square square = new Square();
            square.ID = "2";
            shapeDict.Add(square.ID, square);

            Rectangle rectangle = new Rectangle();
            rectangle.ID = "3";
            shapeDict.Add(rectangle.ID, rectangle);
        }
    }

    public class PrototypePatternDemo
    {
        public static void Main2(string[] args)
        {
            ShapeClone.AddShape();

            Shape clonedShape = (Shape)ShapeClone.getShape("1");
            Console.WriteLine(clonedShape.TYPE);

            Shape clonedShape2 = (Shape)ShapeClone.getShape("2");
            Console.WriteLine(clonedShape2.TYPE);

            Shape clonedShape3 = (Shape)ShapeClone.getShape("3");
            Console.WriteLine(clonedShape3.TYPE);
        }
    }
}
