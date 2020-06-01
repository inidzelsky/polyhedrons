using System;
using System.Collections.Generic;

namespace Polyhedrons
{
    public class Polygon
    {
        private List<Coords> _coords;

        public Polygon(List<Coords> coords)
        {
            _coords = coords;
        }

        public virtual double GetPerimeter()
        {
            double perimeter = 0;
            int coordsCount = _coords.Count;

            if (coordsCount < 2)
                return perimeter;
            
            for (int i = 0; i < coordsCount - 1; i++)
            {
                perimeter += GetLength(_coords[i], _coords[i + 1]);
            }

            perimeter += GetLength(_coords[coordsCount - 1], _coords[0]);
            
            return perimeter;
        }

        public double GetSquare()
        {
            double square = 0;
            int coordsCount = _coords.Count;

            if (coordsCount < 3)
                return square;

            for (int i = 0; i < coordsCount - 1; i++)
            {
                square += _coords[i].X * _coords[i + 1].Y;
                square -= _coords[i].Y * _coords[i + 1].X;
            }

            square += _coords[coordsCount - 1].X * _coords[0].Y;
            square -= _coords[coordsCount - 1].Y * _coords[0].X;

            return square / 2;
        }
        
        public virtual int GetVertexes()
        {
            return _coords.Count;
        }

        public List<Coords> GetCoords()
        {
            return _coords;
        }

        private double GetLength(Coords c1, Coords c2)
        {
            return Math.Sqrt(Math.Pow(c1.X - c2.X, 2) + Math.Pow(c1.Y - c2.Y, 2));
        }
    }
}