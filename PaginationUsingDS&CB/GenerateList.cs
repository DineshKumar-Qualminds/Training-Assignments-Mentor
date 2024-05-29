using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginationUsingADO
{
    public class GenerateList
    {
        public static List<Employee> GenerateEmployeeListFromDatabase()
        {
            string connectionString = "Data Source=QUAL-LT7M15F63\\SQLEXPRESS;Initial Catalog=EmployeeDatabase;Integrated Security=True;";
            string query = "SELECT e.EmpId, e.EmpFname, e.EmpLname, e.DOB, " +
               "p.Email " +
               "FROM EmployeeInfo e " +
               "JOIN EmployeePosition p ON e.EmpID = p.EmpID";


            List<Employee> employees = new List<Employee>();

          using(SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(); 



                while(reader.Read())
                {
                    employees.Add(new Employee() {
                        Id = Convert.ToInt32(reader["EmpID"]),
                        FirstName = reader["EmpFname"].ToString(),
                        LastName = reader["EmpLname"].ToString(),
                        DateOfBirth = Convert.ToDateTime(reader["DOB"]),
                        EmailId = reader["Email"].ToString()
                    });
                }
                reader.Close();


            }
          return employees;


        }
    }
}
