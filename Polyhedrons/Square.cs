using System;
using System.Collections.Generic;

namespace Polyhedrons
{
    public class Square : Polygon
    {
        public Square(List<Coords> coords) :
            base(coords)
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
}