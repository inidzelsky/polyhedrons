using System;

namespace Polyhedrons
{
    public abstract class Polyhedron : Figure
    {
        protected readonly Polygon Base;
        protected readonly double Height;

        protected Polyhedron(Polygon @base, string type, double height) :
            base(type)
        {
            Base = @base;
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

    public class Pyramid : Polyhedron
    {
        public Pyramid(Polygon @base, double height) :
            base(@base, "Pyramid", height)
        {
        }

        public override double GetVolume()
        {
            return Base.GetArea() * Height / 3;
        }

        public override int GetApexes()
        {
            return Base.GetApexes() + 1;
        }

        public override int GetEdges()
        {
            return Base.GetApexes() * 2;
        }

        public override int GetBrinks()
        {
            return Base.GetApexes() + 1;
        }

        protected override void ValidatePolyhedron()
        {
            if (Height <= 0)
                throw new InvalidFigureException("The pyramid top can not be equal or less than 0");
        }
    }
}