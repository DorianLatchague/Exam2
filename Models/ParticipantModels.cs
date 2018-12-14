using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Exam2.Models
{
    public class Participants
    {
        [Key]
        public int ParticipantsId { get;set; }
        public int ActivitiesId { get;set; }
        public Activities Activity { get;set; }
        public int UsersId { get;set; }
        public Users User { get;set; }
    }
}