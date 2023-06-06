using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Entities;
using WorkDiaryRepository.Interfaces;

namespace WorkDiaryRepository.Classes
{
    public class OfferRepository : RepositoryBase, IOfferRepository
    {
        public int? AcceptRewardOffer(Offer offer)
        {
            return (int?)_db.Web_Offer_AcceptOffer_AwardJob(
                                                       offer.Job_Offer_Id,
                                                       offer.Job_Id,
                                                       offer.Provider_Id,
                                                       offer.Buyer_Id, offer.Currency_Id).FirstOrDefault();
        }

        public int? DeclineOffer(int? Job_Offer_Id, int? Buyer_Id)
        {
            return _db.Web_Offer_Reject(Job_Offer_Id, Buyer_Id).FirstOrDefault();
        }

        public List<Web_Offer_GetActiveByBuyerId_Result> GetActiveOffersByBuyerID(int buyer_Id)
        {
            return _db.Web_Offer_GetActiveByBuyerId(buyer_Id).ToList();
        }

        public List<Web_Offer_GetRejectedByBuyerId_Result> GetRejectedOffersByBuyerID(int buyer_Id)
        {
            return _db.Web_Offer_GetRejectedByBuyerId(buyer_Id).ToList();
        }

        public int? SendOffer(Offer offer)
        {
            return _db.Web_Offer_Insert(offer.Job_Id,
                                        offer.Provider_Id,
                                        offer.Buyer_Id,
                                        offer.Currency_Id,
                                        offer.OFFER_AMOUNT,
                                        offer.SERVICE_FEE,
                                        offer.CLIENT_CHARGED,
                                        offer.UPFRONT_PAYMENT,
                                        offer.TIME_REQUIRED,
                                        offer.IS_FIRST_OFFER,
                                        offer.IS_AWARDED,
                                        offer.DESCRIPTION,
                                        offer.TERMS,
                                        offer.CREATED_BY,
                                        offer.IS_OFFER_BUYER
                                        ).FirstOrDefault();
        }
    }
}
