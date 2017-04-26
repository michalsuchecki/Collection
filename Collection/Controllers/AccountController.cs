using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Collection.ViewModels;
using Collection.Models;
using Microsoft.Extensions.Options;

namespace Collection.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IOptions<IdentityCookieOptions> _identityCookieOptions;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            IOptions<IdentityCookieOptions> identityCookieOptions
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _identityCookieOptions = identityCookieOptions;
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
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if(result.Succeeded)
                {
                    return RedirectToAction("index", "item");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","item");
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
                var user = new User()
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "item");
                }

            }
            return View(model);
        }
    }
}