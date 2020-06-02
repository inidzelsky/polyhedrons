namespace Polyhedrons
{
    public abstract class Polyhedron : Figure
    {
        protected readonly Polygon Base;

        protected Polyhedron(Polygon @base)
        {
            Base = @base;
        }

        public double GetBaseArea()
        {
            return Base.GetArea();
        }

        public abstract double GetVolume();

        public abstract int GetApexes();

        public abstract int GetEdges();

        public abstract int GetBrinks();

        protected virtual void ValidatePolyhedron()
        {
        }
    }
}