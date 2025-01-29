using Microsoft.EntityFrameworkCore;
using PaymentSchedule.Model;
using PaymentSchedule.Response;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
    public DbSet<PropostaModel> Propostas { get; set; }
    public DbSet<PaymentFlowSummaryModel> PaymentFlowSummaries { get; set; }
    public DbSet<PaymentDetailModel> PaymentDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<PropostaModel>(entity =>
        {
            entity.ToTable("Proposta");
            entity.HasKey(p => p.Id); 
            entity.Property(p => p.LoanAmount).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(p => p.AnnualInterestRate).IsRequired().HasColumnType("decimal(18,4)");
            entity.Property(p => p.NumberOfMonths).IsRequired();
            entity.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
        });

        modelBuilder.Entity<PaymentFlowSummaryModel>(entity =>
        {
            entity.ToTable("PaymentFlowSummary"); // Nome da tabela
            entity.HasKey(p => p.Id); // Chave primária
            entity.Property(p => p.MonthlyPayment).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(p => p.TotalInterest).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(p => p.TotalPayment).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
        });

        modelBuilder.Entity<PaymentDetailModel>(entity =>
        {
            entity.ToTable("PaymentDetail");
            entity.HasKey(d => d.Id);
            entity.Property(d => d.Principal).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(d => d.Interest).IsRequired().HasColumnType("decimal(18,2)");
            entity.Property(d => d.Balance).IsRequired().HasColumnType("decimal(18,2)");

            // Configura a relação entre PaymentDetail e PaymentFlowSummary
            entity.HasOne(d => d.PaymentFlowSummary)
                  .WithMany(s => s.PaymentDetails)
                  .HasForeignKey(d => d.PaymentFlowSummaryId)
                  .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
