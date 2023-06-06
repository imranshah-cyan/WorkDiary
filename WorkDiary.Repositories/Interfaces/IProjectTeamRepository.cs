using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.models;

namespace WorkDiaryRepository.Interfaces
{
    public interface IProjectTeamRepository
    {
        List<Web_GetProjectTeamByBuyerId_Result> GetProjectTeamByBuyerId(int? buyer_Id);
        int? AddProjectTeamMember(ProjectTeamMember projectTeamMember);
        int? DeleteProjectTeamMember(int? Project_Team_Id);
    }

}
