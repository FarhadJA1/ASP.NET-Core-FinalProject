using ASP.NET_Core_EndProject.Models;
using ASP.NET_Core_EndProject.Services;
using ASP.NET_Core_EndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.ViewComponents
{
    public class SidebarViewComponent:ViewComponent
    {
        private readonly SidebarService _sidebarService;
        public SidebarViewComponent(SidebarService sidebar)
        {
            _sidebarService = sidebar;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Tag> tags = await _sidebarService.GetTags();
            List<Blog> blogs = await _sidebarService.GetBlogs();
            Advert advert = await _sidebarService.GetAdvert();
            List<CourseCategory> courseCategories = await _sidebarService.GetCourseCategoriesAsync();

            SidebarVM sidebarVM = new SidebarVM()
            {
                Tags=tags,
                Blogs=blogs,
                Advert=advert,
                CourseCategories=courseCategories
            };
            return (await Task.FromResult(View(sidebarVM)));
        }
    }
}
