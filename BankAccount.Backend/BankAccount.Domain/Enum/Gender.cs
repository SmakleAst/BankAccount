using System.ComponentModel.DataAnnotations;

namespace BankAccount.Domain.Enum
{
    public enum Gender
    {
        [Display(Name = "Мужчина")]
        Male = 0,

        [Display(Name = "Женщина")]
        Female = 1,
    }
}
