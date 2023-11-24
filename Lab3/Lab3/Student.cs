using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;//added


namespace Lab3
{
    public class Student
    {
        private static int StudentPK;
        private static string Name;
        private static string Surname;
        private static int StudentNo;
        public static void setName(string name)
        {
            Name = name;
        }

        public static void setSurname(string surname)
        {
            Surname = surname;
        }

        public static void setStudentNo(int studentNo)
        {
            StudentNo = studentNo;
        }
        public static int getStudentPK()
        {
            return StudentPK;
        }
        public static string getName()
        {
            return Name;
        }
        public static string getSurname()
        {
            return Surname;
        }
        public static int getStudentNo()
        {
            return StudentNo;
        }
        public static void resetStudent()
        {
            StudentPK = 0;
            Name = "";
            Surname = "";
            StudentNo = 0;
        }
        public static int insertStudent()
        {
            int result;
            DataAccessLayer dal = new DataAccessLayer();
            if (dal.openConnection())
            {
                string query = "select * from Students where StudentNo = @studentNo";
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = query;
                sqlCommand.Parameters.AddWithValue("@StudentNo", StudentNo);
                SqlDataReader reader = dal.returnReader(sqlCommand);
                if (!reader.HasRows)//if there is no student with this student number
                {
                    sqlCommand.CommandText = "insert into Students values(@name, @surname,@studentNo)";
                    sqlCommand.Parameters.AddWithValue("@name", Name);
                    sqlCommand.Parameters.AddWithValue("@surname", Surname);
                    //sqlCommand.Parameters.AddWithValue("@studentNo", StudentNo);
                    reader.Close();
                    result = dal.queryExecution(sqlCommand);//result = 1 or result = 0
                }
                else result = -50;//student not in unique

                dal.closeConnection();//close connection
            }
            else
            {
                result = -1000;//connection error
            }
            return result;
        }

        public static int insertStudentStoreProcedure()
        {
            int result;
            DataAccessLayer dal = new DataAccessLayer();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandType=System.Data.CommandType.StoredProcedure;
            sqlCommand.CommandText = "insert_student";
            sqlCommand.Parameters.AddWithValue("@name", Name);
            sqlCommand.Parameters.AddWithValue("@surname", Surname);
            sqlCommand.Parameters.AddWithValue("@studentNo", StudentNo);
            if(dal.openConnection())
            {
                result = dal.queryExecution(sqlCommand);//result = 1 or result = 0
                dal.closeConnection();//close connection
            }
            else result = -1000;//connection error
            
            return result;
        }

        public static int searchStudent()
        {
            int result;
            DataAccessLayer dal = new DataAccessLayer();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "select * from Students where StudentNo = @studentNo";
            sqlCommand.Parameters.AddWithValue("@studentNo", StudentNo);
            if (dal.openConnection())
            {
                SqlDataReader reader = dal.returnReader(sqlCommand);
                if (reader.HasRows)//if there is a student with this student number
                {
                    reader.Read();
                    StudentPK = Convert.ToInt32(reader[0].ToString());
                    Name = reader[1].ToString();
                    Surname = reader[2].ToString();
                    //StudentNo = Convert.ToInt32(reader[3].ToString());
                    reader.Close();
                    result = 1;//student found
                }
                else result = 0;//student not found
                dal.closeConnection();//close connection

            }
            else result = -1000;//connection error
            
            return result;
        }

        public static int updateStudent()
        {
            int result;
            DataAccessLayer dal = new DataAccessLayer();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "update Students set Name = @name, Surname = @surname where (StudentNo = @studentNo and StudentPK = @studentPK)";
            
            sqlCommand.Parameters.AddWithValue("@studentNo", StudentNo);
            sqlCommand.Parameters.AddWithValue("@studentPK", StudentPK);
            sqlCommand.Parameters.AddWithValue("@name", Name);
            sqlCommand.Parameters.AddWithValue("@surname", Surname);
            if (dal.openConnection())
            {
                result = dal.queryExecution(sqlCommand);//result = 1 or result = 0
                dal.closeConnection();//close connection
            }
            else result = -1000;//connection error
            
            return (int)result;
        }
    }
}