using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    public class ExchangeService : IExchangeService
    {
        private readonly IExchangeRepository _exchangeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ExchangeService(IExchangeRepository exchangeRepository, IUnitOfWork unitOfWork)
        {
            _exchangeRepository = exchangeRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(ExchangeViewModel exchangeVm)
        {
            var exchange = Mapper.Map<ExchangeViewModel, Exchange>(exchangeVm);
            _exchangeRepository.Add(exchange);
        }

        public void Delete(int id)
        {
            _exchangeRepository.Remove(id);
        }

        public List<ExchangeViewModel> GetAll()
        {
            return _exchangeRepository.FindAll(x => !x.IsDeleted).ProjectTo<ExchangeViewModel>().ToList();
        }

        public PagedResult<ExchangeViewModel> GetAllPaging(string keyword, int page, int pageSize)
        {
            var query = _exchangeRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));

            int totalRow = query.Count();
            var data = query.OrderByDescending(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var paginationSet = new PagedResult<ExchangeViewModel>()
            {
                Results = data.ProjectTo<ExchangeViewModel>().ToList(),
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize,
            };

            return paginationSet;
        }

        public ExchangeViewModel GetById(int id)
        {
            return Mapper.Map<Exchange, ExchangeViewModel>(_exchangeRepository.FindById(id));
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(ExchangeViewModel exchangeVm)
        {
            var exchange = _exchangeRepository.FindById(exchangeVm.Id);

            Mapper.Map(exchangeVm, exchange);

            _exchangeRepository.Update(exchange);
        }
    }
}