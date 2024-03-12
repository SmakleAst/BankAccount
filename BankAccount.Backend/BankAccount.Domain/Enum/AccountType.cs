using System.ComponentModel.DataAnnotations;

namespace BankAccount.Domain.Enum
{
    public enum AccountType
    {
        [Display(Name = "Кредитный")]
        Credit = 0,

        [Display(Name = "Дебетовый")]
        Debit = 1,

        [Display(Name = "Сберегательный")]
        Save = 2,
    }
}
