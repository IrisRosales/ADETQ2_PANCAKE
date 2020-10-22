using ADETQ2_PANCAKE.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace ADETQ2_PANCAKE.Controllers
{
    public class StudentController : Controller
    {
        string Str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo Ideapad A320\source\repos\ADETQ2_PANCAKE\App_Data\Student.mdf;Integrated Security=True";
        // GET: Student
        public ActionResult Index()

        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(Str))
            {
                con.Open();
                string q = "Select * from Student ORDER BY Surname";
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                da.Fill(dt);
            }

            return View(dt);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View(new Student());
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Str))
                {
                    SqlDataAdapter adpt = new SqlDataAdapter("SELECT * FROM student WHERE Student_Number='"+ student.Student_Number +"'",con);
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);
                    if (dt.Rows.Count <= 0)
                    {
                        con.Open();
                        string q = "insert into student values('" + student.Surname + "','" + student.Firstname + "','" + student.MI + "','" + student.Student_Number + "','" + student.Age + "','" + student.Address + "')";
                        SqlCommand cmd = new SqlCommand(q, con);


                        cmd.ExecuteNonQuery();
                    }
                    else { 

                    }
                    
                    
                }
                    
                
                return RedirectToAction("Index");
             }
            catch
            {

                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = new Student();
            DataTable dataTable = new DataTable();
            using (SqlConnection con = new SqlConnection(Str))
            {
                con.Open();
                string q = "Select * from Student where Id=" + id;
                SqlDataAdapter da = new SqlDataAdapter(q, con);
                da.Fill(dataTable);
            }
            if (dataTable.Rows.Count == 1)
            {
                student.Id = Convert.ToInt32(dataTable.Rows[0][0].ToString());
                student.Surname = dataTable.Rows[0][1].ToString();
                student.Firstname = dataTable.Rows[0][2].ToString();
                student.MI = dataTable.Rows[0][3].ToString();
                student.Student_Number = dataTable.Rows[0][4].ToString();
                student.Age = dataTable.Rows[0][5].ToString();
                student.Address = dataTable.Rows[0][6].ToString();

                return View(student);
            }
            return RedirectToAction("Index");
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Str))
                {
                    con.Open();
                    string q = "Update Student SET Surname=@Surname, Firstname=@Firstname, MI=@MI, Student_Number=@Student_Number, Age=@Age, Address=@Address where Id=@Id";
                    SqlCommand cmd = new SqlCommand(q, con);

                    cmd.Parameters.AddWithValue("@Id", student.Id);
                    cmd.Parameters.AddWithValue("@Surname", student.Surname);
                    cmd.Parameters.AddWithValue("@Firstname", student.Firstname);
                    cmd.Parameters.AddWithValue("@MI", student.MI);
                    cmd.Parameters.AddWithValue("@Student_Number", student.Student_Number);
                    cmd.Parameters.AddWithValue("@Age", student.Age);
                    cmd.Parameters.AddWithValue("@Address", student.Address);

                    cmd.ExecuteNonQuery();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(Str))
            {
                con.Open();
                string q = "Delete from Student where Id=@Id";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }


        // POST: Student/Delete/5
    }
}
