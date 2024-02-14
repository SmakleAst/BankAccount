namespace BankAccount.Domain.Entity
{
    public class CheckAccountEntity
    {
        public int Id { get; set; }
        public string CheckAccountNumber { get; set; }
        public DateTime OpeningDate { get; set; }
        public int? IndividualClientId { get; set; }
        public IndividualEntity? IndividualClient { get; set; }
        public int? LegalClientId { get; set; }
        public LegalEntity? LegalClient { get; set; }
        public decimal Balance { get; set; }
        public CheckAccountType Type { get; set; }
    }
}
