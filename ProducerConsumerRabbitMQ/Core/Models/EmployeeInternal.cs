namespace Models
{
    public class EmployeeInternal
    {
        public string Name { get; }
        public string Birthday{ get; }
        public string Profession { get; }

        public EmployeeInternal(string name, string birthday, string profession)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Profession = profession;
        }

        public override string ToString()
        {
            return "Name: " + Name + ", Birthday: " + Birthday + ", Profession: " + Profession;
        }

    }
}
