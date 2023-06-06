
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Entities;
using WorkDiaryServices.Classes;

namespace ServiceDotNet.Api.Controllers
{
    [RoutePrefix("api/offers")]
    public class OffersController : ApiController
    {
        //Add New Offer
        [HttpPost]
        [Route("SendOffer")]
        public int? SendOffer(Offer offer)
        {
            return new OfferService().SendOffer(offer);
        }

        //Accept Offer
        [HttpPost]
        [Route("AcceptRewardOffer")]
        public int? AcceptRewardOffer(Offer offer)
        {
            return new OfferService().AcceptRewardOffer(offer);
        }

        //Decline Offer
        [HttpPost]
        [Route("DeclineOffer")]
        public int? DeclineOffer(int? Job_Offer_Id, int? Buyer_Id)
        {
            return new OfferService().DeclineOffer(Job_Offer_Id, Buyer_Id);
        }

        //Get Offers by Buyer Id
        [HttpGet]
        [Route("GetActiveOffersByBuyerId")]
        public List<Web_Offer_GetActiveByBuyerId_Result> GetOffersByBuyerID(int buyer_Id)
        {
            return new OfferService().GetActiveOffersByBuyerID(buyer_Id).ToList();
        }

        [HttpGet]
        [Route("GetRejectedOffersByBuyerId")]
        public List<Web_Offer_GetRejectedByBuyerId_Result> GetRejectedOffersByBuyerID(int buyer_Id)
        {
            return new OfferService().GetRejectedOffersByBuyerID(buyer_Id).ToList();
        }

    }
}
