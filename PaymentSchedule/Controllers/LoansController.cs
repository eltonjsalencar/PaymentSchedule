using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentSchedule.Interfaces;
using PaymentSchedule.Request;
using PaymentSchedule.Response;

namespace PaymentSchedule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILoansSimulateService _loansSimulateService;

        public LoansController(ILoansSimulateService loansSimulateService)
        {
            _loansSimulateService = loansSimulateService;
        }
        
        [HttpPost("simulate")]
        public ActionResult<LoansSimulateResponse> SimulateLoan([FromBody] LoansRequest loanRequest)
        {            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _loansSimulateService.SaveProposta(loanRequest);
            var response = _loansSimulateService.SimulateLoan(loanRequest.LoanAmount, loanRequest.AnnualInterestRate, loanRequest.NumberOfMonths);
            _loansSimulateService.SavePaymentFlowSummary(response);

            return Ok(response);
        }
    }
}
