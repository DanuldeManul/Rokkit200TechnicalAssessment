using Microsoft.EntityFrameworkCore;
using Rokkit200TechnicalAssessment.Data.Entity;

namespace Rokkit200TechnicalAssessment.Data
{
    public class AccountDbContext : DbContext
    {
        public AccountDbContext() : base() { }

        public DbSet<CurrentAccount> CurrentAccounts { get; set; }
        public DbSet<SavingsAccount> SavingsAccounts { get; set; }
    }
}
