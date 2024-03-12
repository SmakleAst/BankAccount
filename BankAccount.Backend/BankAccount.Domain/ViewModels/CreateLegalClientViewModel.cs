using BankAccount.Domain.Enum;

namespace BankAccount.Domain.ViewModels
{
    public class CreateLegalClientViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string LeaderFullname { get; set; }
        public string ChiefAccountantFullname { get; set; }
        public string Phone { get; set; }
        public Ownerships OwnershipsForm { get; set; }
    }
}
