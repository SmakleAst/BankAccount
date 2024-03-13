using BankAccount.Domain.Response;
using BankAccount.Domain.ViewModels;
using BankAccount.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankAccount.Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankController : Controller
    {
        private readonly IBankService _bankService;

        public BankController(IBankService bankService) =>
            _bankService = bankService;

        #region Account
        [Route("/CreateAccount")]
        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountViewModel model)
        {
            var response = await _bankService.CreateAccount(model);

            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }

            return BadRequest(new { description = response.Description });
        }

        [Route("/DeleteAccount")]
        [HttpPost]
        public async Task<IActionResult> DeleteAccount([FromQuery]int id)
        {
            var response = await _bankService.DeleteAccount(id);

            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }

            return BadRequest(new { description = response.Description });
        }

        [Route("/UpdateAccount")]
        [HttpPut]
        public async Task<IActionResult> UpdateAccount(UpdateAccountViewModel model)
        {
            var response = await _bankService.UpdateAccount(model);

            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }

            return BadRequest(new { description = response.Description });
        }

        [Route("/PatchAccount")]
        [HttpPatch]
        public async Task<IActionResult> PatchAccount(UpdateAccountViewModel model)
        {
            var response = await _bankService.UpdateAccount(model);

            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }

            return BadRequest(new { description = response.Description });
        }

        [Route("/GetAllAccounts")]
        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var response = await _bankService.GetAllAccounts();

            return Json(new { data = response.Data });
        }
        #endregion

        //Task<IBaseResponse<CreateLegalClientViewModel>> CreateLegalClient(CreateLegalClientViewModel model);
        //Task<IBaseResponse<LegalClientViewModel>> DeleteLegalClient(int id);
        //Task<IBaseResponse<UpdateLegalClientViewModel>> UpdateLegalClient(UpdateLegalClientViewModel model);
        //Task<IBaseResponse<UpdateLegalClientViewModel>> PatchLegalClient(UpdateLegalClientViewModel model);
        //Task<IBaseResponse<IEnumerable<LegalClientViewModel>>> GetAllLegalClients();
    }
}
