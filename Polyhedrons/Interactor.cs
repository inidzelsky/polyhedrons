using System;
using System.Collections.Generic;

namespace Polyhedrons
{
    public class Interactor : IInteractor
    {
        private Figure _figure;

        public double GetVolume()
        {
            throw new NotImplementedException();
        }

        public Figure GetFigure()
        {
            return _figure;
        }

        public void CreatePolygon(string type, List<Coords> coords)
        {
            try
            {
                Figure figure = PolygonFactory.FactoryMethod(type, coords);
                _figure = figure;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void CreatePolyhedron(string type, Polygon polygon, double height = 0)
        {
            try
            {
                Figure figure = PolyhedronFactory.FactoryMethod(type, polygon, height);
                _figure = figure;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public double GetPerimeter()
        {
            if (_figure is Polygon)
                return ((Polygon) _figure).GetPerimeter();
            
            throw new InvalidOperationException("Can`t find the perimeter of the polyhedron");
        }

        public double GetArea()
        {
            if (_figure is Polygon)
                return ((Polygon) _figure).GetArea();
            
            throw new InvalidOperationException("Can`t find the area of the polyhedron");
        }

        public int GetApexes()
        {
            if (_figure is Polygon)
                return ((Polygon) _figure).GetApexes();

            return ((Polyhedron) _figure).GetApexes();
        }

        public int GetEdges()
        {
            if (_figure is Polyhedron)
                return ((Polyhedron) _figure).GetEdges();
            
            throw new InvalidOperationException("Can`t find the edges of the polygon");
        }

        public int GetBrinks()
        {
            if (_figure is Polyhedron)
                return ((Polyhedron) _figure).GetBrinks();
            
            throw new InvalidOperationException("Can`t find the edges of the polygon");
        }

        public double GetBaseArea()
        {
            if (_figure is Polyhedron)
                return ((Polyhedron) _figure).GetBaseArea();
            
            throw new InvalidOperationException("Can`t find the area of the base figure of the polygon");
        }
    }
}