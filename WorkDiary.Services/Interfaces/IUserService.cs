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
    public interface IUserService
    {
        int? InsertUser(User entity);
        UserValidateLogin_sp_Result ValidateUser(USER model);
        UserInfoGetById_sp_Result UserInfoGetById(int User_id);
        UserGetByEmail_sp_Result UserGetByEmail(string Email);
        Web_ForgotUserCheck_Result Web_ForgotUserCheck(User user);
        bool UserExists(string altCandidate);
        string UserExistsByEmailOrUserName(string email, string userName);
        bool UserEmailExists(string Email);
        GetTodayWorkSummaryByProvider_Result GetTodayWorkSummaryByProvider(int userId, int currentJobId, DateTime dateTime);
        void UserActivate(User objUser);
        void GetLoginInfo(ref USER objUser);
        int? InsertRates(CONTACT_RATES entity);
        int? UpdateContact(CONTACT entity);
        List<UserGetAll_sp_Result> GetUserList(int userId, int roleId, int classId, int cityId, int stateId, string postCode, string searchText);
        int? InsertCategory(CONTACT_CATEGORY entity);
        bool IsUserActivate(int UserId);
        List<UserFeedBackHistory_sp_Result> GetUserFeedBackHistory(int UserId, bool IsBuyer);
        int? UserChangePassword(User user);
        List<EducationGet_sp_Result> GetEducation(int UserId, int ContactId, int EducationTypeId);
        int? InsertEduction(EDUCATION entity);
        int? InsertSkills(CONTACT_SKILLS entity, string skillIds, int classId);
        int? InsertExperience(CONTACT_WORK_HISTORY entity);
        int? InsertPortfolios(CONTACT_PORTFOLIO entity);
        int InsertUserLog(List<USER_LOG> userLog);
        int InsertScreenLog(List<SCREEN_LOGS> scLog);

    }
}
