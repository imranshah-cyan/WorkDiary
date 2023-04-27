using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorkDiaryRepository;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Entities;
using WorkDiaryServices.Classes;

namespace ServiceDotNet.Api.Controllers
{
    [RoutePrefix("api/job")]
    public class JobController : ApiController
    {
        [Route("get/{userId}")]
        [System.Web.Http.HttpGet]
        public IEnumerable<JobInProgressByUserId_sp_Result> Get(int userId)
        {
            return new JobRepository().GetJobsInProgress(userId, 3);
        }

        [Route("detail/{jobId}")]
        [System.Web.Http.HttpGet]
        public JobGetByJobId_sp_Result GetJobDetail(int jobId)
        {
            return new JobRepository().GetJobByJobId(jobId);
        }

        // Add New Job
        [Route("addJob")]
        [System.Web.Http.HttpPost]
        public int? Post([FromBody] Job job)
        {
            int? Job_Id = new JobService().InsertJob(job);
            return Job_Id;
        }

        // List of Providers 
        [Route("GetProviders")]
        [System.Web.Http.HttpGet]
        public List<GetProvidersByJobId_Result> GetProvidersByJobId([FromUri] int JobId, int Buyer_Id)
        {
            return new JobService().GetProvidersByJobId(JobId, Buyer_Id);
        }

        // List of Jobs
        [Route("GetJobsbyBuyerId")]
        [HttpGet]
        public List<GetJobsByBuyerId_Result> GetJobsByBuyerId([FromUri] int Buyer_Id)
        {
            return new JobService().GetJobsByBuyerId(Buyer_Id);
        }
        
    }
}