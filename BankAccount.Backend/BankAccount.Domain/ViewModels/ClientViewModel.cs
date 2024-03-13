namespace BankAccount.Domain.ViewModels
{
    public class ClientViewModel
    {
        public LegalClientViewModel? LegalClient { get; set; }
        public IndividualClientViewModel? IndividualClient { get; set; }
    }
}
