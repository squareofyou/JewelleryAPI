using JewelleryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelleryApp.Repository.IRepository
{
	public interface IUserRepository
	{
		User Authenticate(string username, string password);
	
	}
}
