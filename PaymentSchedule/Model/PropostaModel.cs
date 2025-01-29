namespace PaymentSchedule.Model
{
    public class PropostaModel
    {
        public int Id { get; set; } 
        public decimal LoanAmount { get; set; }
        public decimal AnnualInterestRate { get; set; }
        public int NumberOfMonths { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
