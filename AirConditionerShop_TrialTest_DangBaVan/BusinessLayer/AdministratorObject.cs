using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public class AdministratorObject
	{
		private readonly Administrator _admin;

		public AdministratorObject()
		{
			_admin = new Administrator();

		}

		public int CheckAdminRole()
		{
			return _admin.AdminAccount.Role;
		}

	}
}
