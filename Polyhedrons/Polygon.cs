using System;
using System.Collections.Generic;
using System.Net;

namespace Polyhedrons
{
    public class InvalidCoordsOrderException : Exception
    {
        public InvalidCoordsOrderException(string message) :
            base(message)
        {
        }
    }

    public class Polygon
    {
        private List<Coords> _coords;

        public Polygon(List<Coords> coords)
        {
            _coords = coords;
        }

        public virtual double GetPerimeter() // #TODO Handle 0 - 1 vertexes exception
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

        public double GetSquare() // #TODO Handle 0 - 2 vertexes exception
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
            square /= 2;

            ValidateSquare(square);
            return square;
        }


        public virtual int GetVertexes() // #TODO Handle 0 vertexes exception
        {
            return _coords.Count;
        }

        public List<Coords> GetCoords()
        {
            return _coords;
        }

        private void ValidateSquare(double square)
        {
            if (square < 0)
                throw new InvalidCoordsOrderException("Coords were set in an inappropriate way");
        }

        private double GetLength(Coords c1, Coords c2)
        {
            return Math.Sqrt(Math.Pow(c1.X - c2.X, 2) + Math.Pow(c1.Y - c2.Y, 2));
        }
    }
}