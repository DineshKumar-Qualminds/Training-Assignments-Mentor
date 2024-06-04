using System;
using System.Collections.Generic;

namespace Employee_API_DatabaseFirst.Model;

public partial class EmployeeDetail
{
    public int EmpId { get; set; }

    public string? EmpName { get; set; }

    public string? DeptName { get; set; }

    public int? Salary { get; set; }
}
