using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryRepository.Classes;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Entities;
using WorkDiaryServices.Interfaces;

namespace WorkDiaryServices.Classes
{
    public class OfferService : IOfferService
    {
        public int? AcceptRewardOffer(Offer offer)
        {
            return new OfferRepository().AcceptRewardOffer(offer);
        }

        public int? DeclineOffer(int? Job_Offer_Id, int? Buyer_Id)
        {
            return new OfferRepository().DeclineOffer(Job_Offer_Id, Buyer_Id);
        }

        public List<Web_Offer_GetActiveByBuyerId_Result> GetActiveOffersByBuyerID(int buyer_Id)
        {
            return new OfferRepository().GetActiveOffersByBuyerID(buyer_Id);
        }

        public List<Web_Offer_GetRejectedByBuyerId_Result> GetRejectedOffersByBuyerID(int buyer_Id)
        {
            return new OfferRepository().GetRejectedOffersByBuyerID(buyer_Id);
        }

        public int? SendOffer(Offer offer)
        {
            return new OfferRepository().SendOffer(offer);
        }
    }
}

