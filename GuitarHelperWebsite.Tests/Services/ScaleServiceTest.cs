using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using GuitarHelperWebsite.Models;
using GuitarHelperWebsite.Services;

namespace GuitarHelperWebsite.Tests.Services
{
    [TestFixture]
    public class ScaleServiceTest
    {
        private ScaleService scaleService;

        public ScaleServiceTest()
        {
            scaleService = new ScaleService();
        }

        [Test]
        public void whenGivenPatternWithSpaces_returnCorrectNotes()
        {
            List<Note> notes = scaleService.GetNotes("1, 2b,3 ,6,7s", "C");
            List<string> expectedNoteNames = new List<string> { "C", "C#", "E", "A", "C" };
            Assert.AreEqual(notes.Select(n => n.Name), expectedNoteNames);
        }
    }
}
