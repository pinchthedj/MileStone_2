using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Mile_Stone_1
{
    class AllMethods
    {
        public List<Student> GetStudent()
        {

            List<Student> students = new List<Student>();
            students.Add(new Student("Katlego Motsepe", "2001/01/03", "male", "576977", "0764014888", "31 Oster Street The Orchards", "PRG 281", 20));


            return students;
        }

        public AllMethods() { }
        string con = "Server=(local); Initial Catalog= BCview; Integrated Security=SSPI";

        public DataTable displayStudent()
        {
            SqlConnection connect = new SqlConnection(con);
            SqlDataAdapter adapter = new SqlDataAdapter("spGetStudents", connect);
            adapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            DataTable dt = new DataTable();

            adapter.Fill(dt);
            return dt;
        }

        public void insertStudent(string fullname, string dob, string gender, string student_no,
            string cell, string addi, string codes, int age)
        {
            using (SqlConnection conn = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("spInsert", conn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@FullName", fullname);
                command.Parameters.AddWithValue("@DOB", dob);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@StudentNumber", student_no);
                command.Parameters.AddWithValue("@CellNumber", cell);
                command.Parameters.AddWithValue("@Addres", addi);
                command.Parameters.AddWithValue("@ModuleCode", codes);
                command.Parameters.AddWithValue("@Age", age);

                conn.Open();
                command.ExecuteNonQuery();

            }

        }
        public void insertUser(string name, string pin)
        {
            using (SqlConnection conne = new SqlConnection(con))
            {
                SqlCommand sql = new SqlCommand("spNewUser", conne);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@Name", name);
                sql.Parameters.AddWithValue("@Pin", pin);
                conne.Open();
                sql.ExecuteNonQuery();


            }
        }

        public void insertModule(string name, string code, string discribtion, string yt)
        {
            using (SqlConnection connec = new SqlConnection(con))
            {
                SqlCommand mandie = new SqlCommand("spNewModule", connec);
                mandie.CommandType = CommandType.StoredProcedure;
                mandie.Parameters.AddWithValue("@Name", name);
                mandie.Parameters.AddWithValue("@Code", code);
                mandie.Parameters.AddWithValue("@Gender", discribtion);
                mandie.Parameters.AddWithValue("@YTlink", yt);
                connec.Open();
                mandie.ExecuteNonQuery();

            }
        }

        public void DeleteStudent(string studentnumber)
        {
            using (SqlConnection connect = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("spDelete", connect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentNumber", studentnumber);
                
                connect.Open();
                command.ExecuteNonQuery();

            }

        }

        public void UpdateStudents(string fullname, string dob, string gender, string student_no,
            string cell, string addi, string codes, int age)
        {
            using (SqlConnection co = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("spUpdate", co);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@FullName", fullname);
                command.Parameters.AddWithValue("@DOB", dob);
                command.Parameters.AddWithValue("@Gender", gender);
                command.Parameters.AddWithValue("@StudentNumber", student_no);
                command.Parameters.AddWithValue("@CellNumber", cell);
                command.Parameters.AddWithValue("@Addres", addi);
                command.Parameters.AddWithValue("@ModuleCode", codes);
                command.Parameters.AddWithValue("@Age", age);

                co.Open();
                command.ExecuteNonQuery();

            }
        }

        public void LogIN(string name, string pin)
        {
            using (SqlConnection c = new SqlConnection(con))
            {
                SqlCommand sql = new SqlCommand("spLogin", c);
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@Name", name);
                sql.Parameters.AddWithValue("@Pin", pin);

                c.Open();
                sql.ExecuteNonQuery();

            }
        }

        public DataTable Search(string studentnumber)
        {
            using (SqlConnection coo = new SqlConnection(con))
            {
                SqlCommand command = new SqlCommand("spSearch", coo);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@StudentNumber", studentnumber);
                coo.Open();
                DataTable data = new DataTable();
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    data.Load(reader);
                    return data;
                }

            }

        }
    }
}

