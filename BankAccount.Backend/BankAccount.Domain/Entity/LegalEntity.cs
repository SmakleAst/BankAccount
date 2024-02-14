namespace BankAccount.Domain.Entity
{
    public class LegalEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string LeaderFullname { get; set; }
        public string ChiefAccountantFullname { get; set; }
        public string Phone { get; set; }
        public Ownerships OwnershipsForm { get; set; }
    }
}
