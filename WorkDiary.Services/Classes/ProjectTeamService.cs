using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryRepository.Classes;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.models;
using WorkDiaryServices.Interfaces;

namespace WorkDiaryServices.Classes
{
    public class ProjectTeamService : IProjectTeamService
    {
        public List<Web_GetProjectTeamByBuyerId_Result> GetProjectTeamByBuyerId(int? buyer_Id)
        {
            return new ProjectTeamRepository().GetProjectTeamByBuyerId(buyer_Id);
        }
        public int? AddProjectTeamMember(ProjectTeamMember projectTeamMember)
        {
            return new ProjectTeamRepository().AddProjectTeamMember(projectTeamMember);
        }
        public int? UpdateProjectTeamMember(ProjectTeamMember projectTeamMember)
        {
            return new ProjectTeamRepository().UpdateProjectTeamMember(projectTeamMember);
        }
        public int? DeleteProjectTeamMember(int? Project_Team_Id)
        {
            return new ProjectTeamRepository().DeleteProjectTeamMember(Project_Team_Id);
        }
    }
}

