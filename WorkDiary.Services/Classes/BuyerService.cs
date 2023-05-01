using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryRepository.Classes;
using WorkDiaryRepository.Dbo;
using WorkDiaryServices.Interfaces;

namespace WorkDiaryServices.Classes
{
    public class BuyerService : IBuyerService
    {
        public List<GetBuyerProviders_Result> BuyerProviders(int? buyer_Id)
        {
            return new BuyerRepository().BuyerProviders(buyer_Id);
        }

        public int BuyerProvidersCount(int? buyer_Id)
        {
            return new BuyerRepository().BuyerProvidersCount(buyer_Id);
        }
    }
}

