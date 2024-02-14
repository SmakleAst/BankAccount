using BankAccount.Domain.Enum;

namespace BankAccount.Domain.Entity
{
    public class IndividualEntity
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        public bool Status { get; set; }//(должник)
        public string PhotoFilePath { get; set; }
        public bool IsBankEmployee { get; set; }
        public List<CheckAccountEntity> CheckAccounts { get; set; }
        public List<SaveAccountEntity> SaveAccounts { get; set; }
    }
}
