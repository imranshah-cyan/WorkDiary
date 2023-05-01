using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorkDiaryRepository.Dbo;
using WorkDiaryServices.Classes;

namespace ServiceDotNet.Api.Controllers
{
    [RoutePrefix("api/buyer")]
    public class BuyerController : ApiController
    {
        //[Authorize]
        [HttpPost]
        [Route("providers/{buyer_Id}")]
        public List<GetBuyerProviders_Result> GetBuyerProviders(int? buyer_Id)
        {
            return new BuyerService().BuyerProviders(buyer_Id);
        }

        [HttpGet]
        [Route("totalJobs/{buyer_Id}")]
        public int? BuyerProvidersCount(int buyer_Id)
        {
            return new JobService().TotalJobsByBuyer(buyer_Id);
        }
        
        [HttpGet]
        [Route("totalProviders/{buyer_Id}")]
        public int BuyerProvidersCount(int? buyer_Id)
        {
            return new BuyerService().BuyerProvidersCount(buyer_Id);
        }
    }
}
