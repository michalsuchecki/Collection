using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Collection.ViewModels;
using Collection.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Collection.Services;

namespace Collection.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IOptions<IdentityCookieOptions> _identityCookieOptions;
        //private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserService _userService;

        public AccountController(IUserService userService,
                                 IOptions<IdentityCookieOptions> identityCookieOptions)
                                 //RoleManager<IdentityRole> roleManager)
        {
            //_roleManager = roleManager;
            _identityCookieOptions = identityCookieOptions;
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            await HttpContext.Authentication.SignOutAsync(_identityCookieOptions.Value.ExternalCookieAuthenticationScheme);
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                await _userService.LoginAsync(model.Email, model.Password);
                return RedirectToAction("index", "blog");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.LogoutAsync();
            return RedirectToAction("Index","blog");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                await _userService.RegisterAsync(model.Username, model.Password, model.Email);
                return RedirectToAction("index", "blog");
            }
            return View(model);
        }

        //[HttpGet]
        //[Authorize(Roles="Administrator")]
        //public async Task<IActionResult> AddRole(string roleName)
        //{
        //    if (!string.IsNullOrEmpty(roleName))
        //    {
        //        var role = new IdentityRole()
        //        {
        //            Name = roleName
        //        };

        //        var result = await _roleManager.CreateAsync(role);
        //        if(result.Succeeded)
        //        {

        //        }
        //    }
                
        //    return RedirectToAction("index", "item");
        //}

        //[HttpGet]
        //[Authorize(Roles = "Administrator")]
        //public async Task<IActionResult> AddRoleToAccount(string roleName)
        //{
            //if (!string.IsNullOrEmpty(roleName))
            //{
            //    var username = User.Identity.Name;

            //    var model = await _userManager.FindByNameAsync(username);

            //    if (model != null)
            //    {
            //        await _userManager.AddToRoleAsync(model, roleName);
            //    }
            //}

            //return RedirectToAction("index", "item");
        //}
    }
}