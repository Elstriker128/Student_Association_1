using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Association_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = "Senbuviai.csv";
            string filename2 = "Input_Data.txt";
            Console.OutputEncoding = Encoding.UTF8;
            List<Students> students = InOutUtils.ReadStudents(@"Students.csv");
            List<int> courses = Calculations.FindAllCourses(students);
            List<int> final = Calculations.FindAllStudentCourseCount(courses, students);
            Console.WriteLine("Information about oldest student: ");
            InOutUtils.PrintOldest(Calculations.FindAllResult(students));
            InOutUtils.PrintBiggestCourseAndStudents(courses, final);
            InOutUtils.PrintAllAboveSecondCourseToCSV(Calculations.FindAllProperCourseStudents(students), filename);
            InOutUtils.PrintInputData(students, filename2);
        }
    }
}
