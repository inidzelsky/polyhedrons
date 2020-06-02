namespace Polyhedrons
{
    public class Prism : Polyhedron
    {
        private readonly double _height;

        public Prism(Polygon @base, double height) : base(@base)
        {
            _height = height;
        }

        public override double GetVolume()
        {
            return Base.GetArea() * _height;
        }

        public override int GetApexes()
        {
            return Base.GetApexes() * 2;
        }

        public override int GetEdges()
        {
            return Base.GetApexes() * 3;
        }

        public override int GetBrinks()
        {
            return Base.GetApexes() + 2;
        }
    }
}