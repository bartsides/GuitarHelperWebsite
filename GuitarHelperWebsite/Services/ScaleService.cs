using GuitarHelperWebsite.Models;
using System.Collections.Generic;
using System.Linq;

namespace GuitarHelperWebsite.Services
{
    public class ScaleService
    {
        private NoteService noteService = new NoteService();
        
        public List<Note> GetNotes(string pattern, string note)
        {
            List<Note> result = new List<Note>();
            foreach (string e in pattern.Split(',').Select(s => s.Trim()))
            {
                int mod = noteService.GetNote(note).Value;
                if (e.Contains('b'))
                    mod--;
                if (e.Contains('s'))
                    mod++;

                // Skip 1 as it is the first note and has a mod of 0.
                if (e.Contains('2'))
                    mod += 2;
                else if (e.Contains('3'))
                    mod += 4;
                else if (e.Contains('4'))
                    mod += 5;
                else if (e.Contains('5'))
                    mod += 7;
                else if (e.Contains('6'))
                    mod += 9;
                else if (e.Contains('7'))
                    mod += 11;

                result.Add(noteService.GetNote(mod));
            }

            return result;
        }
    }
}
