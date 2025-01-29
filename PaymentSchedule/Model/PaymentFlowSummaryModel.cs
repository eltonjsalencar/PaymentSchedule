using PaymentSchedule.Response;

namespace PaymentSchedule.Model
{
    public class PaymentFlowSummaryModel
    {
        public int Id { get; set; } 
        public decimal MonthlyPayment { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal TotalPayment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<PaymentDetailModel> PaymentDetails { get; set; }
    }
}
