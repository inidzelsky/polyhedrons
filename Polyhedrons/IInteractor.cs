using System.Collections.Generic;

namespace Polyhedrons
{
    public interface IInteractor
    {
        Polygon CreatePolygon(string type, List<Coords> coords);
        Polyhedron CreatePolyhedron(string type, Polygon polygon, double height = 0);
        double GetPerimeter();
        double GetArea();
        int GetApexes();
        int GetEdges();
        int GetBrinks();
        double GetBaseArea();
        double GetVolume();
        bool SavePolygon(string name);
        bool SavePolyhedron(string name);
        Polygon LoadPolygon(string name);
        Polyhedron LoadPolyhedron(string name);
        int GetPolygonsCount();
        int GetPolyhedronsCount();
        Figure GetFigure();
        void SetFigure(Figure figure);
    }
}