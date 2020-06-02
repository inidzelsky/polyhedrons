namespace Polyhedrons
{
    public class Parallelepiped : Polyhedron
    {
        private double _height;

        public Parallelepiped(Polygon @base, double height) : base(@base)
        {
            _height = height;
        }

        public override double GetVolume()
        {
            return Base.GetArea() * _height;
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

        protected override void ValidatePolyhedron()
        {
            if ((Base is Rectangle || Base is Parallelogram) == false)
                throw new InvalidBaseFigureException(
                    "Parallelepiped can be built only from rectangle or parallelogram");
        }
    }
}