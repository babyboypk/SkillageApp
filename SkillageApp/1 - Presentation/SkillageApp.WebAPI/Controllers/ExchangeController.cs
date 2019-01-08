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
    [RoutePrefix("api/exchange")]
    public class ExchangeController : ApiControllerBase
    {
        private readonly IExchangeService _exchangeService;
        public ExchangeController(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var responseData = _exchangeService.GetAll();
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}
