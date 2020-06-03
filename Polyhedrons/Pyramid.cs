using System;

namespace Polyhedrons
{
    public class Pyramid : Polyhedron
    {
        public Pyramid(Polygon @base, double height) : 
            base(@base, "Pyramid", height)
        {
        }

        public override double GetVolume()
        {
            return Base.GetArea() * Height / 3;
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
            if (Height <= 0)
                throw new InvalidFigureException("The pyramid top can not be equal or less than 0");
        }
    }
}