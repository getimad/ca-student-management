﻿using Grp = ca_student_management.Group.Group;
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
                        Search();
                        break;
                    case "6":
                        goto Found;
                    default:
                        Console.WriteLine("Wrong input, please enter an option between 1-5.");
                        break;
                }
            }

            Found: Console.WriteLine("Goodbye :)");
        }

        private static void Header()
        {
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("| WELCOME TO STUDENT MANAGRMENT |");
            Console.WriteLine("+-------------------------------+");
        }

        private static void Menu()
        {
            Console.WriteLine("+------------ Menu -------------+");
            Console.WriteLine("1. Show");
            Console.WriteLine("2. Add");
            Console.WriteLine("3. Modify");
            Console.WriteLine("4. Delete");
            Console.WriteLine("5. Search");
            Console.WriteLine("6. Exist");
            Console.WriteLine("+-------------------------------+");
        }

        private static void Show()
        {
            if (Students.Count() != 0)
            {
                for (int i = 0; i < Students.Count(); i++)
                    Console.WriteLine(Students[i]);
            }

            else
                Console.WriteLine("The group is empty.");
        }

        private static void Insert()
        {
            Console.Write("  Full Name: ");
            var fullName = Console.ReadLine() ?? "Person";

            Console.Write("  Degree: ");
            var degree = Convert.ToDouble(Console.ReadLine());

            var std = new Std(fullName, degree);
            Students.Insert(std);

            Console.WriteLine("The Student is inserted succesfuly.");
        }

        private static void Update()
        {
            Console.Write("  Enter the student's id: ");
            var stdId = Convert.ToInt32(Console.ReadLine());

            Console.Write("  Full Name: ");
            var fullName = Console.ReadLine() ?? "Person";

            Console.Write("  Degree: ");
            var degree = Convert.ToDouble(Console.ReadLine());

            var std = new Std(fullName, degree);
            Students.Update(stdId, std);

            Console.WriteLine("The student is updated succesfuly.");
        }

        private static void Delete()
        {
            Console.Write("  Enter the student's id: ");
            var stdId = Convert.ToInt32(Console.ReadLine());

            Students.Delete(stdId);

            Console.WriteLine("The student is deleted succesfuly.");
        }

        private static void Search()
        {
            Console.Write("  Search for a student by its name: ");
            var input = Console.ReadLine() ?? "";

            var result = Students.Search(input);

            if (result.Count != 0)
                Array.ForEach(result.ToArray(), Console.WriteLine);
            else
                Console.WriteLine("Not Found.");
        }
    }
}