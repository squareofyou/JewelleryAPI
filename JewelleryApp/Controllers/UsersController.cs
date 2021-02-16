using JewelleryApp.Models;
using JewelleryApp.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace JewelleryApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class UsersController : ControllerBase
	{
		private readonly IUserRepository _userRepo;
		public UsersController (IUserRepository userRepo)
		{
			_userRepo = userRepo;
		}

		[AllowAnonymous]
		[HttpPost("authenticate")]
		public IActionResult Authenticate([FromBody] AuthenticationModel model)
		{
			var user = _userRepo.Authenticate(model.Username, model.Password);
			if(user == null)
			{
				return BadRequest(new { message = "Username or passoword is incorrect" });
			}
			return Ok(user);

		}
	}
}
