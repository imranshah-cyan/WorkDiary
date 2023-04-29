using System;
using System.Collections.Generic;
using System.Linq;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Entities;
using WorkDiaryRepository.Helpers;
using WorkDiaryRepository.Interfaces;

namespace WorkDiaryRepository
{
    public class UserRepository : RepositoryBase, IUserRepository
    {

        public int? InsertUser(User entity)
        {
            try
            {
                int? userId = 0;

                string password = new Crypto().Encrypt(entity.PASSWORD);
                userId = _db.UserInsert_sp(
                                            entity.ROLE_ID,
                                            entity.FULL_NAME,
                                            entity.EMAIL,
                                            entity.USER_NAME,
                                            password,
                                            entity.SECURITY_QUESTION,
                                            entity.SECURITY_QUESTION_ANSWER
                                        ).FirstOrDefault();
                return userId;
            }
            catch
            {
                throw;
            }
        }

        public UserValidateLogin_sp_Result ValidateUser(USER model)
        {
            var result =  _db.UserValidateLogin_sp(model.USER_NAME, model.PASSWORD).FirstOrDefault();
            return result;
        }

        public UserGetByEmail_sp_Result UserGetByEmail(string email)
        {
            return _db.UserGetByEmail_sp(email).FirstOrDefault();
        }

        public Web_ForgotUserCheck_Result Web_ForgotUserCheck(User entity)
        {
            return _db.Web_ForgotUserCheck(entity.USER_NAME, entity.SECURITY_QUESTION, entity.SECURITY_QUESTION_ANSWER).FirstOrDefault();
        }

        public GetTodayWorkSummaryByProvider_Result GetTodayWorkSummaryByProvider(int userId, int currentJobId, DateTime dateTime)
        {
            return _db.GetTodayWorkSummaryByProvider(dateTime, userId, currentJobId).FirstOrDefault();
        }

        public bool UserExists(string altCandidate)
        {
            var firstOrDefault = _db.UserExists_sp(altCandidate).FirstOrDefault();
            return firstOrDefault != null && firstOrDefault.Value;
        }

        public string UserExistsByEmailOrUserName(string email,
                                               string userName)
        {
            var firstOrDefault = _db.UserExistsByEmailOrId_sp(email, userName).FirstOrDefault();
            if (firstOrDefault != null)
                return (string)firstOrDefault.ToString();

            return null;
        }


        public bool UserEmailExists(string email)
        {
            if (email == null) throw new ArgumentNullException("email");
            var firstOrDefault = _db.UserEmailExists_sp(email).FirstOrDefault();
            return firstOrDefault != null && firstOrDefault.Value;
        }

