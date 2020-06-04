using System;
using System.Collections.Generic;

namespace Polyhedrons
{
    public interface IDatabase
    {
        void SavePolygon(FigureData polygon, string name);
        void SavePolyhedron(FigureData polyhedron, string name);
        FigureData LoadPolygon(string name);
        FigureData LoadPolyhedron(string name);
        int PolygonsCount();
        int PolyhedronsCount();
        int FiguresCount();
    }
}