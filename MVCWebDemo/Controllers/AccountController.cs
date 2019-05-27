using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCWebDemo.Core.DAL.Model;
using MVCWebDemo.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebDemo.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager
          )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (returnUrl == null)
                        returnUrl = "Home";
                    return RedirectToAction("Index", returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                User user = new User(-1, model.Email, model.Email);
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    if (returnUrl == null)
                        return RedirectToAction("index", "home");
                    else
                        return RedirectToAction(returnUrl);
                }
                ModelState.AddModelError(string.Empty, result.Errors.FirstOrDefault().Description);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        //AccessDenied
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
