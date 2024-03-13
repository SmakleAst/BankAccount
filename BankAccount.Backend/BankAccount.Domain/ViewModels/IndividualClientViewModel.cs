using BankAccount.Domain.Enum;

namespace BankAccount.Domain.ViewModels
{
    public class IndividualClientViewModel
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public DateTime BirthDay { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string PhotoFilePath { get; set; }
        public bool IsBankEmployee { get; set; }
        public bool IsDebtor { get; set; }
    }
}
