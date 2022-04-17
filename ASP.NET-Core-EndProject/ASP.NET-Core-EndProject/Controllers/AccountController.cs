using ASP.NET_Core_EndProject.Data;
using ASP.NET_Core_EndProject.Models;
using ASP.NET_Core_EndProject.Services.Interfaces;
using ASP.NET_Core_EndProject.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ASP.NET_Core_EndProject.Utilities.Helpers.Helper;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace ASP.NET_Core_EndProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;
        public AccountController(UserManager<AppUser> userManager,
                                 SignInManager<AppUser> signInManager,
                                 AppDbContext context,
                                 IEmailService emailService,
                                 RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _roleManager = roleManager;
            _emailService = emailService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);
            AppUser user = await _userManager.FindByNameAsync(loginVM.Username);
            if (user == null)
            {
                ModelState.AddModelError("", "Username or password is wrong");
                return View();
            }
            if (!user.Activated)
            {
                ModelState.AddModelError("", "Profile is not activated");
                return View();
            }

            SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

            if (!signInResult.Succeeded)
            {
                if (signInResult.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Account has not verified");
                    return View();
                }
                ModelState.AddModelError("", "Username or password is wrong");
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            AppUser newUser = new AppUser()
            {
                UserName = registerVM.Username,
                Email=registerVM.Email
            };

            
            IdentityResult result = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View(registerVM);
                }
               
            }
            await _userManager.AddToRoleAsync(newUser, Roles.Member.ToString());

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
            var link = Url.Action("VerifyEmail", "Account", new { userId = newUser.Id, token = code },Request.Scheme,Request.Host.ToString());
            string html = $"<a href={link}>Verify Email</a>";
            string content = "Eduhome - Email Confirmation";
            await _emailService.SendEmailAsync(newUser.Email, newUser.UserName, html, content);


            

            return RedirectToAction(nameof(EmailVerification));
        }
        
        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        
        public async Task<IActionResult> VerifyEmail(string userId,string token)
        {
            if (userId == null || token == null) return BadRequest();

            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user == null) return BadRequest();

            user.Activated = true;
            await _userManager.ConfirmEmailAsync(user,token);
            await _signInManager.SignInAsync(user, false);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult EmailVerification()
        {
            return View();
        }
        
        
        [Authorize(Roles = "Admin")]
        public async Task CreateRole()
        {
            foreach (var role in Enum.GetValues(typeof(Roles)))
            {
                if(!await _roleManager.RoleExistsAsync(role.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
                }
            }
            
        }
        public IActionResult ForgotPassword()
        {
            return View();
        } 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordVM forgotPasswordVM)
        {
            if (!ModelState.IsValid) return View();
            var user = await _userManager.FindByEmailAsync(forgotPasswordVM.Email);
            if (user is null)
            {
                ModelState.AddModelError("", "This email hasn`t registered");
                return View();
            }
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var link = Url.Action(nameof(ResetPassword),"Account",new {email =user.Email,token=code},Request.Scheme,Request.Host.ToString());
            string html = $"<a href={link}>Forgot Password?</a>";
            string content = "Eduhome - Reset Password";
            await _emailService.SendEmailAsync(user.Email, user.UserName, html, content);

            return RedirectToAction(nameof(Login));
        }
        public IActionResult ResetPassword(string email,string token)
        {
            var model = new ResetPasswordVM { Email = email, Token = token };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM resetPasswordVM)
        {
            if (!ModelState.IsValid) return View(resetPasswordVM);
            var user = await _userManager.FindByEmailAsync(resetPasswordVM.Email);
            if (user == null) return NotFound();
            IdentityResult result = await _userManager.ResetPasswordAsync(user, resetPasswordVM.Token, resetPasswordVM.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(resetPasswordVM);
            }
            return RedirectToAction(nameof(Login));
        }
        public IActionResult ForgotPasswordConfirm()
        {
            return View();
        }
    }
}
