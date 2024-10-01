using System;
using Xunit;

using PolygonTest.Models;
using PolygonTest.Services;

namespace TestProjectPolygonTest
{
    public class UnitTest1
    {
        private readonly IPolygonService _polygonService;
        private readonly Point[] _polygonPoints;

        public UnitTest1()
        {
            _polygonService = new PolygonService();
            _polygonPoints = new Point[]
            {
                new Point{ X=200, Y=200 },
                new Point{ X=200, Y=400 },
                new Point{ X=400, Y=400 },
                new Point{ X=400, Y=200 }
                
            };
        }
        
        
        [Theory]
        [InlineData(250, 250)]
        [InlineData(300, 300)]
        [InlineData(350, 350)]
        [InlineData(220, 370)]
        

        public void PointIn(double x, double y)
        {
            PolygonData data = new PolygonData
            {
                Polygon = _polygonPoints,
                Point = new Point { X = x, Y = y }
            };
            bool result = _polygonService.InPolygon(data);
            Assert.True(result);
        }
        
        
        [Theory]
        [InlineData(20, 150)]
        [InlineData(150, 80)]
        [InlineData(450, 100)]
        [InlineData(250,411)]
        
        public void PointOut(double x, double y)
        {
            PolygonData data = new PolygonData
            {
                Polygon = _polygonPoints,
                Point = new Point { X = x, Y = y }
            };
            bool result = _polygonService.InPolygon(data);
            Assert.False(result);
        }

    }
    
}
