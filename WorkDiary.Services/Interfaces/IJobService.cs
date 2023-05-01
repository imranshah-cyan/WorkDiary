using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryRepository;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Entities;

namespace WorkDiaryServices.Interfaces
{
    public interface IJobService
    {
        int? InsertJob(Job job);
        int? TotalJobsByBuyer(int buyerId);
        List<GetProvidersByJobId_Result> GetProvidersByJobId(int Job_Id, int Buyer_Id);
        List<GetJobsByBuyerId_Result> GetJobsByBuyerId(int Buyer_Id);
        int? InsertScreenShot(IMAGE_STORE entity);
        int? InsertJobSkill(JOB_SKILL entity, string csvSkillIds, int UserId);
        int? UpdateJobs(JOB job);
        int? DeleteJob(int jobId);
        int? Activate(int jobId, bool isActivated);
        List<JobGetAllByUserId_sp_Result> GetJobsByUserId(int UserId, int classId, int cityId, int stateId, string postCode, string searchText, int StatusId);
        JobGetByJobId_sp_Result GetJobByJobId(int JobId);
        List<JobSkillsGetByJobId_sp_Result> GetJobSkillByJobId(int JobId);
        ActiveJobGetByJobId_sp_Result GetActiveJobById(int JobId);
        List<JobOffersGetByJobId_sp_Result> GetJobOffersByJobId(JOB_OFFER jo, int isRequiredFirstOffer, int providerId, int getLastOffer);
        JobOffersGetByJobOfferId_sp_Result GetJobOfferByJobOfferId(int JobOfferId);
        List<JobAwardedGetAllByUserId_sp_Result> GetJobAwardedByUserId(int UserId);
        JobAwardedGetByJobAwardedId_sp_Result GetJobAwardedByJobAwardedId(int JobAwardedId);
        List<MailsGetByJobOfferId_sp_Result> GetJobMessagesByJobOfferId(int jobOfferId);
        List<JobOffersGetByProviderId_sp_Result> GetJobsOffersByProviderId(int UserId, int OfferStatusId);
        int? InsertJobOffer(JOB_OFFER jo);
        int? InsertJobFeedBack(JOB_FEEDBACK jf);
        int? InserUpdateJobAwarded(JOB_AWARDED ja);
        int? JobOfferViewed(int jobOfferId);
        List<JobCounterOffersGetByJobOfferId_sp_Result> GetJobCounterOffersByJobOffer(int jobOfferId, int buyerId, int providerId);
        JobOffersGetLastOfferJobId_sp_Result GetLastOfferByJobId(int JobId, int JobOfferId);
        int? RejectOffer(int JobOfferId);
        List<JobGetAllByBuyerIdForProviderInvitation_sp_Result> GetAllByBuyerIdForProviderInvitation(int UserId, int ProviderId, int JobStatusId);
        JobAwardedGetByJobId_sp_Result GetAwardedJob(int jobId);
        List<JobInProgressByUserId_sp_Result> GetJobsInProgress(int userId, int userType);
        List<TaskTypeGetAll_Result> GetTaskTypes();
        List<TaskStatusGetAll_Result> GetTaskStatus();
        List<TaskPriorityGetAll_Result> GetTaskPriority();
        int? InsertTimeSheet(TIME_SHEET entity);
        int? UpdatetTimeSheet(TIME_SHEET entity);
        int? UpdatetTimeSheetEndTime(TIME_SHEET entity);
        int? DeleteTimeSheet(int timeSheetId);
        List<JobGetAll_sp_Result> GetAllJobs();
        List<SearchingJobsList_sp_Result> GetSearchingJobList(int UserId, int classId, int cityId, int stateId, string postCode, string searchText, int StatusId);
        List<WD_JobTasksByJobId_Result> GetJobsTasks(int selectedJobId, bool isCompletedTasks);
        int? CompleteTask(int taskId);
        List<JobTasksByJobId_Result> GetTasksByJob(int jobId, int typeId, int statusId, int priorityId);
        JobTasksById_Result GetTaskById(int taskId);
        int CreateTask(JOB_TASK task);
        GetUserTimeLog_Result GetUserLog(int userId, int currentJobId, DateTime currentDateTime);
        List<UserLogsGetByHours_Result> GetUserLogByTime(int userId, int jobId, DateTime startTime, DateTime endTime);
        List<GetImagesInGivenTime_Result> GetImagesInGivenTime(int providerId, int jobId, DateTime startTime, DateTime endTime);
    }
}
