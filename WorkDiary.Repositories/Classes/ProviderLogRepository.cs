using ServiceDotNet.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Interfaces;

namespace WorkDiaryRepository
{
    public class ProviderLogRepository : RepositoryBase, IProviderLogRepository
    {

        public SP_GetProviderLogs_Result GetProviderLogs(ProviderLog entity)
        {
            try
            {

                var result = _db.SP_GetProviderLogs(
                                            entity.PROVIDER_ID,
                                            entity.Start_Time,
                                            entity.End_Time
                                        ).FirstOrDefault();

                return result;

            }
            catch
            {
                throw;
            }
        }

        public CheckProviderByBuyerId_Result CheckProviderByBuyerId(ProviderLog entity)
        {
            try
            {

                var result = _db.CheckProviderByBuyerId(
                                            entity.BUYER_ID,
                                            entity.PROVIDER_ID
                                        ).FirstOrDefault();

                return result;

            }
            catch
            {
                throw;
            }
        }

        public SP_GetProviderLogsByJob_Result GetProviderLogsByJob(ProviderLog entity)
        {
            try
            {

                var result = _db.SP_GetProviderLogsByJob(
                                            entity.PROVIDER_ID,
                                            entity.JOB_ID,
                                            entity.Start_Time,
                                            entity.End_Time
                                        ).FirstOrDefault();

                return result;

            }
            catch
            {
                throw;
            }
        }

    }
}