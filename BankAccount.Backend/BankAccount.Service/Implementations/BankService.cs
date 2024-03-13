using BankAccount.DAL.Interfaces;
using BankAccount.Domain.Entity;
using BankAccount.Domain.Enum;
using BankAccount.Domain.Extensions;
using BankAccount.Domain.Response;
using BankAccount.Domain.ViewModels;
using BankAccount.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Numerics;

namespace BankAccount.Service.Implementations
{
    public class BankService : IBankService
    {
        private readonly IBaseRepository<ClientEntity> _clientRepository;
        private readonly IBaseRepository<LegalClientEntity> _legalClientRepository;
        private readonly IBaseRepository<AccountEntity> _accountRepository;
        
        private readonly ILogger<BankService> _logger;

        public BankService(IBaseRepository<ClientEntity> clientRepository, IBaseRepository<LegalClientEntity> legalClientRepository,
            IBaseRepository<AccountEntity> accountRepository, ILogger<BankService> logger) =>
            (_clientRepository, _legalClientRepository, _accountRepository, _logger) =
            (clientRepository, legalClientRepository, accountRepository, logger);

        #region Account
        public async Task<IBaseResponse<CreateAccountViewModel>> CreateAccount(CreateAccountViewModel model)
        {
            try
            {
                var client = await _clientRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == model.ClientId);

                if (client == null)
                {
                    return new BaseResponse<CreateAccountViewModel>
                    {
                        Description = $"Клиента с Id = {model.ClientId} не существует.",
                        StatusCode = StatusCode.ClientNotFound,
                    };
                }

                var account = await _accountRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.AccountNumber.Equals(model.AccountNumber));

                if (account != null)
                {
                    return new BaseResponse<CreateAccountViewModel>
                    {
                        Description = $"Счет с номером \"{model.AccountNumber}\" уже существует.",
                        StatusCode = StatusCode.AccountAlreadyExists,
                    };
                }

                account = new AccountEntity
                {
                    AccountNumber = model.AccountNumber,
                    OpeningDate = DateTime.Now,
                    Balance = model.Balance,
                    AccountType = model.AccountType,
                    CreditLimit = model.CreditLimit,
                    ClientId = model.ClientId,
                };

                await _accountRepository.Create(account);

