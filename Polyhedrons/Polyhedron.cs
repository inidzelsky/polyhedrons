namespace Polyhedrons
{
    public class Prism : Polyhedron
    {
        
        public override double GetVolume()
        {
            throw new System.NotImplementedException();
        }

        public override int GetApexes()
        {
            throw new System.NotImplementedException();
        }

        public override int GetEdges()
        {
            throw new System.NotImplementedException();
        }

        public override int GetBrinks()
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class Cube : Polyhedron
    {
        
    }

    public class Parallelepiped : Polyhedron
    {
        
    }

    public class Pyramid : Polyhedron
    {
        
    }
    
    public abstract class Polyhedron
    {
        private Polygon _base;

        public double GetBaseArea()
        {
            return _base.GetArea();
        }

        public abstract double GetVolume();

        public abstract int GetApexes();

        public abstract int GetEdges();

        public abstract int GetBrinks();
        
    }
}