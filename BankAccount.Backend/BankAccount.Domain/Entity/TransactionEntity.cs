using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccount.Domain.Entity
{
    public class TransactionEntity
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }

        [StringLength(120)]
        public string CashierName { get; set; }

        [StringLength(50)]
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }

        public virtual AccountEntity Account { get; set; }
    }
}
