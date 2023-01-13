using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Student_Association_1
{
    internal class Calculations
    {
        /// <summary>
        /// This method finds the oldest student from the given data.
        /// </summary>
        /// <param name="students">A list from which the oldest student's birthday is found</param>
        /// <returns>The oldest student's birthday</returns>
        public static DateTime FindOldestMember(List<Students> students)
        {
            DateTime biggest = DateTime.Today;
            foreach (Students student in students)
            {
                DateTime difference = student.BirthDate;
                if (DateTime.Compare(biggest, difference) > 0)
                {
                    biggest = difference;
                }
            }
            return biggest;
        }
        /// <summary>
        /// This method finds all the oldest members that share the same birthday with the  oldest student.
        /// </summary>
        /// <param name="students">A list from which the oldest student's birthday is found</param>
        /// <returns>A list of all the oldest students</returns>
        public static List<Students> FindAllResult(List<Students> students)
        {
            DateTime biggest = Calculations.FindOldestMember(students);
            List<Students> result = new List<Students>();
            foreach (Students student in students)
            {
                if (DateTime.Compare(biggest, student.BirthDate) == 0)
                {
                    result.Add(student);
                }
            }
            return result;
        }
        /// <summary>
        /// This method finds all the possible courses from the input data and deletes all the duplicates of other courses.
        /// </summary>
        /// <param name="students">A list from which the given courses are found</param>
        /// <returns>A list of all the courses that were given in the input data without duplicates</returns>
        public static List<int> FindAllCourses(List<Students> students)
        {
            List<int> courses = new List<int>();
            foreach (Students student in students)
            {
                if (!courses.Contains(student.Course))
                {
                    courses.Add(student.Course);
                }
            }
            return courses;
        }
        /// <summary>
        /// This method finds all the student counts from the given courses. It means that 
        /// it counts how many students are in a specific course.
        /// </summary>
        /// <param name="courses">A list of all the courses that were given in the input data without duplicates</param>
        /// <param name="students">A list of all the possible courses</param>
        /// <returns>A list of all the amounts of students in different courses</returns>
        public static List<int> FindAllStudentCourseCount(List<int> courses,
       List<Students> students)
        {
            List<int> final = new List<int>();
            foreach (int course in courses)
            {
                final.Add(FindCourseStudentCount(students, course));
            }
            return final;
        }
        /// <summary>
        /// This method finds the individual amount of students that study in a specific 
        /// This means it counts how many students study in one course.
        /// </summary>
        /// <param name="students">A list of all the possible courses</param>
        /// <param name="quantity">A course that is given to compare to all 
        /// <returns>An amount that displays how many students study in one 
        public static int FindCourseStudentCount(List<Students> students, int quantity)
        {
            int count = 0;
            foreach (Students student in students)
            {
                if (student.Course == quantity)
                {
                    count++;
                }
            }
            return count;
        }
        /// <summary>
        /// This method finds the biggest amount of students that study in one course. It displays as an integer.
        /// </summary>
        /// <param name="final">A list of all the amounts of students in different courses</param>
        /// <returns>The biggest amount of students that study in one course</returns>
        public static int FindBiggestCourseCount(List<int> final)
        {
            int maximum = 0;
            foreach (int value in final)
            {
                if (value > maximum)
                {
                    maximum = value;
                }
            }
            return maximum;
        }
        /// <summary>
        /// This method returns a list of students that study in the second course and above.
        /// There are two ways to find this amount: using the course indicator and the special student feature "fuksas".
        /// Other students who don't have the special feature "fuksas" are assigned a 0.
        /// </summary>
        /// <param name="students">A list that holds all the student's data</param>
        /// <returns>A list of students that study in the second course and above</returns>
        public static List<Students> FindAllProperCourseStudents(List<Students> students)
        {
            List<Students> list = new List<Students>();
            foreach (Students student in students)
            {
                if (student.Course >= 2)
                {
                    list.Add(student);
                }
            }
            return list;
        }
    }
}
