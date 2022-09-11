using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VoiceSageAssessment.Models
{
    public class ContactDetail
    {
        [Key]
        [Column(Order = 0)]
        public int columnId { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int number { get; set; }
        [Required]
        public string email { get; set; }
        public int groupId { get; set; }
        [Required]
        public string groupName { get; set; }
    }
}