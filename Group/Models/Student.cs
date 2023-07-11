namespace ca_student_management.Group.Models
{
    public class Student
    {
        private static int nextId = 1;
        private double degree;

        public int Id { get; }
        public string FullName { get; set; }

        public double Degree {
            get { return degree; }
            set
            {
                if (value >= 0 && value <= 20 )
                {
                    degree = value;
                }
                else
                {
                    throw new ArgumentException("Degree should be between 0 and 20.");
                }
            }
        }

        public Student(string fullName, double degree)
        {
            Id = nextId;
            FullName = fullName;
            Degree = degree;

            nextId += 1;
        }

        public override string ToString()
        {
            return $"{Id} - {FullName} - {degree}";
        }
    }
}
