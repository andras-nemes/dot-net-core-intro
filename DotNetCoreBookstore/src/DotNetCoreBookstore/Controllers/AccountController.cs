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
				User newUser = new User()
				{
					UserName = registrationViewModel.Username,
					YearOfBirth = registrationViewModel.YearOfBirth
				};
				IdentityResult userCreationResult = 
					await _userManager.CreateAsync(newUser, registrationViewModel.Password);
				if (userCreationResult.Succeeded)
				{
					await _signinManager.PasswordSignInAsync(newUser.UserName, registrationViewModel.Password, false, false);
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
		public async Task<IActionResult> Logout()
		{		
			await _signinManager.SignOutAsync();
			return RedirectToAction("Index", "Books");
		}

		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(UserLoginViewModel userLoginViewModel)
		{
			if (ModelState.IsValid)
			{
				var signInResult = await _signinManager.PasswordSignInAsync(userLoginViewModel.Username, userLoginViewModel.Password, userLoginViewModel.RememberMe, false);
				if (signInResult.Succeeded)
				{
					if (!string.IsNullOrEmpty(userLoginViewModel.ReturnUrl))
					{
						return Redirect(userLoginViewModel.ReturnUrl);
					}
					else
					{
						return RedirectToAction("Index", "Books");
					}
				}
			}
			ModelState.AddModelError("", "Login failure. Please check your username and password");
			return View(userLoginViewModel);
		}
    }
}
