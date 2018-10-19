using GuitarHelperWebsite.Models;
using System.Collections.Generic;
using System.Linq;

namespace GuitarHelperWebsite.Services
{
    public class TuningService
    {
        private List<Tuning> tunings;
        private NoteService noteService = new NoteService();

        public TuningService()
        {
            LoadTunings();
        }

        public List<Tuning> GetTunings()
        {
            return tunings;
        }

        public Tuning GetTuning(string notesCsv)
        {
            List<Note> notes = noteService.GetNotes(notesCsv);
            return tunings.First(tuning => tuning.Notes.SequenceEqual(notes));
        }

        private void LoadTunings()
        {
            tunings = new List<Tuning>
            {
                new Tuning("Standard", noteService.GetNotes("E,A,D,G,B,E")),
                new Tuning("Drop D", noteService.GetNotes("D,A,D,G,B,E")),
                new Tuning("Bass", noteService.GetNotes("E,A,D,G"))
            };
        }
    }
}
