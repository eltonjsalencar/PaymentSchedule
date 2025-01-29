using AutoMapper;
using PaymentSchedule.Interfaces;
using PaymentSchedule.Model;
using PaymentSchedule.Response;

namespace PaymentSchedule.Repositories
{
    public class PaymentFlowSummaryRepository : IPaymentFlowSummaryRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public PaymentFlowSummaryRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> SavePaymentFlowSummaryAsync(LoansSimulateResponse response)
        {            
            var summary = _mapper.Map<PaymentFlowSummaryModel>(response);
                        
            _dbContext.PaymentFlowSummaries.Add(summary);
            await _dbContext.SaveChangesAsync();
            
            return summary.Id;
        }
    }
}
