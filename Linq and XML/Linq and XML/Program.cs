using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linq_and_XML
{
    class Program
    {
        static void Main(string[] args)
        {

            string studentsXML =
                @"<Students>
                    <Student>
                        <Name>Toni</Name>
                        <Age>21</Age>
                        <University>Yale</University>
                        <Year>4</Year>
                    </Student>
                    <Student>
                        <Name>Carla</Name>
                        <Age>17</Age>
                        <University>Yale</University>
                        <Year>1</Year>
                    </Student>
                    <Student>
                        <Name>Leyla</Name>
                        <Age>19</Age>
                        <University>Beijing Tech</University>
                        <Year>3</Year>
                    </Student>
                    <Student>
                        <Name>Dylan</Name>
                        <Age>25</Age>
                        <University>BSU</University>
                        <Year>2</Year>
                    </Student>
                </Students>";

            XDocument studentsXdoc = new XDocument();
            studentsXdoc = XDocument.Parse(studentsXML);

            var students = from student in studentsXdoc.Descendants("Student")
                           select new
                           {
                               Name = student.Element("Name").Value,
                               Age = student.Element("Age").Value,
                               University = student.Element("University").Value,
                               Year = student.Element("Year").Value
                           };

            foreach(var student in students)
            {
                Console.WriteLine("Student {0} with age of {1} from University of {2} and has been here for {3} years", 
                    student.Name, student.Age, student.University, student.Year);
            }

            var sortedStudents = from student in students
                                 orderby student.Age
                                 select student;

            foreach (var student in sortedStudents)
            {
                Console.WriteLine("Student {0} with age of {1} from University of {2} and has been here for {3} years", 
                    student.Name, student.Age, student.University, student.Year);
            }

            Console.ReadLine();
        }
    }
}
