namespace Polyhedrons
{
    public abstract class Figure
    {
        public string Type { get; }

        public Figure(string type)
        {
            Type = type;
        }
    }
}