using System;
using System.Collections.Generic;

namespace Polyhedrons
{
    public abstract class Polygon : Figure
    {
        protected readonly List<Coords> Coords;

        protected Polygon(List<Coords> coords, string type) :
            base(type)
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

    public class Square : Polygon
    {
        public Square(List<Coords> coords) :
            base(coords, "Square")
        {
            ValidatePolygon();
        }

        public double GetSide()
        {
            return GetLength(Coords[0], Coords[1]);
        }

        private bool ValidateSides()
        {
            int coordsCount = Coords.Count;
            double side = GetLength(Coords[^1], Coords[0]);

            for (int i = 0; i < coordsCount - 1; i++)
            {
                double testSide = GetLength(Coords[i], Coords[i + 1]);

                if (Math.Abs(testSide - side) > 0)
                    return false;
            }

            return true;
        }

        protected sealed override void ValidatePolygon()
        {
            if (GetApexes() != 4)
                throw new InvalidVertexesCountException($"Square can not have {GetApexes()} vertexes");

            if (!ValidateSides())
                throw new InvalidFigureException("Square can not have different sides");
        }
    }

    public class Trapeze : Polygon
    {
        public Trapeze(List<Coords> coords) :
            base(coords, "Trapeze")
        {
            ValidatePolygon();
        }

        private double GetAngleCoef(int i)
        {
            Index n = (i < GetApexes() - 1) ? (i + 1) : 0;

            return Math.Abs((Coords[n].Y - Coords[i].Y) / (Coords[n].X - Coords[i].X));
        }

        private bool ValidateSides()
        {
            return (Math.Abs(GetAngleCoef(0) - GetAngleCoef(2)) <= 0) ^
                   (Math.Abs(GetAngleCoef(1) - GetAngleCoef(3)) <= 0);
        }

        protected sealed override void ValidatePolygon()
        {
            if (GetApexes() != 4)
                throw new InvalidVertexesCountException($"Trapeze can not have {GetApexes()} vertexes");

            if (!ValidateSides())
                throw new InvalidFigureException("Trapeze must have 2 parallel sides");
        }
    }

    public class Triangle : Polygon
    {
        public Triangle(List<Coords> coords) :
            base(coords, "Triangle")
        {
            ValidatePolygon();
        }

        private bool ValidateSides()
        {
            int coordsCount = Coords.Count;

            double sideX = GetLength(Coords[0], Coords[1]);
            double sideY = GetLength(Coords[1], Coords[^1]);
            double sideZ = GetLength(Coords[^1], Coords[0]);

            return (sideX + sideY > sideZ) && (sideY + sideZ > sideX) && (sideX + sideZ > sideY);
        }

        protected sealed override void ValidatePolygon()
        {
            if (GetApexes() != 3)
                throw new InvalidVertexesCountException($"Triangle can not have {GetApexes()} vertexes");

            if (!ValidateSides())
                throw new InvalidFigureException("Two triangle sides can not be less then the third one");
        }
    }

    public class Rectangle : Polygon
    {
        public Rectangle(List<Coords> coords) : base(coords, "Rectangle")
        {
            ValidatePolygon();
        }

        private double GetAngle(int i)
        {
            Index p = (i > 0) ? (i - 1) : ^1;
            Index n = (i < GetApexes() - 1) ? (i + 1) : 0;

            Coords vec1 = new Coords(Coords[p].X - Coords[i].X, Coords[p].Y - Coords[i].Y);
            Coords vec2 = new Coords(Coords[n].X - Coords[i].X, Coords[n].Y - Coords[i].Y);

            double scalarMult = vec1.X * vec2.X + vec1.Y * vec2.Y;
            double absMult = GetLength(Coords[i], Coords[p]) * GetLength(Coords[i], Coords[p]);

            return Math.Acos(scalarMult / absMult);
        }

        private bool ValidateAngles()
        {
            return ((Math.Abs(GetAngle(0) - GetAngle(1)) <= 0) &&
                    (Math.Abs(GetAngle(2) - GetAngle(3)) <= 0) &&
                    (Math.Abs(GetAngle(0) - GetAngle(2)) <= 0));
        }

        protected sealed override void ValidatePolygon()
        {
            if (GetApexes() != 4)
                throw new InvalidVertexesCountException($"Rectangle can not have {GetApexes()} vertexes");

            if (!ValidateAngles())
                throw new InvalidFigureException("Rectangle can not have different angles");
        }
    }

    public class Parallelogram : Polygon
    {
        public Parallelogram(List<Coords> coords) : base(coords, "Parallelogram")
        {
            ValidatePolygon();
        }

        private double GetAngle(int i)
        {
            Index p = (i > 0) ? (i - 1) : ^1;
            Index n = (i < GetApexes() - 1) ? (i + 1) : 0;

            Coords vec1 = new Coords(Coords[p].X - Coords[i].X, Coords[p].Y - Coords[i].Y);
            Coords vec2 = new Coords(Coords[n].X - Coords[i].X, Coords[n].Y - Coords[i].Y);

            double scalarMult = vec1.X * vec2.X + vec1.Y * vec2.Y;
            double absMult = GetLength(Coords[i], Coords[p]) * GetLength(Coords[i], Coords[p]);

            return Math.Acos(scalarMult / absMult);
        }

        private bool ValidateAngles()
        {
            return (Math.Abs(GetAngle(0) - GetAngle(2)) <= 0 && Math.Abs(GetAngle(1) - GetAngle(3)) <= 0);
        }

        protected sealed override void ValidatePolygon()
        {
            if (GetApexes() != 4)
                throw new InvalidVertexesCountException($"Parallelogram can not have {GetApexes()} vertexes");

            if (!ValidateAngles())
                throw new InvalidFigureException("Parallelogram can not have 3 different sides");
        }
    }

    public class CustomPolygon : Polygon
    {
        public CustomPolygon(List<Coords> coords) : base(coords, "Custom")
        {
        }
    }
}