using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using AutoMapper;
using SkillageApp.App.Interfaces;
using SkillageApp.App.ViewModels;
using SkillageApp.WebAPI.Infrastructure.Core;

namespace SkillageApp.WebAPI.Controllers
{
    [RoutePrefix("api/dailyPrices")]
    public class DailyPricesController : ApiControllerBase
    {
        #region Initialize

        private readonly IDailyPricesService _dailyPricesService;
        public DailyPricesController(IDailyPricesService dailyPricesService)
        {
            _dailyPricesService = dailyPricesService;
        }

        #endregion

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var responseData = _dailyPricesService.GetAll();
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getAllPaging")]
        [HttpPost]
        public HttpResponseMessage GetAllPaging(HttpRequestMessage request)
        {
            //Get Page Size Form Request
            var pageSize = Convert.ToInt32(HttpContext.Current.Request.Params["pageSize"]);

            //Get Page Index From Request
            var page = Convert.ToInt32(HttpContext.Current.Request.Params["page"]);

            return CreateHttpResponse(request, () =>
            {
                var responseData = _dailyPricesService.GetAllPaging("", page, pageSize);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("detail/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var responseData = _dailyPricesService.GetById(id);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, DailyPricesViewModel dailyPricesVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _dailyPricesService.Update(dailyPricesVM);
                    _dailyPricesService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK, dailyPricesVM);

                }

                return response;
            });
        }
    }
}
