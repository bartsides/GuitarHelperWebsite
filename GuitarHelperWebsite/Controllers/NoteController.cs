using GuitarHelperWebsite.Models;
using GuitarHelperWebsite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GuitarHelperWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private NoteService noteService = new NoteService();

        [HttpGet]
        public IEnumerable<Note> Get()
        {
            return noteService.GetNotes();
        }
    }
}