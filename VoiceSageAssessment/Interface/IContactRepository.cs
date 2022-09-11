using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoiceSageAssessment.Models;

namespace VoiceSageAssessment.Interface
{
    interface IContactRepository
    {
        IEnumerable<ContactDetail> GetAllContactDetails();
        IEnumerable<GroupDetail> GetAllGroupName();
        void InsertContactDetails(ContactDetail contact);
        ContactDetail GetContact(int contactId);
        void DeleteContact(int contactId);
        void UpdateContactDetails(ContactDetail contact);

    }
}
