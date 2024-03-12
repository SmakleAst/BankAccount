using BankAccount.Domain.Entity;
using BankAccount.Domain.Response;
using BankAccount.Domain.ViewModels;

namespace BankAccount.Service.Interfaces
{
    public interface IBankService
    {
        Task<IBaseResponse<CreateAccountViewModel>> CreateAccount(CreateAccountViewModel model);
        Task<IBaseResponse<AccountEntity>> DeleteAccount(int id);
        Task<IBaseResponse<AccountEntity>> UpdateAccount(UpdateAccountViewModel model);
        Task<IBaseResponse<AccountEntity>> PatchAccount(UpdateAccountViewModel model);
        Task<IBaseResponse<IEnumerable<AccountEntity>>> GetAllAccounts();

        Task<IBaseResponse<CreateLegalClientViewModel>> CreateLegalClient(CreateLegalClientViewModel model);
        Task<IBaseResponse<LegalClientEntity>> DeleteLegalClient(int id);
        Task<IBaseResponse<LegalClientEntity>> UpdateLegalClient(UpdateLegalClientViewModel model);
        Task<IBaseResponse<LegalClientEntity>> PatchLegalClient(UpdateLegalClientViewModel model);
        Task<IBaseResponse<IEnumerable<LegalClientEntity>>> GetAllLegalClients();
    }
}
