using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryRepository.Dbo;

namespace WorkDiaryServices.Interfaces
{
    public interface IBuyerService
    {
        List<GetBuyerProviders_Result> BuyerProviders(int? buyer_Id);
    }
}
