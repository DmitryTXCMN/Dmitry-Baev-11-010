using System;
using System.Collections.Generic;
using System.Text;

namespace lister
{
    class Student
    {
        public int SumRating(Student stud)
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum += stud.Rating[i];
            }
            return sum;
        }

        public Student FindBestStudent(LinkedList<Student> students, int group)
        {
            List<Student> grop = new List<Student>();
            foreach (Student stud in students)
                if (stud.Group == group)
                    grop.Add(stud);
            return Best(grop);
        }

        public double FindAverageRating(LinkedList<Student> students, int group)
        {
            List<Student> grop = new List<Student>();
            foreach (Student stud in students)
                if (stud.Group == group)
                    grop.Add(stud);
            return Average(grop);
        }

        public Student Best(List<Student> group)
        {
            Student best = new Student("", 0, 0, 0, new int[] { 0, 0, 0, 0, 0 });
            foreach (Student stud in group)
                if (SumRating(stud) > SumRating(best))
                    best = stud;
            return best;
        }

        public double Average(List<Student> group)
        {
            double sum = 0;
            foreach (Student stud in group)
                sum += (double)SumRating(stud) / 5;
            return sum / group.Count;
        }

        public LinkedList<Student> Sort(LinkedList<Student> groups)
        {
            LinkedListNode<Student> now = groups.First;
            LinkedList<Student> sorted = new LinkedList<Student>();
            sorted.AddLast(new Student("temp", 0, 0, 0, new int[] { 0, 0, 0, 0, 0 }));
            while (now != null)
            {
                LinkedListNode<Student> nowSort = sorted.First;
                while (now.Value.Class > nowSort.Value.Class && now.Next != null)
                    nowSort = nowSort.Next;
                if (now.Value.Class == nowSort.Value.Class)
                    while (now.Value.Name[0] > nowSort.Value.Name[0]/*ФИО*/&& now.Next != null)
                        nowSort = nowSort.Next;
                sorted.AddAfter(nowSort, now.Value);
            }
            return sorted;
        }
        public Student FindOldestStudent(LinkedList<Student> students)
        {

            LinkedListNode<Student> now = students.First;
            Student oldest = new Student("temp", 0, 0, 0, new int[] { 0, 0, 0, 0, 0 });
            while (now != null)
            {
                if (now.Value.YearBirth > oldest.YearBirth)
                    oldest = now.Value;
                now = now.Next;
            }
            return oldest;
        }

        public string Name { get; set; }
        public int Class { get; set; }
        public int Group { get; set; }
        public int YearBirth { get; set; }
        public int[] Rating { get; set; }
        public Student(string name, int clas, int group, int yearBirth, int[] rating)
        {
            Name = name;
            Class = clas;
            Group = group;
            YearBirth = yearBirth;
            Rating = rating;
        }
    }
}
