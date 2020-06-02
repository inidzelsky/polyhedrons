using System;
using System.Collections.Generic;

namespace Polyhedrons
{
    public class Trapeze : Polygon
    {
        public Trapeze(List<Coords> coords) : base(coords)
        {
            ValidateFigure();
        }

        private double GetAngleCoef(int i)
        {
            Index n = (i < GetVertexes() - 1) ? (i + 1) : 0;

            return Math.Abs((_coords[n].Y - _coords[i].Y) / (_coords[n].X - _coords[i].X));
        }
        
        private bool ValidateSides()
        {
            return (Math.Abs(GetAngleCoef(0) - GetAngleCoef(2)) <= 0) ^
                   (Math.Abs(GetAngleCoef(1) - GetAngleCoef(3)) <= 0);
        }
        
        protected sealed override void ValidateFigure()
        {
            if (GetVertexes() != 4)
                throw new InvalidVertexesCountException($"Trapeze can not have {GetVertexes()} vertexes");
            
            if (!ValidateSides())
                throw new UnknownFigureException("Trapeze must have 2 parallel sides");
        }
    }
}