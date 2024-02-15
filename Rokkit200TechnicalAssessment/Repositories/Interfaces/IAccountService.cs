using Rokkit200TechnicalAssessment.Data.Entity;

namespace Rokkit200TechnicalAssessment.Repositories.Interfaces
{
    public interface IAccountService
    {
        SavingsAccount OpenSavingsAccount(int accountId, long amountToDeposit);
        CurrentAccount OpenCurrentAccount(int accountId);
        long Withdraw(int accountId, long amountToWithdraw);
        long Deposit(int accountId, long amountToDeposit);
    }
}
