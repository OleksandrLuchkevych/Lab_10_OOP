using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace Lab_10_OOP
{
    [DataContract]
    public struct Point
    {
        [DataMember]
        public int X;
        [DataMember]
        public int Y;
        public Point(int x, int y)
        {
            X = x; Y = y;
        }
        public override string ToString()
        {
            return $"Point ({X};{Y})";
        }
    }
    [DataContract]
    public class Triangle
    {
        [DataMember]
        private Point _vertex1, _vertex2, _vertex3;

        public Triangle(Point vertex1, Point vertex2, Point vertex3)
        {
            _vertex1 = vertex1;
            _vertex2 = vertex2;
            _vertex3 = vertex3;
        }

        public double Distance(Point first, Point second)
        {
            return Math.Sqrt(Math.Pow((first.X - second.X), 2) + Math.Pow((first.Y - second.Y), 2));
        }
        public double Perimeter()
        {
            double distance1 = Distance(_vertex1, _vertex2);
            double distance2 = Distance(_vertex1, _vertex3);
            double distance3 = Distance(_vertex2, _vertex3);

            return distance1 + distance2 + distance3;
        }
        public double Square()
        {
            double distance1 = Distance(_vertex1, _vertex2);
            double distance2 = Distance(_vertex1, _vertex3);
            double distance3 = Distance(_vertex2, _vertex3);
            double HalfPerimeter = Perimeter() / 2;

            return Math.Sqrt(HalfPerimeter * (HalfPerimeter - distance1) * (HalfPerimeter - distance2) * (HalfPerimeter - distance3));
        }

        public double MinimalDistance(Point zero)
        {
            double distance1 = Distance(zero, _vertex1);
            double distance2 = Distance(zero, _vertex2);
            double distance3 = Distance(zero, _vertex3);

            return Math.Min(distance1, Math.Min(distance2, distance3));
        }

        public void Print()
        {
            Console.WriteLine($"Vertices of the triangle: {_vertex1}, {_vertex2}, {_vertex3}, Perimetr is {Perimeter()} and Square is {Square()} ");
        }

    }
}
