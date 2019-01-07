using AutoMapper;
using SkillageApp.App.ViewModels;
using SkillageApp.Data.Entities;

namespace SkillageApp.App.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {

            CreateMap<Exchange, ExchangeViewModel>();
            CreateMap<StockSymbol, StockSymbolViewModel>();
            CreateMap<DailyPrices, DailyPricesViewModel>();
            CreateMap<VWDailyPrices, VWDailyPricesViewModel>();
        }
    }
}