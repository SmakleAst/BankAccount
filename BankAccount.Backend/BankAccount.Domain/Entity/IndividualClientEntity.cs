using BankAccount.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Domain.Entity
{
    public class IndividualClientEntity
    {
        [Key, ForeignKey("Client")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public string PhotoFilePath { get; set; }
        public bool IsBankEmployee { get; set; }
        public bool IsDebtor { get; set; }

        public virtual ClientEntity Client { get; set; }
    }
}
