using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaginationUsingADO
{ 
    public class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = GenerateList.GenerateEmployeeListFromDatabase();

            Console.Write("Enter page size:");
            int pageSize = int.Parse(Console.ReadLine());   

            Console.Write("Enter page number:");
            int pageNumber = int.Parse(Console.ReadLine());

            DisplayEmployeeList.DisplayEmployees(employees,pageNumber, pageSize);   
            Console.ReadLine(); 

        }
    }
}
