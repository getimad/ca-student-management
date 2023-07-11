using Grp = ca_student_management.Group.Group;
using Std = ca_student_management.Group.Models.Student;


namespace ca_student_management
{
    internal class Program
    {
        private static Grp Students { get; set; } = new Grp();

        static void Main(string[] args)
        {
            Header();

            while (true)
            {
                Menu();

                Console.Write("> Choose an option: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Show();
                        break;
                    case "2":
                        Insert();
                        break;
                    case "3":
                        Update();
                        break;
                    case "4":
                        Delete();
                        break;
                    case "5":
                        Console.WriteLine("Goodbye :)");
                        break;
                    default:
                        Console.WriteLine("Wrong input, please enter an option between 1-5.");
                        break;
                }
            }
        }

        private static void Header()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("| WELCOME TO STUDENT MANAGRMENT |");
            Console.WriteLine("---------------------------------");
        }

        private static void Menu()
        {
            Console.WriteLine("------------- Menu --------------");
            Console.WriteLine("1. Show interns.");
            Console.WriteLine("2. Add an intern.");
            Console.WriteLine("3. Modify an intern.");
            Console.WriteLine("4. Delete an intern.");
            Console.WriteLine("5. Exist.");
        }

        private static void Show()
        {
            for (int i = 0; i < Students.Count(); i++)
            {
                Console.WriteLine(Students[i]);
            }
        }

        private static void Insert()
        {
            Console.Write("  Full Name: ");
            var fullName = Console.ReadLine();

            Console.Write("  Degree: ");
            var degree = Convert.ToDouble(Console.ReadLine());

            var std = new Std(fullName, degree);
            Students.Insert(std);

            Console.WriteLine("The Student is inserted succesfuly.");
        }

        private static void Update()
        {
            Console.Write("  Enter the student's id you want to update:");
            var stdId = Convert.ToInt32(Console.ReadLine());

            Console.Write("  Full Name: ");
            var fullName = Console.ReadLine();

            Console.Write("  Degree: ");
            var degree = Convert.ToDouble(Console.ReadLine());

            var std = new Std(fullName, degree);
            Students.Update(stdId, std);

            Console.WriteLine("The student is updated succesfuly.");
        }

        private static void Delete()
        {
            Console.Write("  Enter the student's id you want to delete:");
            var stdId = Convert.ToInt32(Console.ReadLine());

            Students.Delete(stdId);

            Console.WriteLine("The student is deleted succesfuly.");
        }
    }
}