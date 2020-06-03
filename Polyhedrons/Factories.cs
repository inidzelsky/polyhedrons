using System.Collections.Generic;
using System.IO;

namespace Polyhedrons
{
    public class PolygonFactory
    {
        public static Polygon FactoryMethod(string type, List<Coords> coords)
        {
            switch (type.ToLower())
            {
                case "square":
                    return new Square(coords);

                case "rectangle":
                    return new Rectangle(coords);

                case "triangle":
                    return new Triangle(coords);

                case "parallelogram":
                    return new Parallelogram(coords);

                case "trapeze":
                    return new Trapeze(coords);

                default:
                    throw new IOException($"Invalid input. {type} figure does not exist");
            }
        }
    }
    
    public class PolyhedronFactory
    {
        public static Polyhedron FactoryMethod(string type, Polygon polygon, double height = 0)
        {
            switch (type.ToLower())
            {
                case "cube":
                    return new Cube(polygon, ((Square) polygon).GetSide());

                case "parallelepiped":
                    return new Parallelepiped(polygon, height);

                case "pyramid":
                    return new Pyramid(polygon, height);

                case "prism":
                    return new Prism(polygon, height);
                
                default:
                    throw new IOException($"Invalid input. {type} figure does not exist");
            }
        }
    }
}