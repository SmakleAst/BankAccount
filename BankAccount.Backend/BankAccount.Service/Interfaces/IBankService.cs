using BankAccount.Domain.Entity;
using BankAccount.Domain.Response;
using BankAccount.Domain.ViewModels;

namespace BankAccount.Service.Interfaces
{
    public interface IBankService
    {
        Task<IBaseResponse<CreateAccountViewModel>> CreateAccount(CreateAccountViewModel model);
        Task<IBaseResponse<AccountViewModel>> DeleteAccount(int id);
        Task<IBaseResponse<UpdateAccountViewModel>> UpdateAccount(UpdateAccountViewModel model);
        Task<IBaseResponse<UpdateAccountViewModel>> PatchAccount(UpdateAccountViewModel model);
        Task<IBaseResponse<IEnumerable<AccountViewModel>>> GetAllAccounts();

        Task<IBaseResponse<ClientViewModel>> GetOneClient(int id);

        Task<IBaseResponse<CreateLegalClientViewModel>> CreateLegalClient(CreateLegalClientViewModel model);
        Task<IBaseResponse<LegalClientViewModel>> DeleteLegalClient(int id);
        Task<IBaseResponse<UpdateLegalClientViewModel>> UpdateLegalClient(UpdateLegalClientViewModel model);
        Task<IBaseResponse<UpdateLegalClientViewModel>> PatchLegalClient(UpdateLegalClientViewModel model);
        Task<IBaseResponse<IEnumerable<LegalClientViewModel>>> GetAllLegalClients();
    }
}
