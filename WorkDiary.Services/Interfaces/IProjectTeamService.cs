using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.models;

namespace WorkDiaryServices.Interfaces
{
    public interface IProjectTeamService
    {
        List<Web_GetProjectTeamByBuyerId_Result> GetProjectTeamByBuyerId(int? buyer_Id);
        int? AddProjectTeamMember(ProjectTeamMember projectTeamMember);
        int? UpdateProjectTeamMember(ProjectTeamMember projectTeamMember);
        int? DeleteProjectTeamMember(int? Project_Team_Id);
    }
}
