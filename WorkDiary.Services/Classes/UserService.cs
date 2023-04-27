using System;
using System.Collections.Generic;
using WorkDiaryRepository;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Entities;
using WorkDiaryServices.Interfaces;

namespace WorkDiaryServices
{
    public class UserService : IUserService
    {
        public int? InsertUser(User entity)
        {
            return new UserRepository().InsertUser(entity);
        }

        public UserValidateLogin_sp_Result ValidateUser(USER model)
        {
            return new UserRepository().ValidateUser(model);
        }

        public UserGetByEmail_sp_Result UserGetByEmail(string Email)
        {
            return new UserRepository().UserGetByEmail(Email);
        }

        public bool UserExists(string altCandidate)
        {
            return new UserRepository().UserExists(altCandidate);
        }

        public string UserExistsByEmailOrUserName(string email, string userName)
        {
            return new UserRepository().UserExistsByEmailOrUserName(email, userName);
        }

        public bool UserEmailExists(string Email)
        {
            return new UserRepository().UserEmailExists(Email);
        }

        public GetTodayWorkSummaryByProvider_Result GetTodayWorkSummaryByProvider(int userId, int currentJobId, DateTime dateTime)
        {
           return new UserRepository().GetTodayWorkSummaryByProvider(userId, currentJobId, dateTime);
        }

        public void UserActivate(User objUser)
        {
            new UserRepository().UserActivate(objUser);
        }

        public void GetLoginInfo(ref USER objUser)
        {
            new UserRepository().GetLoginInfo(ref objUser);
        }
        
        public int? InsertRates(CONTACT_RATES entity)
        {
            return new UserRepository().InsertRates(entity);
        }

        public int? UpdateContact(CONTACT entity)
        {
            return new UserRepository().UpdateContact(entity);
        }

        public List<UserGetAll_sp_Result> GetUserList(int userId, int roleId, int classId, int cityId, int stateId, string postCode, string searchText)
        {
            return new UserRepository().GetUserList(userId, roleId, classId, cityId, stateId, postCode, searchText);
        }

        public int? InsertCategory(CONTACT_CATEGORY entity)
        {
            return new UserRepository().InsertCategory(entity);
        }

        public bool IsUserActivate(int UserId)
        {
            return new UserRepository().IsUserActivate(UserId);
        }


        public List<UserFeedBackHistory_sp_Result> GetUserFeedBackHistory(int UserId, bool IsBuyer)
        {
            return new UserRepository().GetUserFeedBackHistory(UserId, IsBuyer);
        }


        public int? UserChangePassword(User user)
        {
            return new UserRepository().UserChangePassword(user);
        }


        public List<EducationGet_sp_Result> GetEducation(int UserId, int ContactId, int EducationTypeId)
        {
            return new UserRepository().GetEducation(UserId, ContactId, EducationTypeId);
        }

        public int? InsertEduction(EDUCATION entity)
        {
            return new UserRepository().InsertEduction(entity);
        }


        public int? InsertSkills(CONTACT_SKILLS entity, string skillIds, int classId)
        {
            return new UserRepository().InsertSkills(entity, skillIds, classId);
        }


        public int? InsertExperience(CONTACT_WORK_HISTORY entity)
        {
            return new UserRepository().InsertExperience(entity);
        }

        public int? InsertPortfolios(CONTACT_PORTFOLIO entity)
        {
            return new UserRepository().InsertPortfolios(entity);
        }


        public int InsertUserLog(List<USER_LOG> userLog)
        {
            return new UserRepository().InsertUserLog(userLog);
        }

        public int InsertScreenLog(List<SCREEN_LOGS> scLog)
        {
            return new UserRepository().InsertScreenLog(scLog);
        }
    }
}