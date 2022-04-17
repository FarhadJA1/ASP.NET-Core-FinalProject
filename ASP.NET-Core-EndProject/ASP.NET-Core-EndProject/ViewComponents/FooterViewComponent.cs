using ASP.NET_Core_EndProject.Data;
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
    public class FooterViewComponent : ViewComponent
    {
        private readonly LayoutService _layoutService;
        private readonly AppDbContext _context;
        public FooterViewComponent(LayoutService layoutService, AppDbContext context)
        {
            _layoutService = layoutService;
            _context = context;
        }
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            Setting settings = await _layoutService.GetSettings();
            List<SocNetwork> socialNetworks = await _layoutService.GetSocialNetwork();

            LayoutVM layoutVM = new LayoutVM()
            {
                Setting = settings,
                SocialNetwork = socialNetworks
            };
            return (await Task.FromResult(View(layoutVM)));
        }
        
    }
}
