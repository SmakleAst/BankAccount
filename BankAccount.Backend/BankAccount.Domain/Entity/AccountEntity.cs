using BankAccount.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Domain.Entity
{
    public class AccountEntity
    {
        [Key]
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public DateTime OpeningDate { get; set; }
        public float Balance { get; set; }
        public AccountType AccountType { get; set; }
        public int? CreditLimit { get; set; }
        public int ClientId { get; set; }

        public virtual ClientEntity Client { get; set; }
        public virtual List<TransactionEntity> Transactions { get; set; }
    }
}
