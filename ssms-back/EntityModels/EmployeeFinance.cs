﻿using System;
using System.Collections.Generic;

namespace SSMS.EntityModels
{
  public partial class EmployeeFinance
  {
    public EmployeeFinance()
    {
      IsDeleted = false;
    }
    public string EmpId { get; set; }
    public string BankName { get; set; }
    public string BankAccount { get; set; }
    public string BankIBAN { get; set; }
    public decimal? BasicSalary { get; set; }
    public decimal? HousingAllowance { get; set; }
    public decimal? ExperienceAllowance { get; set; }
    public decimal? TransportAllowance { get; set; }
    public decimal? OtherAllowance { get; set; }
    public decimal? TotalSalary { get; set; }
    public decimal? Loans { get; set; }
    public decimal? Debts { get; set; }
    public string IssuerId { get; set; }
    public DateTime SysStartTime { get; set; }
    public DateTime SysEndTime { get; set; }
    public bool? IsDeleted { get; set; }

    public User _User { get; set; }
    public Employee Emp { get; set; }
  }
}
