namespace BankAccount.Domain.ViewModels
{
    public class AccountViewModel
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string OpeningDate { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public int? CreditLimit { get; set; }
    }
}
