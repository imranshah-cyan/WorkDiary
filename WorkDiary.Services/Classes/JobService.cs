using System;
using System.Collections.Generic;
using WorkDiaryRepository;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Entities;
using WorkDiaryServices.Interfaces;

namespace WorkDiaryServices.Classes
{
    public class JobService : IJobService
    {
        public int? InsertJob(Job job)
        {
            return new JobRepository().InsertJob(job);
        }

        public int? UpdateJobs(Job job)
        {
            return new JobRepository().UpdateJobs(job);
        }

        public List<Web_GetAllJobStatus_Result> GetAllJobStatuses()
        {
            return new JobRepository().GetAllJobStatuses();
        }

        public List<Web_Classes_Result> GetAllJobClasses()
        {
            return new JobRepository().GetAllJobClasses();
        }

        public int? TotalJobsByBuyer(int buyerId)
        {
            return new JobRepository().TotalJobsByBuyer(buyerId);
        }

        public List<GetProvidersByJobId_Result> GetProvidersByJobId(int Job_Id, int Buyer_Id)
        {
            return new JobRepository().GetProviderByJobId(Job_Id, Buyer_Id);
        }
        public List<GetJobsByBuyerId_Result> GetJobsByBuyerId(int Buyer_Id)
        {
            return new JobRepository().GetJobsByBuyerId(Buyer_Id);
        }
        public int? InsertScreenShot(IMAGE_STORE entity)
        {
            return new JobRepository().InsertScreenShot(entity);

        }
        public int? InsertJobSkill(JOB_SKILL entity, string csvSkillIds, int UserId)
        {
            return new JobRepository().InsertJobSkill(entity, csvSkillIds, UserId);

        }

        public int? UpdateJobs(JOB job)
        {
            return new JobRepository().UpdateJobs(job);
        }

        public int? DeleteJob(int jobId)
        {
            return new JobRepository().DeleteJob(jobId);
        }

        public int? Activate(int jobId,
                             bool isActivated)
        {
            return new JobRepository().Activate(jobId, isActivated);
        }

        public List<JobGetAllByUserId_sp_Result> GetJobsByUserId(int UserId, int classId, int cityId, int stateId, string postCode, string searchText, int StatusId)
        {
            return new JobRepository().GetJobsByUserId(UserId, classId, cityId, stateId, postCode, searchText, StatusId);

        }

        public JobGetByJobId_sp_Result GetJobByJobId(int JobId)
        {
            return new JobRepository().GetJobByJobId(JobId);
        }

        public List<JobSkillsGetByJobId_sp_Result> GetJobSkillByJobId(int JobId)
        {
            return new JobRepository().GetJobSkillByJobId(JobId);
        }

        public ActiveJobGetByJobId_sp_Result GetActiveJobById(int JobId)
        {
            return new JobRepository().GetActiveJobById(JobId);
        }

        public List<JobOffersGetByJobId_sp_Result> GetJobOffersByJobId(JOB_OFFER jo, int isRequiredFirstOffer, int providerId, int getLastOffer)
        {
            return new JobRepository().GetJobOffersByJobId(jo, isRequiredFirstOffer, providerId, getLastOffer);
        }


        public JobOffersGetByJobOfferId_sp_Result GetJobOfferByJobOfferId(int JobOfferId)
        {
            return new JobRepository().GetJobOffersByJobOfferId(JobOfferId);
        }


        public List<JobAwardedGetAllByUserId_sp_Result> GetJobAwardedByUserId(int UserId)
        {
            return new JobRepository().GetJobAwardedByUserId(UserId);
        }


        public JobAwardedGetByJobAwardedId_sp_Result GetJobAwardedByJobAwardedId(int JobAwardedId)
        {
            return new JobRepository().GetJobAwardedByJobAwardedId(JobAwardedId);
        }


        public List<MailsGetByJobOfferId_sp_Result> GetJobMessagesByJobOfferId(int jobOfferId)
        {
            return new JobRepository().GetJobMessagesByJobOfferId(jobOfferId);
        }


        public List<JobOffersGetByProviderId_sp_Result> GetJobsOffersByProviderId(int UserId,
                                                                             int OfferStatusId)
        {
            return new JobRepository().GetJobsOffersByProviderId(UserId, OfferStatusId);
        }


        public int? InsertJobOffer(JOB_OFFER jo)
        {
            return new JobRepository().InsertJobOffer(jo);
        }


        public int? InsertJobFeedBack(JOB_FEEDBACK jf)
        {
            return new JobRepository().InsertJobFeedBack(jf);
        }


        public int? InserUpdateJobAwarded(JOB_AWARDED ja)
        {
            return new JobRepository().InserUpdateJobAwarded(ja);
        }


        public int? JobOfferViewed(int jobOfferId)
        {
            return new JobRepository().JobOfferViewed(jobOfferId);
        }


        public List<JobCounterOffersGetByJobOfferId_sp_Result> GetJobCounterOffersByJobOffer(int jobOfferId,
                                                                                        int buyerId,
                                                                                        int providerId)
        {
            return new JobRepository().GetJobCounterOffersByJobOffer(jobOfferId, buyerId, providerId);
        }


