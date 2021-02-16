using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JewelleryApp.Models;

namespace JewelleryApp.Data
{
	public class UserData
	{
		public IEnumerable<User> users;

		public UserData()
		{
			users = new List<User>
			{
				new User{Id=1,Username = "user001",Password="pass001",Role="Normal"},
				new User{Id=2,Username="user002",Password="pass002",Role="Priviliged"}

			};
		}

	}
}
