using System;
using System.Collections.Generic;

namespace Polyhedrons
{
    public class Rectangle : Polygon
    {
        public Rectangle(List<Coords> coords) : base(coords)
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
}