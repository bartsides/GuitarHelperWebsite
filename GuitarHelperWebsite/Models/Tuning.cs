using System.Collections.Generic;
using System.Linq;

namespace GuitarHelperWebsite.Models
{
    public class Tuning
    {
        public string Name { get; set; }
        public List<Note> Notes { get; set; }
        public string Strings
        {
            get {
                return Notes.Select(note => note.Name)
                    .Aggregate((current, next) => current + "," + next);
            }
        }

        public Tuning (string name, List<Note> strings)
        {
            Name = name;
            Notes = strings ?? new List<Note>();
        }
    }
}
