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

		public AccountController(UserManager<User> userManager)
		{
			if (userManager == null) throw new ArgumentNullException("User manager");
			_userManager = userManager;			
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
    }
}
