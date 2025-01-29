using PaymentSchedule.Response;

namespace PaymentSchedule.Interfaces
{
    public interface IPaymentFlowSummaryRepository
    {
        Task<int> SavePaymentFlowSummaryAsync(LoansSimulateResponse response);
    }
}
