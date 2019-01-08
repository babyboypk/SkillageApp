using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SkillageApp.App.Interfaces;
using SkillageApp.WebAPI.Infrastructure.Core;

namespace SkillageApp.WebAPI.Controllers
{
    [RoutePrefix("api/stockSymbol")]
    public class StockSymbolController : ApiControllerBase
    {
        private readonly IStockSymbolService _stockSymbolService;
        public StockSymbolController(IStockSymbolService stockSymbolService)
        {
            _stockSymbolService = stockSymbolService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var responseData = _stockSymbolService.GetAll();
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}
