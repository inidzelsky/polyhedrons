using System.Collections.Generic;

namespace Polyhedrons
{
    public class CustomPolygon : Polygon
    {
        public CustomPolygon(List<Coords> coords) : base(coords, "Custom")
        {
        }
    }
}