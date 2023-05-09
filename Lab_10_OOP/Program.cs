using System;
using System.Drawing;
using System.Runtime.Serialization.Json;

namespace Lab_10_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point Zero = new Point(0, 0);

            List<Triangle> triangleList = new List<Triangle>
            {
                new Triangle(new Point(0, 0), new Point(2, 4), new Point(4, 0)),
                new Triangle(new Point(9, 0), new Point(0, 4), new Point(2, 0)),
                new Triangle(new Point(4, 7), new Point(2, 6), new Point(1, 0)),

            };
            foreach (Triangle triangle in triangleList)
            {
                triangle.Print();
                Console.WriteLine();
            }

            Triangle closestTriangle = triangleList[0];
            double closestDistance = closestTriangle.MinimalDistance(Zero);

            foreach (Triangle triangle in triangleList)
            {
                double distance = triangle.MinimalDistance(Zero);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTriangle = triangle;
                }
            }

            Console.WriteLine("Triangle closest to (0, 0):");
            closestTriangle.Print();

            Console.WriteLine();
            Console.WriteLine();


            Stream file = new FileStream("Triangle.json", FileMode.Create);
            DataContractJsonSerializer ser = new
                                           DataContractJsonSerializer(typeof(List<Triangle>));
            ser.WriteObject(file, triangleList);



            Console.WriteLine("After serialization: ");
            file.Position = 0;
            List<Triangle> triangleList1 = (List<Triangle>)ser.ReadObject(file);
            foreach (Triangle triangles in triangleList1)
            {
                triangles.Print();
                Console.WriteLine();
            }

        }
    }
}