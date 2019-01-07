using System.Collections.Generic;
using System.Data.Entity;
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
    public class DailyPricesService : IDailyPricesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDailyPricesRepository _dailyPricesRepository;

        public DailyPricesService(IUnitOfWork unitOfWork,IDailyPricesRepository dailyPricesRepository)
        {
            _unitOfWork = unitOfWork;
            _dailyPricesRepository = dailyPricesRepository;
        }

        public void Add(DailyPricesViewModel dailyPricesVm)
        {
            var dailyPrices = Mapper.Map<DailyPricesViewModel, DailyPrices>(dailyPricesVm);
           
            _dailyPricesRepository.Add(dailyPrices);
        }

        public void Update(DailyPricesViewModel dailyPricesVm)
        {
            var dailyPrices = _dailyPricesRepository.FindById(dailyPricesVm.Id);

            Mapper.Map(dailyPricesVm, dailyPrices);

            _dailyPricesRepository.Update(dailyPrices);
        }

        public void Delete(int id)
        {
            _dailyPricesRepository.Remove(id);
        }

        public List<DailyPricesViewModel> GetAll()
        {
            var queryable = _dailyPricesRepository.FindAll();

            return queryable.ProjectTo<DailyPricesViewModel>().ToList();
        }

        public PagedResult<DailyPricesViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _dailyPricesRepository.FindAll();

            int totalRow = query.Count();

            query = query.OrderByDescending(x => x.Date)
                .Skip((page - 1) * pageSize).Take(pageSize);

            var data = query.ProjectTo<DailyPricesViewModel>().ToList();

            var paginationSet = new PagedResult<DailyPricesViewModel>
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public DailyPricesViewModel GetById(int id)
        {
            var dailyPrices = _dailyPricesRepository.FindById(id);

            return Mapper.Map<DailyPrices, DailyPricesViewModel>(dailyPrices);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}