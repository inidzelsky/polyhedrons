using System;

namespace Polyhedrons
{
    public class Cube : Polyhedron
    {
        public Cube(Polygon @base, double height) : 
            base(@base, "Cube", height)
        {
            ValidatePolyhedron();
        }

        public override double GetVolume()
        {
            return Math.Pow(((Square) Base).GetSide(), 3);
        }

        public override int GetApexes()
        {
            return 8;
        }

        public override int GetEdges()
        {
            return 12;
        }

        public override int GetBrinks()
        {
            return 6;
        }

        protected sealed override void ValidatePolyhedron()
        {
            if ((Base is Square) == false)
                throw new InvalidBaseFigureException("Cube can be created only from the square");
        }
    }
}