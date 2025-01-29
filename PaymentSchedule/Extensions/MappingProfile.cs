using AutoMapper;
using PaymentSchedule.Model;
using PaymentSchedule.Request;
using PaymentSchedule.Response;

namespace PaymentSchedule.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Configuração do mapeamento de LoansSimulateRequest para Proposta
            CreateMap<LoansRequest, PropostaModel>();

            CreateMap<LoansSimulateResponse, PaymentFlowSummaryModel>()
            .ForMember(dest => dest.MonthlyPayment, opt => opt.MapFrom(src => src.MonthlyPayment))
            .ForMember(dest => dest.TotalInterest, opt => opt.MapFrom(src => src.TotalInterest))
            .ForMember(dest => dest.TotalPayment, opt => opt.MapFrom(src => src.TotalPayment))
            .ForMember(dest => dest.PaymentDetails, opt => opt.MapFrom(src => src.PaymentSchedule));

            // Mapeamento de cada PaymentDetail
            CreateMap<PaymentDetail, PaymentDetailModel>()
                .ForMember(dest => dest.Month, opt => opt.MapFrom(src => src.Month))
                .ForMember(dest => dest.Principal, opt => opt.MapFrom(src => src.Principal))
                .ForMember(dest => dest.Interest, opt => opt.MapFrom(src => src.Interest))
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(src => src.Balance));
        }
    }

}
