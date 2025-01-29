using System.ComponentModel.DataAnnotations;

namespace PaymentSchedule.Response
{
    public class LoansSimulateResponse
    {
        [Display(Name = "Monthly Payment", Description = "Valor fixo da parcela mensal (decimal). Ex.: 2.364,50.")]
        public decimal MonthlyPayment { get; set; }

        [Display(Name = "Total Interest", Description = "Total pago em juros durante o financiamento (decimal). Ex.: 20.580,30.")]
        public decimal TotalInterest { get; set; }

        [Display(Name = "Total Payment", Description = "Valor total pago ao final do financiamento (decimal). Ex.: 5.500,00.")]
        public decimal TotalPayment { get; set; }

        [Display(Name = "Payment Schedule", Description = "Lista detalhada do cronograma de pagamentos (List<PaymentDetail>).")]
        public required List<PaymentDetail> PaymentSchedule { get; set; }
    }

    public class PaymentDetail
    {
        [Display(Name = "Month", Description = "Número da parcela (int). Ex.: 2.")]
        public int Month { get; set; }

        [Display(Name = "Principal", Description = "Valor amortizado (decimal). Ex.: 5.500,00.")]
        public decimal Principal { get; set; }

        [Display(Name = "Interest", Description = "Valor dos juros da parcela (decimal). Ex.: 500,00.")]
        public decimal Interest { get; set; }

        [Display(Name = "Balance", Description = "Saldo devedor após o pagamento (decimal). Ex.: 5.000,00.")]
        public decimal Balance { get; set; }
    }

}