                return new BaseResponse<CreateAccountViewModel>
                {
                    Description = "Счет создан",
                    StatusCode = StatusCode.Ok,
                };
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"[BankService.CreateAccount]: {exception.Message}");
                return new BaseResponse<CreateAccountViewModel>
                {
                    Description = $"{exception.Message}",
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<AccountViewModel>> DeleteAccount(int id)
        {
            try
            {
                var account = await _accountRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (account == null)
                {
                    return new BaseResponse<AccountViewModel>
                    {
                        Description = $"Счета с Id = {id} не существует.",
                        StatusCode = StatusCode.AccountNotFound,
                    };
                }

                await _accountRepository.Delete(account);

                return new BaseResponse<AccountViewModel>
                {
                    Description = $"Счет с Id = {id} удален.",
                    StatusCode = StatusCode.Ok,
                };
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"[BankService.DeleteAccount]: {exception.Message}");
                return new BaseResponse<AccountViewModel>
                {
                    Description = $"{exception.Message}",
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<UpdateAccountViewModel>> UpdateAccount(UpdateAccountViewModel model)
        {
            try
            {
                var account = await _accountRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == model.Id);

                if (account == null)
                {
                    return new BaseResponse<UpdateAccountViewModel>
                    {
                        Description = $"Счет с Id = {model.Id} не найден.",
                        StatusCode = StatusCode.AccountNotFound,
                    };
                }

                account.AccountNumber = model.AccountNumber;
                account.Balance = model.Balance.Value;
                account.AccountType = model.AccountType.Value;
                account.CreditLimit = model.CreditLimit;

                if (model.ClientId != null)
                {
                    var client = await _clientRepository.GetAll()
                        .FirstOrDefaultAsync(x => x.Id == model.ClientId);

                    if (client == null)
                    {
                        return new BaseResponse<UpdateAccountViewModel>
                        {
                            Description = $"Клиент с Id = {model.ClientId} не найден.",
                            StatusCode = StatusCode.ClientNotFound,
                        };
                    }

                    account.Client = client;
                }
                else
                {
                    account.Client = null;
                }

                await _accountRepository.Update(account);

                return new BaseResponse<UpdateAccountViewModel>
                {
                    Description = $"Счет с Id = {model.Id} обновлен (Put).",
                    StatusCode = StatusCode.Ok,
                };
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"[BankService.UpdateAccount]: {exception.Message}");
                return new BaseResponse<UpdateAccountViewModel>
                {
                    Description = $"{exception.Message}",
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<UpdateAccountViewModel>> PatchAccount(UpdateAccountViewModel model)
        {
            try
            {
                var account = await _accountRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == model.Id);

                if (account == null)
                {
                    return new BaseResponse<UpdateAccountViewModel>
                    {
                        Description = $"Счет с Id = {model.Id} не найден.",
                        StatusCode = StatusCode.AccountNotFound,
                    };
                }

                account.AccountNumber = model.AccountNumber == null ? account.AccountNumber : model.AccountNumber;
                account.Balance = model.Balance == null ? account.Balance : model.Balance.Value;
                account.AccountType = model.AccountType == null ? account.AccountType : model.AccountType.Value;
                account.CreditLimit = model.CreditLimit == null ? account.CreditLimit : model.CreditLimit;

                if (model.ClientId != null)
                {
                    var client = await _clientRepository.GetAll()
                        .FirstOrDefaultAsync(x => x.Id == model.ClientId);

                    if (client == null)
                    {
                        return new BaseResponse<UpdateAccountViewModel>
                        {
                            Description = $"Клиент с Id = {model.ClientId} не найден.",
                            StatusCode = StatusCode.ClientNotFound,
                        };
                    }

                    account.Client = client;
                }

                await _accountRepository.Update(account);

                return new BaseResponse<UpdateAccountViewModel>
                {
                    Description = $"Счет с Id = {model.Id} обновлен (Patch).",
                    StatusCode = StatusCode.Ok,
                };
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"[BankService.PatchAccount]: {exception.Message}");
                return new BaseResponse<UpdateAccountViewModel>
                {
                    Description = $"{exception.Message}",
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<AccountViewModel>>> GetAllAccounts()
        {
            try
            {
                var accounts = await _accountRepository.GetAll()
                    .Select(x => new AccountViewModel
                    {
                        Id = x.Id,
                        AccountNumber = x.AccountNumber,
                        OpeningDate = x.OpeningDate.ToString("dd.MM.yyyy"),
                        Balance = x.Balance,
                        AccountType = x.AccountType.GetDisplayName(),
                        CreditLimit = x.CreditLimit,
                    })
                    .ToListAsync();

                return new BaseResponse<IEnumerable<AccountViewModel>>
                {
                    Data = accounts,
                    StatusCode = StatusCode.Ok,
                };
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"[BankService.GetAllAccounts]: {exception.Message}");
                return new BaseResponse<IEnumerable<AccountViewModel>>
                {
                    Description = $"{exception.Message}",
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
        #endregion

        #region LegalClient
        public async Task<IBaseResponse<CreateLegalClientViewModel>> CreateLegalClient(CreateLegalClientViewModel model)
        {
            try
            {
                var legalClient = await _legalClientRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Name.Equals(model.Name));

                if (legalClient != null)
                {
                    return new BaseResponse<CreateLegalClientViewModel>
                    {
                        Description = $"Юридическое лицо с названием \"{model.Name}\" уже существует.",
                        StatusCode = StatusCode.LegalClientAlreadyExists,
                    };
                }

                var client = new ClientEntity
                {
                    Type = ClientType.Legal
                };

                await _clientRepository.Create(client);

                legalClient = new LegalClientEntity
                {
                    Id = client.Id,
                    Name = model.Name,
                    Address = model.Address,
                    LeaderFullname = model.LeaderFullname,
                    ChiefAccountantFullname = model.ChiefAccountantFullname,
                    Phone = model.Phone,
                    OwnershipsForm = model.OwnershipsForm
                };

                await _legalClientRepository.Create(legalClient);

                return new BaseResponse<CreateLegalClientViewModel>
                {
                    Description = $"Юридическое лицо с названием \"{model.Name}\" создано.",
                    StatusCode = StatusCode.Ok,
                };
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"[BankService.CreateLegalClient]: {exception.Message}");
                return new BaseResponse<CreateLegalClientViewModel>
                {
                    Description = $"{exception.Message}",
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<LegalClientViewModel>> DeleteLegalClient(int id)
        {
            try
            {
                var legalClient = await _legalClientRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == id);

                var client = await _clientRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (client == null || legalClient == null)
                {
                    return new BaseResponse<LegalClientViewModel>
                    {
                        Description = $"Юридического лица с Id = {id} не существует.",
                        StatusCode = StatusCode.LegalClientNotFound,
                    };
                }

                await _legalClientRepository.Delete(legalClient);
                await _clientRepository.Delete(client);

                return new BaseResponse<LegalClientViewModel>
                {
                    Description = $"Юридическое лицо с Id = {id} удалено.",
                    StatusCode = StatusCode.Ok,
                };
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"[BankService.DeleteLegalClient]: {exception.Message}");
                return new BaseResponse<LegalClientViewModel>
                {
                    Description = $"{exception.Message}",
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<UpdateLegalClientViewModel>> UpdateLegalClient(UpdateLegalClientViewModel model)
        {
            try
            {
                var legalClient = await _legalClientRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == model.Id);

                if (legalClient == null)
                {
                    return new BaseResponse<UpdateLegalClientViewModel>
                    {
                        Description = $"Юридического лица с Id = {model.Id} не существует.",
                        StatusCode = StatusCode.LegalClientNotFound,
                    };
                }

                legalClient.Name = model.Name;
                legalClient.Address = model.Address;
                legalClient.LeaderFullname = model.LeaderFullname;
                legalClient.ChiefAccountantFullname = model.ChiefAccountantFullname;
                legalClient.Phone = model.Phone;
                legalClient.OwnershipsForm = model.OwnershipsForm.Value;

                await _legalClientRepository.Update(legalClient);

                return new BaseResponse<UpdateLegalClientViewModel>
                {
                    Description = $"Юридическое лицо с Id = {model.Id} обновлено (Update).",
                    StatusCode = StatusCode.Ok,
                };
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"[BankService.UpdateLegalClient]: {exception.Message}");
                return new BaseResponse<UpdateLegalClientViewModel>
                {
                    Description = $"{exception.Message}",
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<UpdateLegalClientViewModel>> PatchLegalClient(UpdateLegalClientViewModel model)
        {
            try
            {
                var legalClient = await _legalClientRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.Id == model.Id);

                if (legalClient == null)
                {
                    return new BaseResponse<UpdateLegalClientViewModel>
                    {
                        Description = $"Юридического лица с Id = {model.Id} не существует.",
                        StatusCode = StatusCode.LegalClientNotFound,
                    };
                }

                legalClient.Name = model.Name == null ? legalClient.Name : model.Name;
                legalClient.Address = model.Address == null ? legalClient.Address : model.Address;
                legalClient.LeaderFullname = model.LeaderFullname == null ? legalClient.LeaderFullname : model.LeaderFullname;
                legalClient.ChiefAccountantFullname = model.ChiefAccountantFullname == null ? legalClient.ChiefAccountantFullname
                    : model.ChiefAccountantFullname;
                legalClient.Phone = model.Phone == null ? legalClient.Phone : model.Phone;
                legalClient.OwnershipsForm = model.OwnershipsForm == null ? legalClient.OwnershipsForm : model.OwnershipsForm.Value;

                await _legalClientRepository.Update(legalClient);

                return new BaseResponse<UpdateLegalClientViewModel>
                {
                    Description = $"Юридическое лицо с Id = {model.Id} обновлено (Patch).",
                    StatusCode = StatusCode.Ok,
                };
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"[BankService.PatchLegalClient]: {exception.Message}");
                return new BaseResponse<UpdateLegalClientViewModel>
                {
                    Description = $"{exception.Message}",
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<LegalClientViewModel>>> GetAllLegalClients()
        {
            try
            {
                var legalClients = await _legalClientRepository.GetAll()
                    .Select(x => new LegalClientViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Address = x.Address,
                        LeaderFullname = x.LeaderFullname,
                        ChiefAccountantFullname = x.ChiefAccountantFullname,
                        Phone = x.Phone,
                        OwnershipsForm = x.OwnershipsForm.GetDisplayName(),
                    })
                    .ToListAsync();

                return new BaseResponse<IEnumerable<LegalClientViewModel>>
                {
                    Data = legalClients,
                    StatusCode = StatusCode.Ok,
                };
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"[BankService.GetAllLegalClients]: {exception.Message}");
                return new BaseResponse<IEnumerable<LegalClientViewModel>>
                {
                    Description = $"{exception.Message}",
                    StatusCode = StatusCode.InternalServerError,
                };
            }
        }
        #endregion
    }
}
