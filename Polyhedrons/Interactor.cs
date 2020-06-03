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
        
        public double GetVolume()
        {
            if (_figure is Polyhedron)
                return ((Polyhedron) _figure).GetVolume();
            
            throw new InvalidOperationException("Can`t find the volume of the polygon");
        }

        public void SavePolygon(string name)
        {
            if (_figure is Polyhedron)
                throw new InvalidOperationException("Can`t save polyhedron to polygons table");

            Polygon polygon = (Polygon) _figure;
            FigureData figureData = new FigureData();
            
            figureData.PolygonType = polygon.Type;
            figureData.Coords = polygon.GetCoords();
            
            _database.SavePolygon(figureData, name);
        }

        public void SavePolyhedron(string name)
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
        }

        public void OpenPolygon(string name)
        {
            try
            {
                FigureData figureData = _database.OpenPolygon(name);
                CreatePolygon(figureData.PolygonType, figureData.Coords);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void OpenPolyhedron(string name)
        {
            try
            {
                FigureData figureData = _database.OpenPolygon(name);
            
                Polygon polygon = PolygonFactory.FactoryMethod(figureData.PolygonType, figureData.Coords);
                CreatePolyhedron(figureData.PolyhedronType, polygon, figureData.Height);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public int GetPolygonsCount()
        {
            return _database.PolygonsCount();
        }
        
        public int GetPolyhedronsCount()
        {
            return _database.PolyhedronsCount();
        }
    }
}