namespace Polyhedrons
{
    public class Coords
    {
        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public Coords(double x, double y, double z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}