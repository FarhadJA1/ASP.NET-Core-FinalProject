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

        public FooterViewComponent(LayoutService layoutService)
        {
            _layoutService = layoutService;

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
