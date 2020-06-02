using System.Collections.Generic;

namespace Polyhedrons
{
    public interface IInteractor
    {
        void CreatePolygon(string type, List<Coords> coords);
        void CreatePolyhedron(string type, Polygon polygon, double height = 0);
        double GetPerimeter();
        double GetArea();
        int GetApexes();
        int GetEdges();
        int GetBrinks();
        double GetBaseArea();
        double GetVolume();
        Figure GetFigure();
    }
}