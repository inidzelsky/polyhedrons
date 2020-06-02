using System.Collections.Generic;

namespace Polyhedrons
{
    public class Triangle : Polygon
    {
        public Triangle(List<Coords> coords) : base(coords)
        {
            ValidateFigure();
        }

        private bool ValidateSides()
        {
            int coordsCount = _coords.Count;

            double sideX = GetLength(_coords[0], _coords[1]);
            double sideY = GetLength(_coords[1], _coords[^1]);
            double sideZ = GetLength(_coords[^1], _coords[0]);

            return (sideX + sideY > sideZ) && (sideY + sideZ > sideX) && (sideX + sideZ > sideY);
        }

        protected sealed override void ValidateFigure()
        {
            if (GetVertexes() != 3)
                throw new InvalidVertexesCountException($"Triangle can not have {GetVertexes()} vertexes");

            if (!ValidateSides())
                throw new UnknownFigureException("Two triangle sides can not be less then the third one");
        }
    }
}