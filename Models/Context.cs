using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace Exam2.Models
{
    public class Exam2Context : DbContext
    {
        public Exam2Context(DbContextOptions<Exam2Context> options) : base(options) {}
        public DbSet<Users> users { get;set; }
        public DbSet<Activities> activities { get;set; }
        public DbSet<Participants> participants { get;set; }
    }
}