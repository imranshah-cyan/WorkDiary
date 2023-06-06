using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkDiaryServices.models
{
    public class ProjectTeamMember
    {
        public int Job_Id { get; set; }
        public int Designation_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

}
