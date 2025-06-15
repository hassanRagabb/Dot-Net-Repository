using identityLect9.Authintcation;
using identityLect9.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace identityLect9.Controllers
{
	//[Authorize(Roles ="admin,hr")]
	//[Authorize(Roles = "admin")] //check if u have cookie have claim called admin
	[Authorize(Roles = "admin")]
	public class RoleController : Controller
	{
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;
		

		public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)// IdentityRole no attributes like applicationuser have address as additional
		{
			this.roleManager = roleManager;
			this.userManager = userManager;
			this.signInManager = signInManager;

		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		
		public IActionResult New()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> New(RoleViewModel newroleViewmodel)
		{
			if (ModelState.IsValid)
			{
				IdentityRole roleModel = new IdentityRole();//IdentityRole no application user :)
				roleModel.Name = newroleViewmodel.RoleName;
				// save in db
				var result = await roleManager.CreateAsync(roleModel);
				if (result.Succeeded)
				{
					return RedirectToAction("Index");
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description); //display error 
				}
			}
			return View("New", newroleViewmodel);
		}
	

		[HttpGet]
		public IActionResult addAdmin()
		{
			return View();
		}
		[HttpPost]
		public async Task< IActionResult> addAdmin(RegisterViewModel newUser)
		{
			if (newUser == null)
			{
				return BadRequest("User data is required.");
			}
			if (ModelState.IsValid)
			{

				//map view model to application user
				ApplicationUser applicatonUser = new ApplicationUser();
				applicatonUser.UserName = newUser.Username;
				applicatonUser.Email = newUser.Email;
				applicatonUser.Address = newUser.Address;
				//applicatonUser.PasswordHash = newUser.Password;

				//save in db call user manger type of user injected TYPE application user
				IdentityResult result = await userManager.CreateAsync(applicatonUser, newUser.Password);//hi take applicationuser not viewmodel so map before it
																							 //save in db call user manger type of user injected TYPE application user
																							 //thses function call store then call context then call DB

				if (result.Succeeded)//saved in database done
				{
					// Add to "Admin" role //add to db 
					await userManager.AddToRoleAsync(applicatonUser, "admin");

				
				   //create cookie
					await signInManager.SignInAsync(applicatonUser, false);
					return RedirectToAction("Index", "Home");

					//create cookie using SignInManager<ApplicationUser> in construcctor

					//await signInManager.SignInAsync(applicatonUser, false); //default take id name and role  
					//for add extra info not just default
					//List<Claim> claimss = new List<Claim>();
					//claimss.Add(new Claim("Color", "red")); 
					//await signInManager.SignInWithClaimsAsync(applicatonUser,false, claimss);// false for not presistant we will make it true in login action

					// You can redirect to a login page or home page 

					//await userManager.AddToRoleAsync(applicatonUser, "student"); // return identity result

					
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description); // send to view u can send key ""
				}
			}

			return View(newUser);
		}
	}
}