using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoiceSageAssessment.Models;

namespace VoiceSageAssessment.Interface
{
    interface IGroupRepository
    {
        IEnumerable<GroupDetail> GetAllGroupDetails();
        void InsertGroupDetails(GroupDetail grup);
        GroupDetail GetGroup(int grupId);
        void DeleteGroup(int groupId);
        void UpdateGroupDetails(GroupDetail grup);

    }
}
