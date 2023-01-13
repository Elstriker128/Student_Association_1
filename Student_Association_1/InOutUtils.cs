using Student_Association_1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Student_Association_1
{
    public class InOutUtils
    {
        /// <summary>
        /// This method reads all the input data from a file.
        /// </summary>
        /// <param name="filename">A filename that shows what file holds all the input  data</param>
        /// <returns>A list with all the students' data</returns>
        public static List<Students> ReadStudents(string filename)
        {
            List<Students> students = new List<Students>();
            string[] Lines = File.ReadAllLines(filename);
            if (new FileInfo(filename).Length == 0)
            {
                Console.WriteLine("Error: no data input");
            }
            foreach (string Line in Lines)
            {
                string[] Values = Line.Split(',');
                string surname = Values[0];
                string name = Values[1];
                DateTime birthdate = DateTime.Parse(Values[2]);
                string studentid = Values[3];
                int course = int.Parse(Values[4]);
                string phonenumber = Values[5];
                string status = Values[6];
                Students student = new Students(surname, name, birthdate, studentid,
               course, phonenumber, status);
                students.Add(student);
            }
            return students;
        }
        /// <summary>
        /// This method prints all the oldest students.
        /// </summary>
        /// <param name="result">A list that returns all the required oldest students' data</param>
        /// <returns>All the oldest students from the input file</returns>
        public static void PrintOldest(List<Students> result)
        {
            if (result.Count == 0)
            {
                Console.WriteLine("Error: there are no oldest students because of lack of  data");
            }
            else
            {
                Console.WriteLine(new string('-', 100));
                Console.WriteLine("| {0,-15} | {1,-15} | {2,-8} | ", "Surname", "Name",
               "Age");
                Console.WriteLine(new string('-', 100));
                foreach (Students student in result)
                {
                    Console.WriteLine("| {0,-15} | {1,-15} | {2,-8} | ", student.Surname,
                   student.Name, student.Age);
                }
                Console.WriteLine(new string('-', 100));
            }
        }
        /// <summary>
        /// This method prints all the courses with the most students and the student count.
        /// </summary>
        /// <param name="courses">A list of all the courses that were given in the input data without duplicates</param>
        /// <param name="final">A list of all the amounts of students in different  courses</param>
        /// <returns>All the courses with the most students and the student count</returns>
        public static void PrintBiggestCourseAndStudents(List<int> courses, List<int>
       final)
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("Error: no biggest course because of lack of data");
            }
            else
            {
                int max = Calculations.FindBiggestCourseCount(final);
                Console.WriteLine(new string('-', 100));
                Console.WriteLine("The biggest course(-s) and its amount of students:");
                for (int i = 0; i < courses.Count; i++)
                {
                    if (final[i] == max)
                    {
                        Console.WriteLine("{0} | {1}", courses[i], final[i]);
                    }
                }
                Console.WriteLine(new string('-', 100));
            }
        }
        /// <summary>
        /// This method prints all the students and their data that study int the second course and above
        /// My system uses commas ',' to seperate cells, but other systems may use ';' so it needs to be checked before run
        /// </summary>
        /// <param name="list">A list that holds all the student's personal info that's displayed in the input file</param>
        /// <param name="filename">A filename that shows what file outputs all the neccesary data</param>
        /// <returns>All the students and their data that study int the second course and above to a file</returns>
        public static void PrintAllAboveSecondCourseToCSV(List<Students> list, string
       filename)
        {
            if (list.Count == 0)

            {
                Console.WriteLine(new string('-', 100));
                Console.WriteLine("Error: no data output to a given file Senbuviai.csv");
                Console.WriteLine(new string('-', 100));
                File.Delete(filename);
            }
            else
            {
                string[] lines = new string[list.Count + 5];
                lines[0] = String.Format("{0,-15}, {1,-15}, {2,-10:yyyy-MM-dd}, {3,-15}, { 4,-6}, { 5,-20}, { 6,-15},", "Surname", "Name", "BirthDate",
 "StudentID", "Course", "PhoneNumber", "Status");
                for (int i = 0; i < list.Count; i++)
                {
                    lines[i + 1] = String.Format("{0,-15}, {1,-15}, {2,-10:yyyy-MM-dd}, { 3,-15}, { 4,-6}, { 5,-20}, { 6,-15},", list[i].Surname, list[i].Name, list[i].BirthDate,
               list[i].StudentID, list[i].Course, list[i].PhoneNumber, list[i].Status);
                }
                File.WriteAllLines(filename, lines, Encoding.UTF8);
            }
        }
        /// <summary>
        /// This method prints the primary student data into an *txt file
        /// </summary>
        /// <param name="students">A list with all the primary data ofall the students </ param >
        /// <param name="filename">A filename that shows what file outputs all the neccesary data </ param >
        /// <returns>All the students and their data that were given in the input file </ returns >
        public static void PrintInputData(List<Students> students, string filename)
        {
            string[] lines = new string[students.Count + 5];
            lines[0] = String.Format("| {0,-15} | {1,-15} | {2,-10:yyyy-MM-dd} | {3,-15} | { 4,-2} | { 5,-15} | { 6,-15} | ", "Surname", "Name", "BirthDate",
         "StudentID", "Course", "PhoneNumber", "Status");
            for (int i = 0; i < students.Count; i++)
            {
                lines[i + 1] = String.Format("| {0,-15} | {1,-15} | {2,-8:yyyy-MM-dd} | { 3,-15} | { 4,-6} | { 5,-15} | { 6,-15} | ", students[i].Surname, students[i].Name,
            students[i].BirthDate, students[i].StudentID, students[i].Course, students[i].PhoneNumber,
            students[i].Status);
            }
            File.WriteAllLines(filename, lines, Encoding.UTF8);
        }
    }
}
