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
    }
}
