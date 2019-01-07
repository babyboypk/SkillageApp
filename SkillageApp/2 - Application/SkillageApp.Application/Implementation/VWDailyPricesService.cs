using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SkillageApp.App.Interfaces;
using SkillageApp.App.ViewModels;
using SkillageApp.Data.Entities;
using SkillageApp.Data.IRepositories;
using SkillageApp.Infrastructure.Interfaces;
using SkillageApp.Utilities.Dtos;

namespace SkillageApp.App.Implementation
{
    public class VWDailyPricesService : IVWDailyPricesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVWDailyPricesRepository _vwDailyPricesRepository;

        public VWDailyPricesService(IUnitOfWork unitOfWork,IVWDailyPricesRepository vwDailyPricesRepository)
        {
            _unitOfWork = unitOfWork;
            _vwDailyPricesRepository = vwDailyPricesRepository;
        }

        public List<VWDailyPricesViewModel> GetAll()
        {
            return _vwDailyPricesRepository.FindAll().ProjectTo<VWDailyPricesViewModel>().ToList();
        }

        public PagedResult<VWDailyPricesViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _vwDailyPricesRepository.FindAll();

            int totalRow = query.Count();

            query = query.OrderByDescending(x => x.Date)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ProjectTo<VWDailyPricesViewModel>().ToList();

            var paginationSet = new PagedResult<VWDailyPricesViewModel>
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public VWDailyPricesViewModel GetById(int id)
        {
            return Mapper.Map<VWDailyPrices, VWDailyPricesViewModel>(_vwDailyPricesRepository.FindById(id));
        }
    }
}