using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Entities;

namespace WorkDiaryRepository.Interfaces
{
    public interface IOfferRepository
    {
        int? SendOffer(Offer offer);
        int? AcceptRewardOffer(Offer offer);
        int? DeclineOffer(int? Job_Offer_Id, int? Buyer_Id);
        List<Web_Offer_GetActiveByBuyerId_Result> GetActiveOffersByBuyerID(int buyer_Id);
        List<Web_Offer_GetRejectedByBuyerId_Result> GetRejectedOffersByBuyerID(int buyer_Id);
    }

}
