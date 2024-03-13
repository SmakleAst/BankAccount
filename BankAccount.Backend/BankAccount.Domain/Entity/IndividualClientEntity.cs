using BankAccount.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Domain.Entity
{
    public class IndividualClientEntity
    {
        [Key, ForeignKey("Client")]
        public int Id { get; set; }

        [StringLength(40)]
        public string Surname { get; set; }

        [StringLength(40)]
        public string Name { get; set; }

        [Column(TypeName = "NVARCHAR")]
        [StringLength(40)]
        public string Middlename { get; set; }
        public DateTime BirthDay { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(10)]
        public string Phone { get; set; }
        public Gender Gender { get; set; }

        [StringLength(100)]
        public string PhotoFilePath { get; set; }
        public bool IsBankEmployee { get; set; }
        public bool IsDebtor { get; set; }

        public virtual ClientEntity Client { get; set; }
    }
}
