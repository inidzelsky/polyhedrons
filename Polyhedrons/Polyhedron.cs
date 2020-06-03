namespace Polyhedrons
{
    public abstract class Polyhedron : Figure
    {
        protected readonly Polygon Base;
        protected readonly double Height;
        public string Type { get; }

        protected Polyhedron()
        {
        }

        protected Polyhedron(Polygon @base, string type, double height)
        {
            Base = @base;
            Type = type;
            Height = height;
        }

        public double GetBaseArea()
        {
            return Base.GetArea();
        }

        public abstract double GetVolume();

        public abstract int GetApexes();

        public abstract int GetEdges();

        public abstract int GetBrinks();

        public double GetHeight()
        {
            return Height;
        }

        public Polygon GetBaseFigure()
        {
            return Base;
        }

        protected virtual void ValidatePolyhedron()
        {
        }
    }
}