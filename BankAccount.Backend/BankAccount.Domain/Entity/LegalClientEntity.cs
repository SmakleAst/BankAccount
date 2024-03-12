using BankAccount.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Domain.Entity
{
    public class LegalClientEntity
    {
        [Key, ForeignKey("Client")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string LeaderFullname { get; set; }
        public string ChiefAccountantFullname { get; set; }
        public string Phone { get; set; }
        public Ownerships OwnershipsForm { get; set; }

        public virtual ClientEntity Client { get; set; }
    }
}
