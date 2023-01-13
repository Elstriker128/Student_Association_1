using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Association_1
{
    public class Students
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string StudentID { get; set; }
        public int Course { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public int Age { get; set; }
        public Students(string surname, string name, DateTime birthdate, string studentid,
       int course, string phonenumber, string status)
        {
            this.Surname = surname;
            this.Name = name;
            this.BirthDate = birthdate;
            this.StudentID = studentid;
            this.Course = course;
            this.PhoneNumber = phonenumber;
            this.Status = status;
            this.Age = (Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd")) -
           Convert.ToInt32(birthdate.ToString("yyyyMMdd"))) / 10000;
        }
    }

}
