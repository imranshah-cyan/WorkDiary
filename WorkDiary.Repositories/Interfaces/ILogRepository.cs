﻿using ServiceDotNet.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Entities;

namespace WorkDiaryRepository.Interfaces
{
    public interface ILogRepository
    {
        SP_WorkDiaryAppLogs_Result GetLogs(Log entity);
        CheckProviderByBuyerId_Result CheckProviderByBuyerId(Log entity);
    }
}
