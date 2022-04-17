using ASP.NET_Core_EndProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<ProTeacher> ProTeachers { get; set; }
        public DbSet<Welcome> Welcome { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<NoticePanel> NoticePanel { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SocNetwork> SocNetworks { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherSkills> TeacherSkills { get; set; }
        public DbSet<TeacherContact> TeacherContacts { get; set; }
        public DbSet<TeacherDetail> TeacherDetails { get; set; }
        public DbSet<CourseFeatures> CourseFeatures { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<EventSpeaker> EventSpeakers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Subscribe> Subscribers { get; set; }

    }
}
