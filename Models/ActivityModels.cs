using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Exam2.Models
{
    public class Activities
    {
        [Key]
        public int ActivitiesId { get;set; }
        public string Title { get;set; }
        public DateTime DateTime { get;set; }
        public int Duration { get;set; }
        public string DurationUnit { get;set; }
        public string Description { get;set; }
        public int CreatorId { get;set; }
        public Users Creator { get;set; }
        public List<Participants> Participants { get;set; }
    }
    public class NewActivity
    {
        public int ActivitiesId { get;set; }
        [Required(ErrorMessage="Please enter a Title")]
        [MinLength(2, ErrorMessage="Your Title should be at least 2 characters long")]
        public string Title { get;set; }
        [Required(ErrorMessage="Please enter a Date")]
        public DateTime Date { get;set; }
        [Required(ErrorMessage="Please enter a Time")]
        public DateTime Time { get;set; }
        [Required(ErrorMessage="Please enter a Duration")]
        [Range(1, 60, ErrorMessage="Please enter a reasonable Duration")]
        public int Duration { get;set; }
        public string DurationUnit { get;set; }
        [Required(ErrorMessage="Please enter a Description")]
        [MinLength(10, ErrorMessage="Your Description should be at least 10 characters long")]
        public string Description { get;set; }
    }
}