using BankAccount.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Domain.Entity
{
    public class ClientEntity
    {
        [Key]
        public int Id { get; set; }
        public ClientType Type { get; set; }
        

        public virtual IndividualClientEntity IndividualClient { get; set; }
        public virtual LegalClientEntity LegalClient { get; set; }
    }
}