        public void UserActivate(User objUser)
        {
            try
            {
                int? userId = 0;

                userId = _db.UserActivate_sp(
                                                objUser.USER_ID,
                                                objUser.ACTIVATED_ON,
                                                objUser.IS_LOCKED,
                                                objUser.IS_ARCHIVED
                                            ).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        public void GetLoginInfo(ref USER objUser)
        {
            UserLoginInfo_sp_Result _user = new UserLoginInfo_sp_Result();

            _user = _db.UserLoginInfo_sp(objUser.USER_ID).FirstOrDefault();

            if (_user != null)
            {
                objUser.USER_NAME = _user.USER_NAME;
                objUser.PASSWORD = _user.PASSWORD;
            }
        }

        public int? InsertRates(CONTACT_RATES entity)
        {
            try
            {
                int? rateId = 0;

                rateId = _db.ContactRatesInsert_sp(
                                                    entity.CONTACT_ID,
                                                    entity.CONTACT_CAT_ID,
                                                    entity.CURRENCY_ID,
                                                    entity.RATE_TYPE_ID,
                                                    entity.RATE,
                                                    entity.CURRENT_SERVICE_FEE
                                                  ).FirstOrDefault();

                return rateId;

            }
            catch
            {
                throw;
            }
        }

        public int? UpdateContact(CONTACT entity)
        {
            try
            {
                int? contactId = 0;

                contactId = _db.ContactUpdate_sp(
                                                    entity.CONTACT_ID,
                                                    entity.CONTACT_TYPE_ID,
                                                    entity.BUSINESS_NAME,
                                                    entity.BUSINESS_LOGO,
                                                    entity.FULL_NAME,
                                                    entity.FNAME,
                                                    entity.LNAME,
                                                    entity.MNAME,
                                                    entity.ADDRESS1,
                                                    entity.ADDRESS2,
                                                    entity.CITY_ID,
                                                    entity.STATE_ID,
                                                    entity.COUNTRY_ID,
                                                    entity.ZIP_POSTAL,
                                                    entity.PRIMARY_PHONE,
                                                    entity.SECONDARY_PHONE,
                                                    entity.OTHER_PHONE,
                                                    entity.WEBSITE_URL,
                                                    entity.FACEBOOK_ID,
                                                    entity.TWITTER_ID,
                                                    entity.GOOGLE_ID,
                                                    entity.NOTES,
                                                    entity.ABOUT_ME,
                                                    entity.IS_BUSINESS_NAME_PUBLIC,
                                                    entity.IS_PERSONAL_INFO_PUBLIC,
                                                    entity.IS_ADDRESS_PUBLIC
                                                ).FirstOrDefault();

                return contactId;

            }
            catch
            {
                throw;
            }
        }

        public List<UserGetAll_sp_Result> GetUserList(int userId, int roleId, int classId, int cityId, int stateId, string postCode, string searchText)
        {
            return _db.UserGetAll_sp(userId, roleId, classId, cityId, stateId, postCode, searchText).ToList();
        }

        public int? InsertCategory(CONTACT_CATEGORY entity)
        {
            try
            {
                int? contactCatId = 0;

                contactCatId = _db.ContactCategoryInsert_sp(
                                                            entity.CAT_ID,
                                                            entity.CLASS_ID,
                                                            entity.CONTACT.USER_ID
                                                           ).FirstOrDefault();

                return contactCatId;

            }
            catch
            {
                throw;
            }
        }

        public int? InsertSkills(CONTACT_SKILLS entity, string skillIds, int classId)
        {
            try
            {
                int? contactSkillId = 0;

                contactSkillId = _db.ContactSkillInsert_sp(
                                                            entity.CONTACT_ID,
                                                            entity.CONTACT_CAT_ID,
                                                            classId,
                                                            entity.CONTACT.USER_ID,
                                                            skillIds
                                                           ).FirstOrDefault();

                return contactSkillId;

            }
            catch
            {
                throw;
            }
        }

        public bool IsUserActivate(int UserId)
        {
            return Convert.ToBoolean(_db.IsUserActivated_sp(UserId).FirstOrDefault());
        }


        public List<UserFeedBackHistory_sp_Result> GetUserFeedBackHistory(int UserId, bool IsBuyer)
        {
            return _db.UserFeedBackHistory_sp(UserId, IsBuyer).ToList();
        }


        public int? UserChangePassword(User user)
        {
            string password = new Crypto().Encrypt(user.PASSWORD);
            return _db.UserChangePassword_sp(user.USER_ID, password).FirstOrDefault();
        }


        public List<EducationGet_sp_Result> GetEducation(int UserId, int ContactId, int EducationTypeId)
        {
            return _db.EducationGet_sp(UserId, ContactId, EducationTypeId).ToList();
        }

        public int? InsertEduction(EDUCATION entity)
        {
            return Convert.ToInt32(_db.EducationIsert_sp(
                                                        entity.USER_ID,
                                                        entity.CONTACT_ID,
                                                        entity.EDUCATION_TYPE_ID,
                                                        entity.NAME,
                                                        entity.YEAR,
                                                        entity.ORGANIZATION,
                                                        entity.CREATED_ON
                                                       ).FirstOrDefault());
        }


        public int? InsertExperience(CONTACT_WORK_HISTORY entity)
        {
            return Convert.ToInt32(_db.ContactWorkHistoryInsert_sp(
                                                        entity.CONTACT_ID,
                                                        entity.CONTACT_CAT_ID,
                                                        entity.POSITION_HELD,
                                                        entity.FROM_DATE,
                                                        entity.TO_DATE,
                                                        entity.EMPLOYER_NAME,
                                                        entity.ROLES_RESPONSIBILITIES,
                                                        entity.IS_ARCHIVED
                                                       ).FirstOrDefault());
        }

        public int? InsertPortfolios(CONTACT_PORTFOLIO entity)
        {
            return Convert.ToInt32(_db.ContactPortfolioInsert_sp(
                                                        entity.USER_ID,
                                                        entity.CONTACT_ID,
                                                        entity.PROJECT_TITLE,
                                                        entity.COMPLETION_DATE,
                                                        entity.CLASS_ID,
                                                        entity.DESCRIPTION,
                                                        entity.URL,
                                                        entity.CREATED_ON,
                                                        entity.IS_ARCHIVED
                                                       ).FirstOrDefault());
        }

        public int InsertUserLog(List<USER_LOG> userLog)
        {
            return userLog.Select(log => _db.InsertUserLog_sp(log.USER_ID, log.START_TIME, log.WINDOW_TITLE, log.KEY_STROKES, log.MOUSE_CLICKS, log.SCROLLING, log.TIME_SPENT_IN_SEC, log.END_TIME, log.JOB_ID).FirstOrDefault()).Where(obj => obj != null).Sum(obj => obj.NumRowsChanged);
        }

        public int InsertScreenLog(List<SCREEN_LOGS> scLog)
        {
            foreach (var log in scLog.Where(t=>!string.IsNullOrEmpty(t.SCREEN_TITLE)).ToList())
            {
                _db.ScreenLogsInsert_sp(log.SCREEN_TITLE, log.SCREEN_CODE, log.PROVIDER_ID, log.JOB_ID, log.TIME_SHEET_ID, log.TIME_SPENT, log.CREATED_ON, log.START_ON, log.END_ON, log.IMAGE_ID);
            }

            return 1;
        }
    }
}