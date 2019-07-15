using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq___object_and_query_operators
{
    class Program
    {
        static void Main(string[] args)
        {
            UniversityManager universityManager = new UniversityManager();
            universityManager.MaleStudents();
            universityManager.FemaleStudents();
            universityManager.SortStudentsByAge();
            universityManager.AllStudentsFromBallState();


            int[] someInts = { 30, 12, 4, 3, 12 };
            IEnumerable<int> sortedInts = from i in someInts orderby i select i;
            IEnumerable<int> reveredInts = sortedInts.Reverse();

            foreach(int i in reveredInts)
            {
                Console.WriteLine(i);
            }

            IEnumerable<int> reveredSortedInts = from i in someInts orderby i descending select i;

            foreach(int i in reveredSortedInts)
            {
                Console.WriteLine(i);
            }

            /*
            string input = Console.ReadLine();
            try
            {
                int inputAsInt = Convert.ToInt32(input);
                universityManager.AllStudentsFromThatUni(inputAsInt);
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong value");
            }

    */
            Console.ReadKey();
        }
    }

    class UniversityManager
    {
        public List<University> universities;
        public List<Student> students;

        //constructor
        public UniversityManager()
        {
            universities = new List<University>();
            students = new List<Student>();

            universities.Add(new University { Id = 1, Name = "Ball State" });
            universities.Add(new University { Id = 2, Name = "Univeristy of Michigan" });

            students.Add(new Student { Id = 1, Name = "Dylan", Gender = "male", Age = 25, UniversityId = 1 });
            students.Add(new Student { Id = 2, Name = "Trevor", Gender = "male", Age = 23, UniversityId = 1 });
            students.Add(new Student { Id = 3, Name = "Dill", Gender = "male", Age = 23, UniversityId = 2 });
            students.Add(new Student { Id = 4, Name = "Briella", Gender = "female", Age = 27, UniversityId = 2 });
            students.Add(new Student { Id = 5, Name = "Evan", Gender = "male", Age = 25, UniversityId = 2 });

        }

        public void MaleStudents()
        {
            IEnumerable<Student> maleStudents = from student in students where student.Gender == "male" select student;
            Console.WriteLine("Male Students: ");

            foreach (Student student in maleStudents)
            {
                student.Print();
            }
        }

        public void FemaleStudents()
        {
            IEnumerable<Student> femaleStudents = from student in students where student.Gender == "female" select student;
            Console.WriteLine("Female Students: ");

            foreach (Student student in femaleStudents)
            {
                student.Print();
            }
        }

        public void SortStudentsByAge()
        {
            var sortedStudents = from student in students orderby student.Age select student;

            Console.WriteLine("Students sorted by Age: ");

            foreach (Student student in sortedStudents)
            {
                student.Print();
            }
        }

        public void AllStudentsFromBallState()
        {
            IEnumerable<Student> bsuStudents = from student in students
                                               join university in universities on student.UniversityId equals university.Id
                                               where university.Name == "Ball State"
                                               select student;
            Console.WriteLine("Students from Ball State: ");
            foreach (Student student in bsuStudents)
            {
                student.Print();
            }
        }

        public void AllStudentsFromThatUni(int Id)
        {
            IEnumerable<Student> myStudents = from student in students
                                              join university in universities on student.UniversityId equals university.Id
                                              where university.Id == Id
                                              select student;

            Console.WriteLine("Students from that uni {0}: ", Id);
            foreach (Student student in myStudents)
            {
                student.Print();
            }
        }

        public void StudentAndUniversityNameCollection()
        {
            var newCollection = from student in students
                                join univeristy in universities on student.UniveristyId equals university.Id
                                orderby student.Name
                                select new { StudentName = student.Name, UniversityName = university.Name };

            Console.WriteLine("New Collection: ");
            foreach (var col in newCollection)
            {
                Console.WriteLine("Student {0} from University {1}", col.StudentName, col.UniversityName);
            }

        }


    }
    class University
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine("University {0} with id {1}", Name, Id);
        }

    }
    class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Gender { get; set; }
            public int Age { get; set; }

            public int UniversityId { get; set; }
        public object UniveristyId { get; internal set; }

        public void Print()
            {
                Console.WriteLine("Student {0} with id {1}, Gender {2}, and Age {3} from Unisersity with the ID {4}",
                    Name, Id, Gender, Age, UniversityId);
            }
        }
    }
    


