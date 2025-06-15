using identityLect9.Authintcation;
using identityLect9.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace lect2.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;

		public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		// POST: /Account/Register
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel newUser)
		{
			if (ModelState.IsValid)
			{ 

				//map view model to application user
				ApplicationUser applicatonUser = new ApplicationUser();
				applicatonUser.UserName = newUser.Username;
				applicatonUser.Email = newUser.Email;
				applicatonUser.Address = newUser.Address;
				applicatonUser.PasswordHash= newUser.Password;

				//save in db call user manger type of user injected TYPE application user
				var result = await userManager.CreateAsync(applicatonUser, newUser.Password);//hi take applicationuser not viewmodel so map before it
																						   //save in db call user manger type of user injected TYPE application user
																						   //thses function call store then call context then call DB
																						 
				if (result.Succeeded)//saved in database done
				{
					//create cookie using SignInManager<ApplicationUser> in construcctor
					
					await signInManager.SignInAsync(applicatonUser, false); //default take id name and role  
																			//for add extra info not just default
																			//List<Claim> claimss = new List<Claim>();
																			//claimss.Add(new Claim("Color", "red")); 
																			//await signInManager.SignInWithClaimsAsync(applicatonUser,false, claimss);// false for not presistant we will make it true in login action

					// You can redirect to a login page or home page 

					await userManager.AddToRoleAsync(applicatonUser, "student"); // return identity result

					return RedirectToAction("Index", "Home");
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description); // send to view u can send key ""
				}
			}

			return View(newUser);
		}
		public IActionResult Logout()
		{
			 signInManager.SignOutAsync(); //this delete cookie 
			return RedirectToAction("Login"); // or Redirect("/your-custom-url")
		}
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]//must put it
		public async Task<IActionResult> Login(LoginViewModel userVM)
		{
			if (ModelState.IsValid)
			{
				//check in datbase if another like emp will use repository for it but here we use user manager
				ApplicationUser userModel = await userManager.FindByNameAsync(userVM.UserName); //return application user record from db
				if (userModel != null)
				{
					//check password in database with ur password in form
					bool isPasswordValid = await userManager.CheckPasswordAsync(userModel, userVM.Password);


					if (isPasswordValid == true)
					{
						//SET Cookie //create cookie after check data valid in database no in form 
						//using SignInManager<ApplicationUser> in construcctor
						await signInManager.SignInAsync(userModel, userVM.RememberMe);		//default take id name and role  
																							//for add extra info not just default
																							//List<Claim> claimss = new List<Claim>();
																							//claimss.Add(new Claim("Color", "red")); 
																							//await signInManager.SignInWithClaimsAsync(applicatonUser,false, claimss);// false for not presistant we will make it true in login action


						return RedirectToAction("Index", "Home");
					}
				}
						

				ModelState.AddModelError("", "Invalid login attempt.");
			}

			return View(userVM);
		}
	
	}
}

