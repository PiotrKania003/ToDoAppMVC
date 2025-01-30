using Microsoft.EntityFrameworkCore;
using MyFristApp.Models;

namespace MyFristApp.Data
{
	public class MyAppContext : DbContext
	{
		public MyAppContext(DbContextOptions<MyAppContext> options) : base(options){ }
		public DbSet<TaskViewModel> Tasks { get; set; }

	}
}
