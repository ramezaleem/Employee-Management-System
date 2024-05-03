using Employees_Managment_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace Employees_Managment_System.Controllers
{
	public class EmployeeController : Controller
	{
		ApplicationDBContext context = new ApplicationDBContext();
		public IActionResult Index ()
		{
			return View(context.Employees.ToList());
		}

		//GET => /Employee/Create
		public IActionResult Create ()
		{
			return View();
		}

		//POST => /Employee/Create
		[HttpPost]
		public IActionResult Create ( Employee emp )
		{
			if (emp != null)
			{
				context.Employees.Add(emp);
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(emp);
		}

		//Edit
		// Edit => /Employee/Edit
		public IActionResult Edit(int id )
		{
			Employee emp = context.Employees.Find(id);
			ViewData["EmpList"] = context.Employees.ToList();
			return View(emp);

		}
		//public IActionResult SaveEdit ( int id, Employee newEmp )
		//{
		//	Employee oldEmp = context.Employees.FirstOrDefault(e => e.EmployeeID == id);
		//	if (oldEmp != null)
		//	{
		//		oldEmp.EmployeeID = newEmp.EmployeeID;
		//		oldEmp.EmpName = newEmp.EmpName;
		//		oldEmp.EmpTitle = newEmp.EmpTitle;
		//		oldEmp.Address = newEmp.Address;
		//		oldEmp.EmpPhone = newEmp.EmpPhone;
		//		oldEmp.EmpSalary = newEmp.EmpSalary;
		//		context.SaveChanges();
		//		return RedirectToAction("Index");
		//	}
		//	ViewData["EmpList"] = context.Employees.ToList();
		//	return View("Edit", newEmp);
		//}

		public IActionResult SaveEdit ( int id, Employee newEmp )
		{
			Employee oldEmp = context.Employees.FirstOrDefault(e => e.EmployeeID == id);
			if (oldEmp != null)
			{
				context.Employees.Remove(oldEmp);
				context.SaveChanges();

				Employee updatedEmployee = new Employee
				{
					EmployeeID = newEmp.EmployeeID, 
					EmpName = newEmp.EmpName,
					EmpTitle = newEmp.EmpTitle,
					Address = newEmp.Address,
					EmpPhone = newEmp.EmpPhone,
					EmpSalary = newEmp.EmpSalary
				};

				context.Employees.Add(updatedEmployee);
				context.SaveChanges();

				return RedirectToAction("Index");
			}

			ViewData["EmpList"] = context.Employees.ToList();
			return View("Edit", newEmp);
		}


		//Delete
		// POST => /Employee/Delete

		public IActionResult Delete(int id)
		{
			Employee emp = context.Employees.Find(id);
			if (emp != null)
			{
				context.Employees.Remove(emp);
				context.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				return Content("Employee Not Found !!");
			}
		}
		
		// Delete All
		public IActionResult DeleteAll()
		{
			context.Employees.RemoveRange(context.Employees);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		// Details 
		// GET =>  /Employee/Details
		public IActionResult Details (int id)
		{
			Employee emp = context.Employees.Find(id);
			if(emp != null)
			{
				return View(emp);
			}
			else
			{
				return Content("Employee Not Found !!");
			}
		}

	}


}
