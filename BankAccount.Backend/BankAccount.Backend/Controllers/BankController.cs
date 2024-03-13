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
            var response = await _bankService.PatchAccount(model);

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

        #region LegalClient
        [Route("/CreateLegalClient")]
        [HttpPost]
        public async Task<IActionResult> CreateLegalClient(CreateLegalClientViewModel model)
        {
            var response = await _bankService.CreateLegalClient(model);

            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }

            return BadRequest(new { description = response.Description });
        }

        [Route("/DeleteLegalClient")]
        [HttpPost]
        public async Task<IActionResult> DeleteLegalClient([FromQuery] int id)
        {
            var response = await _bankService.DeleteLegalClient(id);

            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }

            return BadRequest(new { description = response.Description });
        }

        [Route("/UpdateLegalClient")]
        [HttpPut]
        public async Task<IActionResult> UpdateLegalClient(UpdateLegalClientViewModel model)
        {
            var response = await _bankService.UpdateLegalClient(model);

            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }

            return BadRequest(new { description = response.Description });
        }

        [Route("/PatchLegalClient")]
        [HttpPatch]
        public async Task<IActionResult> PatchLegalClient(UpdateLegalClientViewModel model)
        {
            var response = await _bankService.PatchLegalClient(model);

            if (response.StatusCode == Domain.Enum.StatusCode.Ok)
            {
                return Ok(new { description = response.Description });
            }

            return BadRequest(new { description = response.Description });
        }

        [Route("/GetAllLegalClients")]
        [HttpGet]
        public async Task<IActionResult> GetAllLegalClients()
        {
            var response = await _bankService.GetAllLegalClients();

            return Json(new { data = response.Data });
        }
        #endregion
    }
}
