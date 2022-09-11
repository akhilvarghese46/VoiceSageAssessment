using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VoiceSageAssessment.Models;

namespace VoiceSageAssessment.DatabaseAccess
{
    

    public class DefaultConnection : DbContext
    {
        public DefaultConnection()
        {
        }

        /* protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             throw new UnintentionalCodeFirstException();
         }*/

        public DbSet<GroupDetail> groupdetails { get; set; }
        public DbSet<ContactDetail> contactdetails { get; set; }

    }

}