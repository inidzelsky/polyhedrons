using System.Collections.Generic;

namespace Polyhedrons
{
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
}