using Rokkit200TechnicalAssessment.Repositories.Interfaces;
using Rokkit200TechnicalAssessment.Data;
using Rokkit200TechnicalAssessment.Data.Entity;

namespace Rokkit200TechnicalAssessment.Repositories
{
    public class AccountService : IAccountService
    {
        private readonly AccountDbContext _context;

        public AccountService(AccountDbContext context)
        {
            _context = context;
        }

        public SavingsAccount OpenSavingsAccount(int accountId, long amountToDeposit)
        {
            try
            {
                if (amountToDeposit >= 1000)
                {
                    var acc = new SavingsAccount() { Id = accountId, Balance = amountToDeposit, CustomerId = 2 };

                    _context.SavingsAccounts.Add(acc);

                    _context.SaveChanges();

                    return acc;
                }
                return null;
            }
            catch (Exception)
            {

                throw new Exception("NullReferenceException");
            }
        }

        public CurrentAccount OpenCurrentAccount(int accountId)
        {
            var acc = new CurrentAccount() { Id = accountId, CustomerId = 2 , Balance = 0};

            _context.CurrentAccounts.Add(acc);

            _context.SaveChanges();

            return acc;
        }

        public long Withdraw(int accountId, long amountToWithdraw)
        {
            var savingAcc = _context.SavingsAccounts.FirstOrDefault<SavingsAccount>(a => a.Id == accountId);
            var currentAcc = _context.CurrentAccounts.FirstOrDefault<CurrentAccount>(a => a.Id == accountId);
            var result = new long();

            if (savingAcc == null && currentAcc == null)
                throw new Exception("AccountNotFoundException");

            if (savingAcc != null)
            {
                if (savingAcc.Balance < amountToWithdraw)
                    throw new Exception($"There is insufficient funds to withdraw R{amountToWithdraw}");

                result = savingAcc.Balance -= amountToWithdraw;
            }
            else if (currentAcc != null)
            {
                if (currentAcc.Balance + currentAcc.OverDraft < amountToWithdraw)
                    throw new Exception($"There is insufficient funds to withdraw R{amountToWithdraw}");

                result = currentAcc.Balance -= amountToWithdraw;
            }

            _context.SaveChanges();

            return result;
        }

        public long Deposit(int accountId, long amountToDeposit)
        {
            var savingAcc = _context.SavingsAccounts.FirstOrDefault<SavingsAccount>(a => a.Id == accountId);
            var currentAcc = _context.CurrentAccounts.FirstOrDefault<CurrentAccount>(a => a.Id == accountId);
            var result = new long();

            if (savingAcc == null && currentAcc == null)
                throw new Exception("AccountNotFoundException");

            if (savingAcc != null)
                result = savingAcc.Balance += amountToDeposit;
  
            else if (currentAcc != null)
                result = currentAcc.Balance += amountToDeposit;

            _context.SaveChanges();

            return result;
        }
    }
}
