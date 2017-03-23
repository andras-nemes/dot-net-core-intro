using DotNetCoreBookstore.Models;
using DotNetCoreBookstore.UserManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreBookstore.Controllers
{
    public class AccountController : Controller
    {
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signinManager;

		public AccountController(UserManager<User> userManager, SignInManager<User> signinManager)
		{
			if (userManager == null) throw new ArgumentNullException("User manager");
			if (signinManager == null) throw new ArgumentNullException("Sign in manager");
			_userManager = userManager;
			_signinManager = signinManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(UserRegistrationViewModel registrationViewModel)
		{
			if (ModelState.IsValid)
			{
				IdentityResult userCreationResult = 
					await _userManager.CreateAsync(new User() { UserName = registrationViewModel.Username, YearOfBirth = registrationViewModel.YearOfBirth }, registrationViewModel.Password);
				if (userCreationResult.Succeeded)
				{
					return RedirectToAction("Index", "Books");
				}
				else
				{
					IEnumerable<string> userCreationErrors = from e in userCreationResult.Errors select e.Description;
					string concatenatedErrors = string.Join(Environment.NewLine, userCreationErrors);
					ModelState.AddModelError("", concatenatedErrors);
				}
			}
			return View();
		}

		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(UserLoginViewModel userLoginViewModel)
		{
			if (ModelState.IsValid)
			{
				var signInResult = await _signinManager.PasswordSignInAsync(userLoginViewModel.Username, userLoginViewModel.Password, userLoginViewModel.RememberMe, false);
				if (signInResult.Succeeded)
				{
					return Redirect(userLoginViewModel.ReturnUrl);
				}
			}
			ModelState.AddModelError("", "Login failure. Please check your username and password");
			return View(userLoginViewModel);
		}
    }
}
