using GuitarHelperWebsite.Models;
using GuitarHelperWebsite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace GuitarHelperWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawingController : ControllerBase
    {
        private DrawingService drawingService = new DrawingService();

        [Route("{tuning}")]
        public DrawingResponse Get(string tuning)
        {
            return new DrawingResponse(drawingService.GetDrawing(tuning));
        }

        [Route("{tuning}/{pattern}/{note}")]
        public DrawingResponse Get(string tuning, string pattern, string note)
        {
            return new DrawingResponse(drawingService.GetDrawing(tuning, pattern, note));
        }

        [Route("Coordinate/{tuning}/{x}/{y}")]
        public Point? GetFretLocation(string tuning, int x, int y)
        {
            return drawingService.GetFretClicked(tuning, x, y);
        }
    }
}
