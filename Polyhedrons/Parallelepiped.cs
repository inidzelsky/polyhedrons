namespace Polyhedrons
{
    public class Parallelepiped : Polyhedron
    {
        public Parallelepiped(Polygon @base, double height) : 
            base(@base, "Parallelepiped", height)
        {
            ValidatePolyhedron();
        }

        public override double GetVolume()
        {
            return Base.GetArea() * Height;
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
            if ((Base is Rectangle || Base is Parallelogram) == false)
                throw new InvalidBaseFigureException(
                    "Parallelepiped can be built only from rectangle or parallelogram");
        }
    }
}