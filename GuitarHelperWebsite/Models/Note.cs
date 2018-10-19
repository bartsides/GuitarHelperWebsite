namespace GuitarHelperWebsite.Models
{
    public class Note
    {
        public string Name;
        public int Value;

        public Note(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            Note newObj = obj as Note;
            if (newObj != null)
                return Name == newObj.Name;
            return base.Equals(obj);
        }
    }
}
