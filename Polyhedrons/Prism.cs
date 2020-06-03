namespace Polyhedrons
{
    public class Prism : Polyhedron
    {
        public Prism(Polygon @base, double height) : 
            base(@base, "Prism", height)
        {
        }

        public override double GetVolume()
        {
            return Base.GetArea() * Height;
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