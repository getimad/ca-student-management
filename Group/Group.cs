﻿using Std = ca_student_management.Group.Models.Student;

namespace ca_student_management.Group
{
    public class Group
    {
        private readonly List<Std> students;

        public Group()
        {
            students = [];
        }

        public Std this[int index]
        {
            get
            {
                if (index >= 0 && index < students.Count)
                    return students[index];

                else
                    throw new IndexOutOfRangeException();
            }

            set
            {
                if (index >= 0 && index < students.Count)
                    students[index] = value;

                else
                    throw new IndexOutOfRangeException();
            }
        }

        public int Count()
            => students.Count;

        public int IsExists(int id)
        {
            for (int i = 0; i < students.Count; i++)
                if (students[i].Id == id)
                    return i;

            return -1;
        }

        public void Insert(Std std)
            => students.Add(std);

        public void Delete(int id)
        {
            int index = IsExists(id);

            if (index == -1)
                throw new KeyNotFoundException();

            students.RemoveAt(index);
        }

        public void Update(int id, Std std)
        {
            int index = IsExists(id);

            if (index == -1)
                throw new KeyNotFoundException();

            students[index] = std;
        }

        public List<Std> Search(string input)
        {
            var list = new List<Std>();

            for (int i = 0; i < students.Count; i++)
                if (students[i].FullName.Contains(input))
                    list.Add(students[i]);

            return list;
        }
    }
}
