using GuitarHelperWebsite.Models;
using GuitarHelperWebsite.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuitarHelperWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawingController : ControllerBase
    {
        private DrawingService _drawingService = new DrawingService();

        [Route("{tuning}/{pattern}/{note}")]
        public DrawingResponse Get(string tuning, string pattern, string note)
        {
            return new DrawingResponse(_drawingService.GetDrawing(tuning, pattern, note));
        }
    }
}
