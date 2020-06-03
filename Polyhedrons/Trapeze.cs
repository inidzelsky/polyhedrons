using System;
using System.Collections.Generic;

namespace Polyhedrons
{
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
}