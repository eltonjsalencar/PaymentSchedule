using PaymentSchedule.Request;
using PaymentSchedule.Response;

namespace PaymentSchedule.Interfaces
{
    public interface ILoansSimulateService
    {
        LoansSimulateResponse SimulateLoan(decimal loanAmount, decimal annualInterestRate, int numberOfMonths);
        void SaveProposta(LoansRequest loansRequest);
        void SavePaymentFlowSummary(LoansSimulateResponse response);
    }
}
