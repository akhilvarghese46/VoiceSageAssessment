using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoiceSageAssessment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class GroupDetail
    {
        [Key]
        [Column(Order = 0)]
        public int GroupId { get; set; }
        [Required]
        public string GroupName { get; set; }
        [Required]
        public string GroupDescription { get; set; }
    }
}