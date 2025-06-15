using jwtTokienLec3.Authintcation;
using jwtTokienLec3.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static System.Net.WebRequestMethods;

namespace jwtTokienLec3.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountUsersController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> userManager;
		private readonly SignInManager<ApplicationUser> signInManager;

		public IConfiguration Config { get; }

		public AccountUsersController(UserManager<ApplicationUser> userManager,IConfiguration config, SignInManager<ApplicationUser> signInManager)
		{
			this.userManager = userManager;
			Config = config; // to read fields in app.setting
			this.signInManager = signInManager;
		}
		// POST: new user creation
		[HttpPost("register")]// api/AccountUsers/register
		public async Task<IActionResult> Register(RegisterViewModel newUser) //Dto
		{
			if (ModelState.IsValid)
			{

				//map view model to application user
				ApplicationUser applicatonUser = new ApplicationUser();
				applicatonUser.UserName = newUser.Username;
				applicatonUser.Email = newUser.Email;
				//applicatonUser.PasswordHash = newUser.Password;

				//save in db call user manger type of user injected TYPE application user
				IdentityResult result = await userManager.CreateAsync(applicatonUser, newUser.Password);//hi take applicationuser not viewmodel so map before it
																							 //save in db call user manger type of user injected TYPE application user
																							 //thses function call store then call context then call DB

				if (result.Succeeded)//saved in database done
				{
					return Ok("Account created");



					//OLD MVC
					////create cookie using SignInManager<ApplicationUser> in construcctor

					//await signInManager.SignInAsync(applicatonUser, false); //default take id name and role  
					//														//for add extra info not just default
					//														//List<Claim> claimss = new List<Claim>();
					//														//claimss.Add(new Claim("Color", "red")); 
					//														//await signInManager.SignInWithClaimsAsync(applicatonUser,false, claimss);// false for not presistant we will make it true in login action

					//// You can redirect to a login page or home page 

					//await userManager.AddToRoleAsync(applicatonUser, "student"); // return identity result

					//return RedirectToAction("Index", "Home");



				}
				return BadRequest(result.Errors.FirstOrDefault());
				//foreach (var error in result.Errors)
				//{
				//	ModelState.AddModelError("", error.Description); // send to view u can send key ""
				//}
			}

			return BadRequest(ModelState);
		}
		
		
		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginViewModel userDto) //dto
		{
			if (ModelState.IsValid) 
			{	//ceack found and create tokien
				//check in datbase if another like emp will use repository for it but here we use user manager
				ApplicationUser userModel = await userManager.FindByNameAsync(userDto.UserName); //return application user record from db
				if (userModel != null)  //check passeord also not just username
				{
					//check password in database with ur password in form
					bool isPasswordValid = await userManager.CheckPasswordAsync(userModel, userDto.Password);


					if (isPasswordValid == true) //found username and passwrod now
					{
						//claims will be inside tokien
						var claims=new List<Claim>();
						claims.Add(new Claim(ClaimTypes.Name, userModel.UserName));//for application user
						claims.Add(new Claim(ClaimTypes.NameIdentifier, userModel.Id)); //for application user
						claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));//tokien id changeable new tokien with anther login min 15 p2 
						//add roles in claims get role by user manager 
						var roles = await userManager.GetRolesAsync(userModel); //list string
						foreach (var roleItem in roles) {
							claims.Add(new Claim(ClaimTypes.Role, roleItem));
						}

						//signingCredentials for verify tokien by key and algorithm

						SecurityKey SigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["JwtSettings:secretKey"])); //string as byte

						SigningCredentials signCredintial = new SigningCredentials(SigningKey , SecurityAlgorithms.HmacSha256);//sign dad

						//create tokien secret  represent tokien not create it ##################################################### create under 
						JwtSecurityToken mytokien = new JwtSecurityToken(
											issuer: Config["JwtSettings:validIssuer"],  //url web api swager		
											audience: Config["JwtSettings:validAudience"], //like angular
											claims: claims,
											expires: DateTime.Now.AddHours(1),
										    signingCredentials: new SigningCredentials(SigningKey, SecurityAlgorithms.HmacSha256)
												);

						return Ok(new
						{
							token= new JwtSecurityTokenHandler().WriteToken(mytokien) , //create instance token here//////////////////////////////////////////////////////
							expireation = mytokien.ValidTo								//serialzie and add to payload oftokien
						});



						//old mvc
						//SET Cookie //create cookie after check data valid in database no in form 
						//using SignInManager<ApplicationUser> in construcctor
						//await signInManager.SignInAsync(userModel, userVM.RememberMe);      //default take id name and role  
						//for add extra info not just default
						//List<Claim> claimss = new List<Claim>();
						//claimss.Add(new Claim("Color", "red")); 
						//await signInManager.SignInWithClaimsAsync(applicatonUser,false, claimss);
						// false for not presistant we will make it true in login action
						//return RedirectToAction("Index", "Home");
					}
				}

				return Unauthorized(); //401 for no name like this name
				//ModelState.AddModelError("", "Invalid login attempt.");
			}

			return Unauthorized(); //401
		}
	}
}
