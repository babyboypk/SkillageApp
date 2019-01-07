using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SkillageApp.App.ViewModels;
using SkillageApp.Data.Entities;

namespace SkillageApp.App.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ExchangeViewModel, Exchange>();
            CreateMap<StockSymbolViewModel, StockSymbol>();
            CreateMap<DailyPricesViewModel, DailyPrices>();
        }
    }
}
