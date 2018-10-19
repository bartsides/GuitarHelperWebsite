using GuitarHelperWebsite.Models;
using GuitarHelperWebsite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GuitarHelperWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScaleController : ControllerBase
    {
        private ScaleService scaleService = new ScaleService();

        [Route("{pattern}/{note}")]
        public IEnumerable<Note> GetNotesInScale(string pattern, string note)
        {
            return scaleService.GetNotes(pattern, note);
        }
    }
}