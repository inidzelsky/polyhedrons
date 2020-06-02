using System;

namespace Polyhedrons
{
    public class Pyramid : Polyhedron
    {
        private readonly Coords _top;

        public Pyramid(Polygon @base, Coords top) : base(@base)
        {
            _top = top;
        }

        public override double GetVolume()
        {
            return Base.GetArea() * _top.Z / 3;
        }

        public override int GetApexes()
        {
            return Base.GetApexes() + 1;
        }

        public override int GetEdges()
        {
            return Base.GetApexes() * 2;
        }

        public override int GetBrinks()
        {
            return Base.GetApexes() + 1;
        }

        protected override void ValidatePolyhedron()
        {
            if (Math.Abs(_top.Z) <= 0)
                throw new InvalidFigureException("The pyramid top can not be 0");
        }
    }
}