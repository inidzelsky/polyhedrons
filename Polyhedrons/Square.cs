using System;
using System.Collections.Generic;

namespace Polyhedrons
{
    public class Square : Polygon
    {
        public Square(List<Coords> coords) :
            base(coords)
        {
            ValidateFigure();
        }

        private bool ValidateSides()
        {
            int coordsCount = _coords.Count;
            double side = GetLength(_coords[^1], _coords[0]);

            for (int i = 0; i < coordsCount - 1; i++)
            {
                double testSide = GetLength(_coords[i], _coords[i + 1]);
                
                if (Math.Abs(testSide - side) > 0)
                    return false;
            }

            return true;
        }
        
        protected sealed override void ValidateFigure()
        {
            if (GetVertexes() != 4)
                throw new InvalidVertexesCountException($"Square can not have {GetVertexes()} vertexes");
            
            if (!ValidateSides())
                throw new UnknownFigureException("Square can not have different sides");
        }
    }
}