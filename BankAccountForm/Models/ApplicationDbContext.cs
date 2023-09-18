using Microsoft.EntityFrameworkCore;

namespace BankAccountForm.Models
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext()
		{
		}

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options)
		{
		}

		public DbSet<AccountModel> Accounts { get; set; }
		public DbSet<State> States { get; set; }
		public DbSet<City> Cities { get; set; }
		public DbSet<Branch> Branches { get; set; }
		public DbSet<Language> Languages { get; set; }

	}
}
