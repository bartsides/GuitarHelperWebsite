using GuitarHelperWebsite.Models;
using GuitarHelperWebsite.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GuitarHelperWebsite.Tests.Services
{
    [TestFixture]
    public class NoteServiceTest
    {
        private readonly NoteService noteService;

        public NoteServiceTest()
        {
            noteService = new NoteService();
        }

        [Test]
        public void whenAllNotesRequested_return12Notes()
        {
            Assert.AreEqual(noteService.GetNotes().Count(), 12);
        }

        [Test]
        public void whenGivenName_returnNoteWithSameName()
        {
            Assert.AreEqual(noteService.GetNote("D#").Name, "D#");
        }

        [Test]
        public void whenGivenNegativeNumber_returnCorrectNote()
        {
            Assert.AreEqual(noteService.GetNote(-11), noteService.GetNote("A"));
        }

        [Test]
        public void whenGivenNumberGreaterThan12_returnCorrectNote()
        {
            Assert.AreEqual(noteService.GetNote(146), noteService.GetNote("A#"));
        }

        [Test]
        public void whenGivenListOfNoteNames_returnRequestedNotesInOrder()
        {
            List<string> requestedNoteNames = new List<string> { "A", "D", "F#", "G" };
            List<Note> notes = noteService.GetNotes(requestedNoteNames);
            Assert.AreEqual(notes.Select(n => n.Name), requestedNoteNames);
        }

        [Test]
        public void whenGivenCsvOfNoteNames_returnRequestedNotesInOrder()
        {
            List<string> requestedNoteNames = new List<string> { "B", "C", "C#", "E", "F", "G#" };
            List<Note> notes = noteService.GetNotes(requestedNoteNames.Aggregate((current, next) => current + ", " + next));
            Assert.AreEqual(notes.Select(n => n.Name), requestedNoteNames);
        }
    }
}
