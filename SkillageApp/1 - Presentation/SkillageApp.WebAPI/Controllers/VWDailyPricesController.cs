using SkillageApp.WebAPI.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using SkillageApp.App.Interfaces;

namespace SkillageApp.WebAPI.Controllers
{
    [RoutePrefix("api/vwDailyPrices")]
    public class VWDailyPricesController : ApiControllerBase
    {
        private readonly IVWDailyPricesService _vwDailyPricesService;

        public VWDailyPricesController(IVWDailyPricesService vwDailyPricesService)
        {
            _vwDailyPricesService = vwDailyPricesService;
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
                var responseData = _vwDailyPricesService.GetAllPaging("", page, pageSize);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
    }
}
