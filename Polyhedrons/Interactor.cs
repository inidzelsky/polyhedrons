using System;
using System.Collections.Generic;

namespace Polyhedrons
{
    public class Interactor : IInteractor
    {
        private Figure _figure;
        private readonly IDatabase _database;

        public Interactor(IDatabase database)
        {
            _database = database;
        }

        public Figure GetFigure()
        {
            return _figure;
        }

        public void SetFigure(Figure figure)
        {
            _figure = figure;
        }

        public Polygon CreatePolygon(string type, List<Coords> coords)
        {
            try
            {
                Polygon polygon = PolygonFactory.FactoryMethod(type, coords);
                return polygon;
            }
            catch (Exception e)
            {
                Console.Clear();

                ConsoleView.ColorizeError(e.Message);

                Console.WriteLine();
                return null;
            }
        }

        public Polyhedron CreatePolyhedron(string type, Polygon polygon, double height = 0)
        {
            try
            {
                Polyhedron polyhedron = PolyhedronFactory.FactoryMethod(type, polygon, height);

                return polyhedron;
            }
            catch (Exception e)
            {
                Console.Clear();

                ConsoleView.ColorizeError(e.Message);

                Console.WriteLine();

                return null;
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

        public double GetVolume()
        {
            if (_figure is Polyhedron)
                return ((Polyhedron) _figure).GetVolume();

            throw new InvalidOperationException("Can`t find the volume of the polygon");
        }

        public bool SavePolygon(string name)
        {
            try
            {
                if (_figure is Polyhedron)
                    throw new InvalidOperationException("Can`t save polyhedron to polygons table");

                Polygon polygon = (Polygon) _figure;
                FigureData figureData = new FigureData();

                figureData.PolygonType = polygon.Type;
                figureData.Coords = polygon.GetCoords();

                _database.SavePolygon(figureData, name);

                return true;
            }
            catch (Exception e)
            {
                Console.Clear();

                ConsoleView.ColorizeError(e.Message);

                Console.WriteLine();

                return false;
            }
        }

        public bool SavePolyhedron(string name)
        {
            try
            {
                if (_figure is Polygon)
                    throw new InvalidOperationException("Can`t save polygon to polyhedrons table");

                Polyhedron polyhedron = (Polyhedron) _figure;
                FigureData figureData = new FigureData();

                figureData.PolyhedronType = polyhedron.Type;
                figureData.PolygonType = polyhedron.GetBaseFigure().Type;
                figureData.Coords = polyhedron.GetBaseFigure().GetCoords();
                figureData.Height = polyhedron.GetHeight();

                _database.SavePolyhedron(figureData, name);

                return true;
            }
            catch (Exception e)
            {
                Console.Clear();

                ConsoleView.ColorizeError(e.Message);

                Console.WriteLine();

                return false;
            }
        }

        public Polygon LoadPolygon(string name)
        {
            try
            {
                FigureData figureData = _database.LoadPolygon(name);
                return CreatePolygon(figureData.PolygonType, figureData.Coords);
            }
            catch (Exception e)
            {
                Console.Clear();

                ConsoleView.ColorizeError(e.Message);

                Console.WriteLine();

                return null;
            }
        }

        public Polyhedron LoadPolyhedron(string name)
        {
            try
            {
                FigureData figureData = _database.LoadPolyhedron(name);

                Polygon polygon = PolygonFactory.FactoryMethod(figureData.PolygonType, figureData.Coords);
                return CreatePolyhedron(figureData.PolyhedronType, polygon, figureData.Height);
            }
            catch (Exception e)
            {
                Console.Clear();

                ConsoleView.ColorizeError(e.Message);

                Console.WriteLine();

                return null;
            }
        }

        public int GetPolygonsCount()
        {
            try
            {
                return _database.PolygonsCount();
            }
            catch (Exception e)
            {
                Console.Clear();

                ConsoleView.ColorizeError(e.Message);

                Console.WriteLine();
            }

            return 0;
        }

        public int GetPolyhedronsCount()
        {
            try
            {
                return _database.PolyhedronsCount();
            }
            catch (Exception e)
            {
                Console.Clear();

                ConsoleView.ColorizeError(e.Message);

                Console.WriteLine();
            }

            return 0;
        }
    }
}