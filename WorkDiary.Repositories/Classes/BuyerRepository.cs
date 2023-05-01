using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Interfaces;

namespace WorkDiaryRepository.Classes
{
    public class BuyerRepository : RepositoryBase, IBuyerRepository
    {
        public List<GetBuyerProviders_Result> BuyerProviders(int? buyer_Id)
        {
            return _db.GetBuyerProviders(buyer_Id).ToList();
        }

        public int BuyerProvidersCount(int? buyer_Id)
        {
            object result = _db.Web_TotalProvidersByBuyer(buyer_Id).FirstOrDefault();
            
            int count = Convert.ToInt32(result);
            return count;
        }
    }
}
