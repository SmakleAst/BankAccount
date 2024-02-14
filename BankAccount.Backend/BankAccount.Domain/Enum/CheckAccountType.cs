using System.ComponentModel.DataAnnotations;

namespace BankAccount.Domain.Enum
{
    public enum CheckAccountType
    {
        [Display(Name = "Кредитный")]
        Credit = 0,

        [Display(Name = "Дебетовый")]
        Debit = 1,
    }
}
