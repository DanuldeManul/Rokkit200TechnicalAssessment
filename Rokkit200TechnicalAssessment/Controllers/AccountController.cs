using Microsoft.AspNetCore.Mvc;
using Rokkit200TechnicalAssessment.Repositories.Interfaces;

namespace Rokkit200TechAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accService;
        public AccountController (IAccountService accService) 
        { 
            _accService = accService;
        }

        [HttpPost]
        public ActionResult CreateSavingsAccount(int Id, long amounToDeposit)
        {
            try
            {
                var result = _accService.OpenSavingsAccount(Id, amounToDeposit);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public ActionResult CreateCurrentAccount(int Id)
        {
            try
            {
                var result = _accService.OpenCurrentAccount(Id);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult Deposit(int Id, long amount)
        {
            try
            {
                var result = _accService.Deposit(Id, amount);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult Withdraw(int Id, long amount)
        {
            try
            {
                var result = _accService.Withdraw(Id, amount);
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
