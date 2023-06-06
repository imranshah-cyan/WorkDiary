using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.Interfaces;
using WorkDiaryRepository.models;

namespace WorkDiaryRepository.Classes
{
    public class ProjectTeamRepository : RepositoryBase, IProjectTeamRepository
    {
        public List<Web_GetProjectTeamByBuyerId_Result> GetProjectTeamByBuyerId(int? buyer_Id)
        {
            return _db.Web_GetProjectTeamByBuyerId(buyer_Id).ToList();
        }

        public int? AddProjectTeamMember(ProjectTeamMember projectTeamMember)
        {
            return (int?)_db.Web_AddProjectTeamMember(projectTeamMember.Job_Id,
                                                projectTeamMember.Designation_Id,
                                                projectTeamMember.Name,
                                                projectTeamMember.Email).FirstOrDefault();
        }

        public int? UpdateProjectTeamMember(ProjectTeamMember projectTeamMember)
        {
            return (int?)_db.Web_UpdateProjectTeamMember(projectTeamMember.PROJECT_TEAM_ID,
                                                        projectTeamMember.Job_Id,
                                                        projectTeamMember.Designation_Id,
                                                        projectTeamMember.Name,
                                                        projectTeamMember.Email).FirstOrDefault();
        }

        public int? DeleteProjectTeamMember(int? Project_Team_Id)
        {
            return (int)_db.Web_DeleteProjectTeamMember(Project_Team_Id).FirstOrDefault();
        }
        
    }
}
