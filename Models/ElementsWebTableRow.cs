namespace DemoQA_Automation.Models
{
    internal class ElementsWebTableRow
    {
        internal string? FirstName { get; set; }
        internal string? LastName { get; set; }
        internal int Age {  get; set; }
        internal string? Email { get; set; }
        internal long Salary { get; set; }
        internal string? Department { get; set; }

        internal ElementsWebTableRow() {}

        internal ElementsWebTableRow(string? firstName, string? lastName, int age, string? email, long salary, string? department)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Email = email;
            Salary = salary;
            Department = department;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not ElementsWebTableRow other) 
                return false;

            return FirstName == other.FirstName
                && LastName == other.LastName
                && Age == other.Age
                && Email == other.Email
                && Salary == other.Salary
                && Department == other.Department;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, Age, Email, Salary, Department);
        }
    }
}
