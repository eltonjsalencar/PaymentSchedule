using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PaymentSchedule.Interfaces;
using PaymentSchedule.Model;
using PaymentSchedule.Request;
using System.Threading.Tasks;


namespace PaymentSchedule.Repositories
{
    public class PropostaRepository : IPropostaRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public PropostaRepository(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> SavePropostaAsync(LoansRequest request)
        {
            var proposta = _mapper.Map<PropostaModel>(request);
                     
            _dbContext.Propostas.Add(proposta);
            await _dbContext.SaveChangesAsync();
                        
            return proposta.Id;
        }
    }

}
