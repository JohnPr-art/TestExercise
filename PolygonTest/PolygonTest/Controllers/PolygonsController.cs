using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PolygonTest.Models;
using PolygonTest.Services;

namespace PolygonTest.Controllers
{


    /*[Route("api/[controller]")]
    [ApiController]*/
    [ApiController]
    [Route("[controller]")]
    public class PolygonsController : ControllerBase
    {
        private readonly IPolygonService _polyService;
        public PolygonsController(IPolygonService polyService)
        {
            _polyService = polyService;
        }

        [HttpPost("data")]
        public IActionResult ReceiveAndCheckData([FromBody] PolygonData polygonData)
        {
            bool inPoly = _polyService.InPolygon(polygonData);
            Result result = new Result
            {
                InPolygon = inPoly,
                Name = polygonData.Name
            };
            return Ok(result);
        }
    }

    
}
