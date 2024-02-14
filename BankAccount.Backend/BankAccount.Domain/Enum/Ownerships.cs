using System.ComponentModel.DataAnnotations;

namespace BankAccount.Domain.Enum
{
    public enum Ownerships
    {
        [Display(Name = "Государственная")]
        State = 0,

        [Display(Name = "Частная")]
        PrivateForm = 1,

        [Display(Name = "Иностранное предприятие")]
        ForeignEnterprise = 2,

        [Display(Name = "Cмешанная")]
        Mixed = 3, 
    }
}
