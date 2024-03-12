using BankAccount.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Domain.Entity
{
    public class InterestRateEntity
    {
        [Key]
        public int Id { get; set; }
        public AccountType AccountType { get; set; }
        public decimal Rate { get; set; }
    }
}
