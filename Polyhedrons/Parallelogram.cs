using System;
using System.Collections.Generic;

namespace Polyhedrons
{
    public class Parallelogram : Polygon
    {
        public Parallelogram(List<Coords> coords) : base(coords)
        {
            ValidateFigure();
        }

        private double GetAngle(int i)
        {
            Index p = (i > 0) ? (i - 1) : ^1;
            Index n = (i < GetVertexes() - 1) ? (i + 1) : 0;

            Coords vec1 = new Coords(_coords[p].X - _coords[i].X, _coords[p].Y - _coords[i].Y);
            Coords vec2 = new Coords(_coords[n].X - _coords[i].X, _coords[n].Y - _coords[i].Y);

            double scalarMult = vec1.X * vec2.X + vec1.Y * vec2.Y;
            double absMult = GetLength(_coords[i], _coords[p]) * GetLength(_coords[i], _coords[p]);

            return Math.Acos(scalarMult / absMult);
        }
        
        private bool ValidateAngles()
        {
            return (Math.Abs(GetAngle(0) - GetAngle(2)) <= 0 && Math.Abs(GetAngle(1) - GetAngle(3)) <= 0);
        }

        protected sealed override void ValidateFigure()
        {
            if (GetVertexes() != 4)
                throw new InvalidVertexesCountException($"Parallelogram can not have {GetVertexes()} vertexes");

            if (!ValidateAngles())
                throw new UnknownFigureException("Parallelogram can not have 3 different sides");
        }
    }
}