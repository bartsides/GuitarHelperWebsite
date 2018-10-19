using GuitarHelperWebsite.Models;
using System.Collections.Generic;
using System.Linq;

namespace GuitarHelperWebsite.Services
{
    public class NoteService
    {
        private List<Note> notes;

        public NoteService()
        {
            LoadNotes();
        }

        public Note GetNote(string name)
        {
            return notes.First(n => n.Name == name);
        }

        public Note GetNote(int value)
        {
            while (value < 1)
                value += 12;
            return notes[(value - 1) % 12];
        }

        public List<Note> GetNotes()
        {
            return notes;
        }

        public List<Note> GetNotes(string notesCsv)
        {
            return GetNotes(notesCsv.Split(",").ToList());
        }

        public List<Note> GetNotes(List<string> notes)
        {
            return notes.Select(note => GetNote(note.Trim())).ToList();
        }

        private void LoadNotes()
        {
            int i = 1;
            notes = new List<Note>
            {
                new Note("A", i++),
                new Note("A#", i++),
                new Note("B", i++),
                new Note("C", i++),
                new Note("C#", i++),
                new Note("D", i++),
                new Note("D#", i++),
                new Note("E", i++),
                new Note("F", i++),
                new Note("F#", i++),
                new Note("G", i++),
                new Note("G#", i++),
            };
        }
    }
}
