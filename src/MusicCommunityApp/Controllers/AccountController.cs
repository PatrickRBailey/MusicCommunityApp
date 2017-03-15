using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MusicCommunityApp.Models;
using MusicCommunityApp.Repositories;
using System.Linq;

namespace MusicCommunityApp.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<Musician> userManager;
        private SignInManager<Musician> signInManager;
        private AppIdentityDbContext context;

        public AccountController(UserManager<Musician>userMgr,
            SignInManager<Musician> signInMgr, AppIdentityDbContext ctx)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            context = ctx;
        }

        [Authorize(Roles ="Admin")]
        public IActionResult AdminRegister()
        {
            var vm = new RegisterViewModel();
            ViewBag.roles = context.Roles.ToList();

            return View(vm);
        }

        [HttpPost]
       [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminRegister(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Musician user = new Musician
                {
                    UserName = vm.FirstName + vm.LastName,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    Email = vm.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, vm.UserRole);
                    if (result.Succeeded)

                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(vm);
        }



        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult>Register(RegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Musician user = new Musician
                {
                    UserName = vm.FirstName + vm.LastName,
                    FirstName = vm.FirstName,
                    LastName = vm.LastName,
                    Email = vm.Email
                };
                IdentityResult result = await userManager.CreateAsync(user, vm.Password);

                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Member");
                    if (result.Succeeded)

                        return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(vm);
        }

        [AllowAnonymous]
        public ViewResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel vm)
        {
            if (ModelState.IsValid)
            {
                Musician user =
                    await userManager.FindByNameAsync(vm.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();

                    Microsoft.AspNetCore.Identity.SignInResult result =
                        await signInManager.PasswordSignInAsync(
                            user, vm.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
                ModelState.AddModelError("", "Invalid name or password");
            }
            
            return View(vm);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
