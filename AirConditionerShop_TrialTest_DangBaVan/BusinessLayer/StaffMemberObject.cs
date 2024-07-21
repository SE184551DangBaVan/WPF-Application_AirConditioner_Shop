using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public class StaffMemberObject
	{
		private readonly IStaffMemberRepository _staffmemberRepository;
		public StaffMemberObject()
		{
			_staffmemberRepository = new StaffMemberRepository();

		}
		public bool Login(string email, string password)
		{
			if (_staffmemberRepository.Authenticate(email, password) == null)
			{
				return false;
			}
			else
			{
				return true;
			}

		}

		public int? GetRoleByEmail(string email)
		{
			int? role = 0;
			return role = _staffmemberRepository.GetStaffMemberByMail(email);
		}
	}
}
