using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpRole { get; set; }


        public static DataSet GetEmpData()
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\source\repos\WebApplication2\WebApplication2\App_Data\Database1.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand("select * from Employee",conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }
        public void InsertEmployee(Employee e)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\source\repos\WebApplication2\WebApplication2\App_Data\Database1.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            string insertCmd = $"insert into Employee (EmpName, EmpRole) values ('{e.EmpName}','{e.EmpRole}')";

            conn.Open();
            SqlCommand command = new SqlCommand(insertCmd, conn);
            command.ExecuteNonQuery();
        }

        
    } 
    
}