using Employees_Managment_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Employees_Managment_System
{
	public class ApplicationDBContext : DbContext
	{
		protected override void OnConfiguring ( DbContextOptionsBuilder optionsBuilder )
		{
			optionsBuilder.UseSqlServer("Data Source=RAMEZALEEM\\TRAINEE;Initial Catalog=System;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
		}
		protected override void OnModelCreating ( ModelBuilder modelBuilder )
		{
			modelBuilder.Entity<Employee>()
				.Property(e => e.EmployeeID)
				.ValueGeneratedOnAdd();
		}
		public DbSet<Employee> Employees { get; set; }
	}
}
