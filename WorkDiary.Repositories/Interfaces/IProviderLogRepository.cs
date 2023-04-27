using ServiceDotNet.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryRepository.Dbo;

namespace WorkDiaryRepository.Interfaces
{
    public interface IProviderLogRepository
    {
        SP_GetProviderLogs_Result GetProviderLogs(ProviderLog entity);
        CheckProviderByBuyerId_Result CheckProviderByBuyerId(ProviderLog entity);
        SP_GetProviderLogsByJob_Result GetProviderLogsByJob(ProviderLog entity);
    }
}
