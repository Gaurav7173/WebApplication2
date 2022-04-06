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
        public string EmpAddress { get; set; }
        public string EmpMobile { get; set; }


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

        public static DataSet GetEmpDataByEmpId(int id)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\source\repos\WebApplication2\WebApplication2\App_Data\Database1.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            SqlCommand command = new SqlCommand($"select * from Employee where EmpId = {id}", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }
        public void InsertEmployee(Employee e)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\source\repos\WebApplication2\WebApplication2\App_Data\Database1.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            string insertCmd = $"insert into Employee (EmpName, EmpRole,EmpAddress,EmpMobile) values ('{e.EmpName}','{e.EmpRole}','{e.EmpAddress}','{e.EmpMobile}')";

            conn.Open();
            SqlCommand command = new SqlCommand(insertCmd, conn);
            command.ExecuteNonQuery();
        }

        internal void UpdateEmployee(Employee e)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\source\repos\WebApplication2\WebApplication2\App_Data\Database1.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);

            string insertCmd = $"update Employee set EmpName='{e.EmpName}', EmpRole='{e.EmpRole}', EmpAddress='{e.EmpAddress}', EmpMobile='{e.EmpMobile}' where EmpId={e.EmpId}";
            conn.Open();
            SqlCommand command = new SqlCommand(insertCmd, conn);
            command.ExecuteNonQuery();
        }

        internal static void DeleteEmployee(int e)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\source\repos\WebApplication2\WebApplication2\App_Data\Database1.mdf;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);

            string insertCmd = $"Delete Employee where EmpId={e}";
            conn.Open();
            SqlCommand command = new SqlCommand(insertCmd, conn);
            command.ExecuteNonQuery();
        }


    } 
    
}