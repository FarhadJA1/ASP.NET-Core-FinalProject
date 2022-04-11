using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_EndProject.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _context;
        public LayoutService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Setting> GetSettings()
        {
            Setting setting = await _context.Settings.FirstOrDefaultAsync();
            return setting;
        }
        public async Task<List<SocNetwork>> GetSocialNetwork()
        {
            List<SocNetwork> socialNetworks = await _context.SocNetworks.ToListAsync();
            return socialNetworks;
        }
    }
}
