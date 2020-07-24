namespace Models
{
    public class Employee
    {
        public string Name { get; }
        public string Birthday{ get; }
        public int Age { get; }
        public string Profession { get; }

        public Employee(string name, string birthday, int age, string profession)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Age = age;
            this.Profession = profession;
        }

        public override string ToString()
        {
            return "Name: " + Name + ", Birthday: " + Birthday + ", Age: " +  Age + ", Profession: " + Profession;
        }

    }
}
