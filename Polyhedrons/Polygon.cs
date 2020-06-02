using System;
using System.Collections.Generic;

namespace Polyhedrons
{
    public abstract class Polygon : Figure
    {
        protected readonly List<Coords> Coords;

        protected Polygon(List<Coords> coords)
        {
            Coords = coords;
        }

        public double GetPerimeter() // #TODO Handle 0 - 1 vertexes exception
        {
            double perimeter = 0;
            int coordsCount = Coords.Count;

            if (coordsCount < 2)
                return perimeter;

            for (int i = 0; i < coordsCount - 1; i++)
            {
                perimeter += GetLength(Coords[i], Coords[i + 1]);
            }

            perimeter += GetLength(Coords[coordsCount - 1], Coords[0]);

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
            int coordsCount = Coords.Count;

            if (coordsCount < 3)
                return square;

            for (int i = 0; i < coordsCount - 1; i++)
            {
                square += Coords[i].X * Coords[i + 1].Y;
                square -= Coords[i].Y * Coords[i + 1].X;
            }

            square += Coords[coordsCount - 1].X * Coords[0].Y;
            square -= Coords[coordsCount - 1].Y * Coords[0].X;
            square /= 2;

            ValidateArea(square);
            return square;
        }

        public int GetApexes() // #TODO Handle 0 vertexes exception
        {
            return Coords.Count;
        }

        public List<Coords> GetCoords()
        {
            return Coords;
        }

        protected double GetLength(Coords c1, Coords c2)
        {
            return Math.Sqrt(Math.Pow(c1.X - c2.X, 2) + Math.Pow(c1.Y - c2.Y, 2));
        }

        protected virtual void ValidatePolygon()
        {
        }
    }
}