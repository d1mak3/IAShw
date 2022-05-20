using System;
using System.Collections.Generic;

namespace ProgToTranslate
{
	[Serializable]
	class Project
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string AccessToken { get; set; }		
		public List<User> UsersInProject { get; set; }		
		
		public bool ContainsUser(string userLogin)
		{
			foreach (User user in UsersInProject)
			{
				if (userLogin == user.Login)
					return true;
			}

			return false;
		}
	}
}
