using Rokkit200TechnicalAssessment.Data;
using Rokkit200TechnicalAssessment.Data.Entity;

namespace Rokkit200TechAssessment
{
    public class SystemDB
    {
        private static SystemDB? instance;
        private readonly AccountDbContext _context;
        public SystemDB(AccountDbContext context)
        {
            _context = context;
             InitializeAccounts();
        }

        public static SystemDB GetInstance(AccountDbContext context)
        {
            if (instance == null)
                instance = new SystemDB(context);

            return instance;
        }


        private void InitializeAccounts()
        {
            _context.CurrentAccounts.Add(new CurrentAccount { Id = 3, CustomerId = 3, Balance = 1000 });
            _context.SavingsAccounts.Add(new SavingsAccount { Id = 1, CustomerId = 1, Balance = 2000 });
            _context.SavingsAccounts.Add(new SavingsAccount { Id = 2, CustomerId = 2, Balance = 5000 });

            _context.SaveChanges();
        }

        public CurrentAccount GetCurrentAccountById(long Id)
        {
            return _context.CurrentAccounts.FirstOrDefault(a => a.Id == Id);
        }

        public SavingsAccount GetSavingsAccountById(long Id)
        {
            return _context.SavingsAccounts.FirstOrDefault(a => a.Id == Id);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AccountDbContext())
            {
                SystemDB db = SystemDB.GetInstance(context);

                var currentAccount = db.GetCurrentAccountById(1);
                Console.WriteLine($"Current Account - Customer ID: {currentAccount.CustomerId}, Balance: {currentAccount.Balance}");

                var savingsAccount1 = db.GetSavingsAccountById(3);
                Console.WriteLine($"Savings Account - Customer ID: {savingsAccount1.CustomerId}, Balance: {savingsAccount1.Balance}");

                var savingsAccount2 = db.GetSavingsAccountById(2);
                Console.WriteLine($"Savings Account - Customer ID: {savingsAccount2.CustomerId}, Balance: {savingsAccount2.Balance}");
            }
        }
    }
}
