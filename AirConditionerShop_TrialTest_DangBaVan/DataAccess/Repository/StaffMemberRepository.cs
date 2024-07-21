using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
	public class StaffMemberRepository : IStaffMemberRepository
	{

		public StaffMember Authenticate(string email, string password)
		{
			try
			{
				using var context = new AirConditionerShop2024DbContext();
				return context.StaffMembers.FirstOrDefault(c => c.EmailAddress == email && c.Password == password);

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void DeleteStaff(int id)
		{
			throw new NotImplementedException();
		}

		public int? GetStaffMemberByMail(string email)
		{
			try
			{
				using var context = new AirConditionerShop2024DbContext();
				var user = context.StaffMembers.SingleOrDefault(c => c.EmailAddress == email);
				return user?.Role;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public void InsertStaff(StaffMember c)
		{
			throw new NotImplementedException();
		}

		public void UpdateStaff(StaffMember c)
		{
			throw new NotImplementedException();
		}
	}
}
