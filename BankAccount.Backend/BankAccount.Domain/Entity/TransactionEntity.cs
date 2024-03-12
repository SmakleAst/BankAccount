using System.ComponentModel.DataAnnotations;

namespace BankAccount.Domain.Entity
{
    public class TransactionEntity
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string CashierName { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }

        public virtual AccountEntity Account { get; set; }
    }
}