        public JobOffersGetLastOfferJobId_sp_Result GetLastOfferByJobId(int JobId,
                                                                   int JobOfferId)
        {
            return new JobRepository().GetLastOfferByJobId(JobId, JobOfferId);
        }


        public int? RejectOffer(int JobOfferId)
        {
            return new JobRepository().RejectOffer(JobOfferId);
        }


        public List<JobGetAllByBuyerIdForProviderInvitation_sp_Result> GetAllByBuyerIdForProviderInvitation(int UserId,
                                                                                                       int ProviderId,
                                                                                                       int JobStatusId)
        {
            return new JobRepository().GetAllByBuyerIdForProviderInvitation(UserId, ProviderId, JobStatusId);
        }

        public JobAwardedGetByJobId_sp_Result GetAwardedJob(int jobId)
        {
            return new JobRepository().GetAwardedJob(jobId);
        }

        public List<JobInProgressByUserId_sp_Result> GetJobsInProgress(int userId,
                                                                   int userType)
        {
            return new JobRepository().GetJobsInProgress(userId, userType);
        }

        public List<TaskTypeGetAll_Result> GetTaskTypes()
        {
            return new JobRepository().GetTaskTypes();
        }

        public List<TaskStatusGetAll_Result> GetTaskStatus()
        {
            return new JobRepository().GetTaskStatus();
        }

        public List<TaskPriorityGetAll_Result> GetTaskPriority()
        {
            return new JobRepository().GetTaskPriority();
        }

        
        public int? InsertTimeSheet(TIME_SHEET entity)
        {
            return new JobRepository().InsertTimeSheet(entity);
        }

        public int? UpdatetTimeSheet(TIME_SHEET entity)
        {
            return new JobRepository().UpdatetTimeSheet(entity);
        }

        public int? UpdatetTimeSheetEndTime(TIME_SHEET entity)
        {
            return new JobRepository().UpdatetTimeSheetEndTime(entity);
        }

        public int? DeleteTimeSheet(int timeSheetId)
        {
            return new JobRepository().DeleteTimeSheet(timeSheetId);
        }


        public List<JobGetAll_sp_Result> GetAllJobs()
        {
            return new JobRepository().GetAllJobs();
        }


        public List<SearchingJobsList_sp_Result> GetSearchingJobList(int UserId, int classId, int cityId, int stateId, string postCode, string searchText, int StatusId)
        {
            return new JobRepository().GetSearchingJobList(UserId, classId, cityId, stateId, postCode, searchText, StatusId);
        }


        public List<WD_JobTasksByJobId_Result> GetJobsTasks(int selectedJobId, bool isCompletedTasks)
        {
            return new JobRepository().GetJobsTasks(selectedJobId, isCompletedTasks);
        }

        public int? CompleteTask(int taskId)
        {
            return new JobRepository().CompleteTask(taskId);
        }

        public List<JobTasksByJobId_Result> GetTasksByJob(int jobId, int typeId, int statusId, int priorityId)
        {
            return new JobRepository().GetTasksByJob(jobId, typeId, statusId, priorityId);
        }

        public JobTasksById_Result GetTaskById(int taskId)
        {
            return new JobRepository().GetTaskById(taskId);
        }

        public int CreateTask(JOB_TASK task)
        {
            return new JobRepository().CreateTask(task);
        }

        public GetUserTimeLog_Result GetUserLog(int userId, int currentJobId, DateTime currentDateTime)
        {
            return new JobRepository().GetUserLog(userId, currentJobId, currentDateTime);
        }

        public List<UserLogsGetByHours_Result> GetUserLogByTime(int userId, int jobId, DateTime startTime, DateTime endTime)
        {
            return new JobRepository().GetUserLogByTime( userId, jobId, startTime, endTime);
        }

        public List<GetImagesInGivenTime_Result> GetImagesInGivenTime(int providerId, int jobId, DateTime startTime, DateTime endTime)
        {
            return new JobRepository().GetImagesInGivenTime(providerId, jobId, startTime, endTime);
        }

        public List<Web_GetAllJobStatus_Result> GetAllJobStatus()
        {
            return new JobRepository().GetAllJobStatus();
        }

        public int? UpdateJobStatus(int? Job_Status_Id, int Job_Id)
        {
            return new JobRepository().UpdateJobStatus(Job_Status_Id, Job_Id);
        }

        public List<Web_GetJobByStatusId_Result> GetJobsByStatusId(int job_Status_Id)
        {
            return new JobRepository().GetJobsByStatusId(job_Status_Id);
        }

        public List<Web_OffersSentAwardedRejected_Result> GetJobsForOffersSentAwardedRejected(int Prov_Id, int Is_Awarded, int Is_Rejected)
        {
            return new JobRepository().GetJobsForOffersSentAwardedRejected(Prov_Id, Is_Awarded, Is_Rejected);
        }

        public List<Web_JobsByStatusForProvider_Result> Web_JobsByStatusForProvider(int Job_Status_Id, int Prov_Id)
        {
            return new JobRepository().Web_JobsByStatusForProvider(Job_Status_Id, Prov_Id);
        }
    }
}
