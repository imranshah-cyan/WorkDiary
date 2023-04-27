using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryRepository.Dbo;

namespace WorkDiaryRepository.Interfaces
{
    public interface IBuyerRepository
    {
        List<GetBuyerProviders_Result> BuyerProviders(int? buyer_Id);
    }
}
