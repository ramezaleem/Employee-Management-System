using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employees_Managment_System.Models
{
	public class Employee
	{
		[Display(Name = "Employee ID")]
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int EmployeeID { get; set; }
		[Display(Name = "Employee Name")]
		public string EmpName { get; set; }
		[Display(Name ="Employee Title")]
        public string EmpTitle { get; set; }
        [Display(Name = "Employee Address")]
		public string Address { get; set; }
		[Display(Name = "Employee Phone")]
		public string EmpPhone { get; set; }
		[Display(Name = "Employee Salary")]
		public double EmpSalary { get; set; }
	}
}
