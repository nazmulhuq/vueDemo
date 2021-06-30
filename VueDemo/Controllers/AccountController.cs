using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueDemo.ViewModels;

namespace VueDemo.Controllers
{
    public class AccountController : Controller
    {
        public readonly UserManager<IdentityUser> userManager;
        public readonly SignInManager<IdentityUser> signInManager;
        public readonly RoleManager<IdentityRole> roleManager;
        public AccountController(UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        public IActionResult RegisterTeacher()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var user = new IdentityUser()
            {
                UserName = registerViewModel.Email,
                Email =registerViewModel.Email,
            };

            var result = await userManager.CreateAsync(user, registerViewModel.Password);
            
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Constants.Student);
                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            foreach(var err in result.Errors)
            {
                ModelState.AddModelError(string.Empty, err.Description);
            }
            return View(registerViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> RegisterTeacher(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var user = new IdentityUser()
            {
                UserName = registerViewModel.Email,
                Email = registerViewModel.Email,
            };

            var result = await userManager.CreateAsync(user, registerViewModel.Password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Constants.Teacher);
                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }
            foreach (var err in result.Errors)
            {
                ModelState.AddModelError(string.Empty, err.Description);
            }
            return View(registerViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync
              (
                  loginViewModel.Email,
                  loginViewModel.Password,
                  loginViewModel.RememberMe,
                  false
              );
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
                ModelState.AddModelError(string.Empty, "Invalid signin attempt");
            }
            return View(loginViewModel);
        }

        public async Task<IActionResult> CreateRole()
        {
            IdentityRole identityRoleT = new IdentityRole()
            {
                Name = "Teacher"
            };
            IdentityRole identityRoleS = new IdentityRole()
            {
                Name = "Student"
            };

            IdentityResult result1 = await roleManager.CreateAsync(identityRoleS);
            IdentityResult result2 = await roleManager.CreateAsync(identityRoleT);
            return Content("done");
        }

    }
}
