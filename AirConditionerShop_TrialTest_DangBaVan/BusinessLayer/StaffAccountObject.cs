using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public class StaffAccountObject
	{
		private readonly Staff _staff;

		public StaffAccountObject()
		{
			_staff = new Staff();

		}

		public int CheckStaffRole()
		{
			return _staff.StaffAccount.Role;
		}

	}
}
