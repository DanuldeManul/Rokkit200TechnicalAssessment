namespace Rokkit200TechnicalAssessment.Data.Entity
{
    public class CurrentAccount
    {
        public int Id { get; set; }
        public long CustomerId { get; set; }
        public long Balance { get; set; }
        public long OverDraft { get; set; } = 10000;
    }
}
