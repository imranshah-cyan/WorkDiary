using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorkDiaryRepository.Dbo;
using WorkDiaryRepository.models;
using WorkDiaryServices.Classes;

namespace ServiceDotNet.Api.Controllers
{
    [RoutePrefix("api/ProjectTeam")]
    public class ProjectTeamController : ApiController
    {
        [HttpGet]
        [Route("{buyer_Id}")]
        public List<Web_GetProjectTeamByBuyerId_Result> GetProjectTeamByBuyerId(int buyer_Id)
        {
            return new ProjectTeamService().GetProjectTeamByBuyerId(buyer_Id);
        }

        [HttpPost]
        public int? AddProjectTeamMember(ProjectTeamMember projectTeamMember)
        {
            return new ProjectTeamService().AddProjectTeamMember(projectTeamMember);
        }

        [HttpPut]
        public int? UpdateProjectTeamMember(ProjectTeamMember projectTeamMember)
        {
            return new ProjectTeamService().UpdateProjectTeamMember(projectTeamMember);
        }

        [HttpDelete]
        public int? DeleteProjectTeamMember(int? Project_Team_Id)
        {
            return new ProjectTeamService().DeleteProjectTeamMember(Project_Team_Id);
        }
        
    }
}
