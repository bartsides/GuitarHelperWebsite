using GuitarHelperWebsite.Models;
using GuitarHelperWebsite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GuitarHelperWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuningController : ControllerBase
    {
        private TuningService tuningService = new TuningService();

        // GET: api/Tuning
        [HttpGet]
        public IEnumerable<Tuning> Get()
        {
            return tuningService.GetTunings();
        }
    }
}
