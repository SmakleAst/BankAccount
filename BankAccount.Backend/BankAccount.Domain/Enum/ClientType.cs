using System.ComponentModel.DataAnnotations;

namespace BankAccount.Domain.Enum
{
    public enum ClientType
    {
        [Display(Name = "Физическое лицо")]
        Individual = 0,

        [Display(Name = "Юридическое лицо")]
        Legal = 1,
    }
}
