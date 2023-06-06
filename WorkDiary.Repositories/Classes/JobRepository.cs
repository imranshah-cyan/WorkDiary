using System;
using System.Collections.Generic;
using System.Linq;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Entities;
using WorkDiaryRepository.Interfaces;

namespace WorkDiaryRepository
{
    public class JobRepository : RepositoryBase, IJobRepository
    {
        public int? InsertJob(Job job)
        {
            try
            {
                int? Job_Id = 0;
                Job_Id = _db.JobInsert_sp(
                    job.USER_ID,
                    job.JOB_TYPE_ID,
                    job.JOB_STATUS_ID,
                    job.JOB_TITLE,
                    job.CLASS_ID,
                    job.DESCRIPTION,
                    job.APPROXIMATE_DURATION,
                    job.APPROXIMATE_BUDGET,
                    job.DURATION,
                    job.HOURLY_RATE,
                    job.HOURS_PER_WEEK,
                    job.ON_SITE_WORK,
                    job.SITE_LOCATION_REGION_ID,
                    job.SITE_LOCATION_CITY_ID,
                    job.SITE_LOCATION_POSTCODE,
                    job.OFFER_SUBMIT_DAYS,
                    job.WORK_START,
                    job.WORK_START_IMMIDIATELY,
                    job.WORK_START_ON_DATE,
                    job.JOB_VIEW_IS_PUBLIC,
                    job.OFFER_AMOUNT_IS_PUBLIC,
                    job.CREATED_BY,
                    job.CURRENCY_ID,        
                    job.RATE_TYPE_ID,        
                    job.RATE           
                    ).FirstOrDefault();
                return Job_Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<Web_GetAllJobStatus_Result> GetAllJobStatuses()
        {
            try
            {
                return _db.Web_GetAllJobStatus().ToList();
            }
            catch
            {
                throw;
            }
        }

        public int? TotalJobsByBuyer(int buyerId)
        {
            return _db.Web_TotalJobsByBuyer(buyerId).FirstOrDefault();
        }

        public List<GetProvidersByJobId_Result> GetProviderByJobId(int Job_Id, int Buyer_Id)
        {
            try
            {
                var results = _db.GetProvidersByJobId(Job_Id, Buyer_Id);
                return results.ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public List<GetJobsByBuyerId_Result> GetJobsByBuyerId(int Buyer_Id)
        {
            try
            {
                var results = _db.GetJobsByBuyerId(Buyer_Id);
                return results.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public int? InsertScreenShot(IMAGE_STORE entity)
        {
            try
            {
                int? id = 0;
                _db.IMAGE_STORE.Add(entity);
                _db.SaveChanges();
                id = entity.IMAGE_ID;
                return id;

            }
            catch
            {
                throw;
            }
        }

        public int? UpdateJobs(JOB entity)
        {
            try
            {
                int? jobId = 0;

                jobId = _db.JobUpdate_sp(entity.JOB_ID,
                    entity.USER_ID,
                    entity.JOB_TYPE_ID,
                    entity.JOB_STATUS_ID,
                    entity.JOB_TITLE,
                    entity.DESCRIPTION,
                    entity.APPROXIMATE_DURATION,
                    entity.APPROXIMATE_BUDGET,
                    entity.DURATION,
                    entity.HOURLY_RATE,
                    entity.HOURS_PER_WEEK,
                    entity.ON_SITE_WORK,
                    entity.SITE_LOCATION_REGION_ID,
                    entity.SITE_LOCATION_CITY_ID,
                    entity.SITE_LOCATION_POSTCODE,
                    entity.OFFER_SUBMIT_DAYS,
                    entity.WORK_START,
                    entity.WORK_START_IMMIDIATELY,
                    entity.WORK_START_ON_DATE,
                    entity.JOB_VIEW_IS_PUBLIC,
                    entity.OFFER_AMOUNT_IS_PUBLIC
                    ).FirstOrDefault();

                return jobId;

            }
            catch
            {
                throw;
            }
        }

        public int? DeleteJob(int jobId)
        {
            int result = 0;
            var firstOrDefault = _db.DeleteJob(jobId).FirstOrDefault();
            if (firstOrDefault != null) result = (int)firstOrDefault;
            return result;
        }

        public int? Activate(int jobId,
            bool isActivated)
        {
            int result = 0;
            var firstOrDefault = _db.ActivateJob(jobId, isActivated).FirstOrDefault();
            if (firstOrDefault != null)
                result = (int)firstOrDefault;
            return result;
        }

        public int? InsertJobSkill(JOB_SKILL entity,
            string csvSkillIds,
            int UserId)
        {
            try
            {
                int? jobSkillId = 0;

                jobSkillId = _db.JobSkillInsert_sp(entity.JOB_ID,
                    entity.CLASS_ID,
                    UserId,
                    csvSkillIds + ",").FirstOrDefault();

                return jobSkillId;

            }
            catch
            {
                throw;
            }
        }

        public List<JobGetAllByUserId_sp_Result> GetJobsByUserId(int UserId,
            int classId,
            int cityId,
            int stateId,
            string postCode,
            string searchText,
            int StatusId)
        {
            try
            {
                return
                    _db.JobGetAllByUserId_sp(UserId, classId, cityId, stateId, postCode, searchText, StatusId).ToList();
            }
            catch
            {
                throw;
            }
        }

        public JobGetByJobId_sp_Result GetJobByJobId(int JobId)
        {
            try
            {
                return _db.JobGetByJobId_sp(JobId).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public List<JobSkillsGetByJobId_sp_Result> GetJobSkillByJobId(int JobId)
        {
            try
            {
                return _db.JobSkillsGetByJobId_sp(JobId).ToList();
            }
            catch
            {
                throw;
            }
        }

        public ActiveJobGetByJobId_sp_Result GetActiveJobById(int JobId)
        {
            try
            {
                return _db.ActiveJobGetByJobId_sp(JobId).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public List<JobOffersGetByJobId_sp_Result> GetJobOffersByJobId(JOB_OFFER jo,
            int isRequiredFirstOffer,
            int providerId,
            int getLastOffer)
        {
            try
            {
                int jobId = (int)jo.JOB_ID;

                return
                    _db.JobOffersGetByJobId_sp(jobId, jo.IS_OFFER_BY_BUYER, jo.IS_FIRST_OFFER, jo.JOB_OFFER_ID,
                        isRequiredFirstOffer, providerId, getLastOffer).ToList();
            }
            catch
            {
                throw;
            }
        }

        public JobOffersGetByJobOfferId_sp_Result GetJobOffersByJobOfferId(int JobOfferId)
        {
            try
            {
                return _db.JobOffersGetByJobOfferId_sp(JobOfferId).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public List<JobAwardedGetAllByUserId_sp_Result> GetJobAwardedByUserId(int UserId)
        {
            try
            {
                return _db.JobAwardedGetAllByUserId_sp(UserId).ToList();
            }
            catch
            {
                throw;
            }
        }

        public JobAwardedGetByJobAwardedId_sp_Result GetJobAwardedByJobAwardedId(int JobAwardedId)
        {
            try
            {
                return _db.JobAwardedGetByJobAwardedId_sp(JobAwardedId).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public List<MailsGetByJobOfferId_sp_Result> GetJobMessagesByJobOfferId(int jobOfferId)
        {
            try
            {
                return _db.MailsGetByJobOfferId_sp(jobOfferId).ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<JobOffersGetByProviderId_sp_Result> GetJobsOffersByProviderId(int UserId,
            int OfferStatusId)
        {
            try
            {
                return _db.JobOffersGetByProviderId_sp(UserId, OfferStatusId).ToList();
            }
            catch
            {
                throw;
            }
        }




        public int? InsertJobOffer(JOB_OFFER jo)
        {
            try
            {
                return _db.JobOfferInsert_sp(jo.JOB_ID,
                    jo.PROVIDER_ID,
                    jo.BUYER_ID,
                    jo.CURRENCY_ID,
                    jo.OFFER_AMOUNT,
                    jo.SERVICE_FEE,
                    jo.CLIENT_CHARGED,
                    jo.UPFRONT_PAYMENT,
                    jo.TIME_REQUIRED,
                    jo.IS_FIRST_OFFER,
                    jo.IS_AWARDED,
                    jo.DESCRIPTION,
                    jo.TERMS,
                    jo.CREATED_BY,
                    jo.IS_OFFER_BY_BUYER).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }


        public int? InsertJobFeedBack(JOB_FEEDBACK jf)
        {
            return
                _db.JobFeedBackInsert_sp(jf.JOB_AWARDED_ID, jf.BUYER_ID, jf.PROVIDER_ID, jf.FEEDBACK_FOR_USER_ID,
                    jf.QUALITY_OF_WORK_RATING, jf.COMMUNICATION_RATING, jf.ON_BUDGET_RATING,
                    jf.ON_TIME_RATING, jf.CREATED_BY).FirstOrDefault();
        }


        public int? InserUpdateJobAwarded(JOB_AWARDED ja)
        {
            return _db.JobAwardedInsertUpdate_sp(ja.JOB_OFFER_ID, ja.JOB_AWARDED_ID,
                ja.JOB_ID,
                ja.BUYER_ID,
                ja.PROVIDER_ID,
                ja.CURRENCY_ID,
                ja.AMOUNT,
                ja.BUYER_REVIEW,
                ja.PROVIDER_REVIEW).FirstOrDefault();
        }

        public int? RejectOffer(int JobOfferId)
        {
            return Convert.ToInt32(_db.RejectJobOffer_sp(JobOfferId).FirstOrDefault());
        }

        public int? JobOfferViewed(int jobOfferId)
        {
            return _db.JobOfferViewd_sp(jobOfferId).FirstOrDefault();
        }


        public List<JobCounterOffersGetByJobOfferId_sp_Result> GetJobCounterOffersByJobOffer(int jobOfferId,
            int buyerId,
            int providerId)
        {
            return _db.JobCounterOffersGetByJobOfferId_sp(jobOfferId, buyerId, providerId).ToList();
        }



        public JobOffersGetLastOfferJobId_sp_Result GetLastOfferByJobId(int JobId,
            int JobOfferId)
        {
            return _db.JobOffersGetLastOfferJobId_sp(JobId, JobOfferId).FirstOrDefault();
        }


        public List<JobGetAllByBuyerIdForProviderInvitation_sp_Result> GetAllByBuyerIdForProviderInvitation(int UserId,
            int ProviderId,
            int JobStatusId)
        {
            return _db.JobGetAllByBuyerIdForProviderInvitation_sp(UserId, ProviderId, JobStatusId).ToList();
        }

        public JobAwardedGetByJobId_sp_Result GetAwardedJob(int jobId)
        {
            return _db.JobAwardedGetByJobId_sp(jobId).FirstOrDefault();
        }

        public List<JobInProgressByUserId_sp_Result> GetJobsInProgress(int userId,
            int userType)
        {
            return _db.JobInProgressByUserId_sp(userId, userType).ToList();
        }



        public int? InsertTimeSheet(TIME_SHEET entity)
        {
            return _db.TimeSheetInsert_sp(entity.JOB_AWARDED_ID,
                entity.BUYER_ID,
                entity.PROVIDER_ID,
                entity.JOB_ID,
                entity.JOB_OFFER_ID,
                entity.JOB_TYPE,
                entity.START_DATE_TIME,
                entity.END_DATE_TIME,
                entity.TOTAL_DAYS,
                entity.TOTAL_HOURS,
                entity.CREATED_BY, entity.IS_COMPLETED_BY_PROVIDER, entity.WORKING_ON).FirstOrDefault();
        }

        public int? UpdatetTimeSheet(TIME_SHEET entity)
        {
            return _db.TimeSheetUpdate_sp(entity.TIME_SHEET_ID,
                entity.IS_VERIFIED_BY_BUYER,
                entity.IS_PAYED, entity.IS_CANCELLED_BY_BUYER, entity.IS_COMPLETED_VERIFIED_BY_BUYER).FirstOrDefault();
        }

        public int? UpdatetTimeSheetEndTime(TIME_SHEET entity)
        {
            return _db.TimeSheetEndTimeUpdate_sp(entity.TIME_SHEET_ID, entity.END_DATE_TIME).FirstOrDefault();
        }

        public int? DeleteTimeSheet(int timeSheetId)
        {
            return _db.TimeSheetDelete_sp(timeSheetId).FirstOrDefault();
        }


        public List<JobGetAll_sp_Result> GetAllJobs()
        {
            return _db.JobGetAll_sp().ToList();
        }


        public List<SearchingJobsList_sp_Result> GetSearchingJobList(int UserId,
            int classId,
            int cityId,
            int stateId,
            string postCode,
            string searchText,
            int StatusId)
        {
            try
            {
                return
                    _db.SearchingJobsList_sp(UserId, classId, cityId, stateId, postCode, searchText, StatusId).ToList();
            }
            catch
            {
                throw;
            }
        }



        public List<WD_JobTasksByJobId_Result> GetJobsTasks(int selectedJobId, bool isCompletedTasks)
        {
            var result = _db.WD_JobTasksByJobId(selectedJobId, isCompletedTasks).ToList();
            return result;
        }

        public int? CompleteTask(int taskId)
        {
            return _db.WD_MarkTaskCompleted(taskId).FirstOrDefault();
        }

        public List<TaskTypeGetAll_Result> GetTaskTypes()
        {
            return _db.TaskTypeGetAll().ToList();
        }

        public List<TaskStatusGetAll_Result> GetTaskStatus()
        {
            return _db.TaskStatusGetAll().ToList();
        }

        public List<TaskPriorityGetAll_Result> GetTaskPriority()
        {
            return _db.TaskPriorityGetAll().ToList();
        }

        public List<JobTasksByJobId_Result> GetTasksByJob(int jobId, int typeId, int statusId, int priorityId)
        {
            return _db.JobTasksByJobId(jobId, typeId, statusId, priorityId).ToList();
            ;
        }

        public JobTasksById_Result GetTaskById(int taskId)
        {
            return _db.JobTasksById(taskId).FirstOrDefault();
        }

        public int CreateTask(JOB_TASK task)
        {
            int taskId = 0;
            var result = _db.CreateTask(task.JOB_ID,
                task.JOB_AWARDED_ID,
                task.TASK_TYPE_ID,
                task.TASK_STATUS_ID,
                task.TASK_PRIORITY_ID,
                task.TASK,
                task.DESCRIPTION,
                task.CREATED_BY,
                task.ASSIGNED_TO,
                task.CREATED_ON
                ).FirstOrDefault();

            if (result != null)
                taskId = Convert.ToInt32(result.Value);

            return taskId;
        }

        public GetUserTimeLog_Result GetUserLog(int userId, int currentJobId, DateTime currentDateTime)
        {
            return _db.GetUserTimeLog(userId, currentJobId, currentDateTime).FirstOrDefault();
        }

        public List<UserLogsGetByHours_Result> GetUserLogByTime(int userId, int jobId, DateTime startTime, DateTime endTime)
        {
            return _db.UserLogsGetByHours(startTime, endTime, userId, jobId).ToList();
        }

        public List<GetImagesInGivenTime_Result> GetImagesInGivenTime(int providerId, int jobId, DateTime startTime, DateTime endTime)
        {
            return _db.GetImagesInGivenTime(startTime, endTime, providerId, jobId).ToList();
        }

        public List<Web_GetAllJobStatus_Result> GetAllJobStatus()
        {
            return _db.Web_GetAllJobStatus().ToList();
        }

        public int? UpdateJobStatus(int? Job_Status_Id, int Job_Id)
        {
            return _db.Web_UpdateJobStatusByJobId(Job_Status_Id, Job_Id).FirstOrDefault();
        }

        public List<Web_GetJobByStatusId_Result> GetJobsByStatusId(int job_Status_Id)
        {
            return _db.Web_GetJobByStatusId(job_Status_Id).ToList();
        }

        public List<Web_OffersSentAwardedRejected_Result> GetJobsForOffersSentAwardedRejected(int Prov_Id, int Is_Awarded, int Is_Rejected)
        {
            return _db.Web_OffersSentAwardedRejected(Prov_Id, Is_Awarded, Is_Rejected).ToList();
        }

        public List<Web_JobsByStatusForProvider_Result> Web_JobsByStatusForProvider(int Job_Status_Id, int Prov_Id)
        {
            return _db.Web_JobsByStatusForProvider(Job_Status_Id, Prov_Id).ToList();
        }
    }
}