using ALUMNI_RECORD.Models;
using Microsoft.EntityFrameworkCore;



namespace ALUMNI_RECORD.Models
{
    public class dbhandler

    {
        public static List<Student> getAllstudent()
        {
            List<Student> students;
            using (Deliverable3Context db=new Deliverable3Context())
            {
                students = db.Students.ToList();
            }

            return students;




        }
    }

}
