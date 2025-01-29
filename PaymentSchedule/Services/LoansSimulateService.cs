using Azure;
using Azure.Core;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PaymentSchedule.Interfaces;
using PaymentSchedule.Repositories;
using PaymentSchedule.Request;
using PaymentSchedule.Response;

namespace PaymentSchedule.Services
{
    public class LoansSimulateService : ILoansSimulateService
    {
        private readonly IPropostaRepository _propostaRepository;
        private readonly IPaymentFlowSummaryRepository _paymentFlowSummaryRepository;

        public LoansSimulateService(IPropostaRepository propostaRepository
            , IPaymentFlowSummaryRepository paymentFlowSummaryRepository)
        {
            _propostaRepository = propostaRepository;
            _paymentFlowSummaryRepository = paymentFlowSummaryRepository;
        }

        public LoansSimulateResponse SimulateLoan(decimal loanAmount, decimal annualInterestRate, int numberOfMonths)
        {
            decimal taxaJurosMensal = annualInterestRate / 12;
                        
            double i = (double)taxaJurosMensal;
            double n = numberOfMonths;

            // Fórmula da Tabela Price: PMT = P * i * (1+i)^n / ((1+i)^n - 1)
            double potencia = Math.Pow(1 + i, n);
            decimal parcelaMensal = loanAmount * (decimal)((i * potencia) / (potencia - 1));
                        
            decimal saldoDevedor = loanAmount;
            decimal totalJuros = 0;
            var paymentSchedule = new List<PaymentDetail>();

            for (int mes = 1; mes <= numberOfMonths; mes++)
            {                
                decimal jurosMes = saldoDevedor * taxaJurosMensal;
             
                decimal principal = parcelaMensal - jurosMes;
                                
                saldoDevedor -= principal;
                
                totalJuros += jurosMes;
             
                paymentSchedule.Add(new PaymentDetail
                {
                    Month = mes,
                    Principal = Math.Round(principal, 2),
                    Interest = Math.Round(jurosMes, 2),
                    Balance = Math.Round(saldoDevedor > 0 ? saldoDevedor : 0, 2)
                });
            }

            return new LoansSimulateResponse
            {
                MonthlyPayment = Math.Round(parcelaMensal, 2),
                TotalInterest = Math.Round(totalJuros, 2),
                TotalPayment = Math.Round(loanAmount + totalJuros, 2),
                PaymentSchedule = paymentSchedule
            };
        }

        public void SaveProposta(LoansRequest loansRequest)
        {
            _propostaRepository.SavePropostaAsync(loansRequest);
        }

        public void SavePaymentFlowSummary(LoansSimulateResponse response)
        {
            _paymentFlowSummaryRepository.SavePaymentFlowSummaryAsync(response);
        }
    }
}
