using System.Collections.Generic;

namespace Polyhedrons
{
    public class FigureData
    {
        public List<Coords> Coords { get; set; }
        public string PolygonType { get; set; }
        public string PolyhedronType { get; set; }
        public double Height { get; set; }

        public static Dictionary<string, double[]> GetArraysFromCoords(List<Coords> coords)
        {
            List<double> xCoords = new List<double>();
            List<double> yCoords = new List<double>();

            foreach (var item in coords)
            {
                xCoords.Add(item.X);
                yCoords.Add(item.Y);
            }

            return new Dictionary<string, double[]>
            {
                {"xCoords", xCoords.ToArray()},
                {"yCoords", yCoords.ToArray()}
            };
        }

        public static List<Coords> GetCoordsFromArrays(double[] xCoords, double[] yCoords)
        {
            List<Coords> coords = new List<Coords>();

            for (int i = 0; i < xCoords.Length; i++)
            {
                coords.Add(new Coords(xCoords[i], yCoords[i]));
            }

            return coords;
        }
    }
}