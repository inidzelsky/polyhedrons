using System;
using System.Collections.Generic;

namespace Polyhedrons
{
    public class InvalidCoordsOrderException : Exception
    {
        public InvalidCoordsOrderException(string message) :
            base(message)
        {
        }
    }

    public class InvalidVertexesCountException : Exception
    {
        public InvalidVertexesCountException(string message) :
            base(message)
        {
        }
    }

    public class UnknownFigureException : Exception
    {
        public UnknownFigureException(string message) :
            base(message)
        {
        }
    }

    public abstract class Polygon
    {
        protected List<Coords> _coords;
        
        public Polygon(List<Coords> coords)
        {
            _coords = coords;
        }

        public double GetPerimeter() // #TODO Handle 0 - 1 vertexes exception
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

        private void ValidateArea(double square)
        {
            if (square < 0)
                throw new InvalidCoordsOrderException("Coords were set in an inappropriate way");
        }

        public double GetArea() // #TODO Handle 0 - 2 vertexes exception
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

            ValidateArea(square);
            return square;
        }

        public int GetVertexes() // #TODO Handle 0 vertexes exception
        {
            return _coords.Count;
        }

        public List<Coords> GetCoords()
        {
            return _coords;
        }

        protected double GetLength(Coords c1, Coords c2)
        {
            return Math.Sqrt(Math.Pow(c1.X - c2.X, 2) + Math.Pow(c1.Y - c2.Y, 2));
        }

        protected virtual void ValidateFigure()
        {
        }
    }
}