using System.ComponentModel.DataAnnotations;

namespace PaymentSchedule.Request
{    
    public class LoansRequest
    {
        [Required(ErrorMessage = "O valor do empréstimo é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor do empréstimo deve ser maior que zero.")]
        public decimal LoanAmount { get; set; }

        [Required(ErrorMessage = "A taxa de juros anual é obrigatória.")]
        [Range(0.01, 1.0, ErrorMessage = "A taxa de juros anual deve estar entre 0 e 1.")]
        public decimal AnnualInterestRate { get; set; }

        [Required(ErrorMessage = "O número de meses é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "O número de meses deve ser maior que zero.")]
        public int NumberOfMonths { get; set; }
    }
}
