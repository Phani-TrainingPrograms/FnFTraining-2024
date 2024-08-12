using System;
using System.Collections.Generic;

namespace WebApiCore.Data;

public partial class DeptTable
{
    public int DeptId { get; set; }

    public string Deptname { get; set; } = null!;

    public virtual ICollection<EmpTable> EmpTables { get; set; } = new List<EmpTable>();
}
