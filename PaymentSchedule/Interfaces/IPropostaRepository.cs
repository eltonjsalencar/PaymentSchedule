using PaymentSchedule.Request;

namespace PaymentSchedule.Interfaces
{
    public interface IPropostaRepository
    {
        Task<int> SavePropostaAsync(LoansRequest request);
    }
}
