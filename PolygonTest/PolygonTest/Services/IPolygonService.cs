using PolygonTest.Models;

namespace PolygonTest.Services
{
    public interface IPolygonService
    {
        bool InPolygon(PolygonData data);
    }
}
