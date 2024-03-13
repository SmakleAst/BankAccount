using BankAccount.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Domain.Entity
{
    public class LegalClientEntity
    {
        [Key, ForeignKey("Client")]
        public int Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(120)]
        public string LeaderFullname { get; set; }

        [StringLength(120)]
        public string ChiefAccountantFullname { get; set; }
        public string Phone { get; set; }
        public Ownerships OwnershipsForm { get; set; }

        public virtual ClientEntity Client { get; set; }
    }
}
