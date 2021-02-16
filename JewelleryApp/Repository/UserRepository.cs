using JewelleryApp.Data;
using JewelleryApp.Models;
using JewelleryApp.Repository.IRepository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryApp.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly UserData _userdata = new UserData();
		private readonly AppSettings _appSettings;

		public UserRepository(IOptions<AppSettings> appSettings)
        {
			_appSettings = appSettings.Value;
        }

		public User Authenticate(string username, string password)
		{
			var user = _userdata.users.SingleOrDefault(x => x.Username == username && x.Password == password);

			//user not found
			if (user == null)
			{				
				return user;
			}

			//if user was found generate JWT token

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name,user.Id.ToString()),
					new Claim(ClaimTypes.Role,user.Role)
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials
										(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			user.Token = tokenHandler.WriteToken(token);

			user.Password = "";
			user.loggedIn = true;
			return user;
		}
	}
}
