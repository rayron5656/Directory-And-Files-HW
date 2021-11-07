namespace Directory_And_Files_HW
{
    public class student
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public student(string iD, string name, int age)
        {
            ID = iD;
            Name = name;
            Age = age;
        }
    }
}
