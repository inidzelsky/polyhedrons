using System;
using System.Collections.Generic;

namespace Polyhedrons
{
    public interface IDatabase
    {
        void SavePolygon(FigureData polygon, string name);
        void SavePolyhedron(FigureData polyhedron, string name);
        FigureData OpenPolygon(string name);
        FigureData OpenPolyhedron(string name);
        int PolygonsCount();
        int PolyhedronsCount();
        int FiguresCount();
    }
}