using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
	public interface IStaffMemberRepository
	{
		public void InsertStaff(StaffMember c);
		public void UpdateStaff(StaffMember c);
		public void DeleteStaff(int id);
		public StaffMember Authenticate(string email, string password);
		public int? GetStaffMemberByMail(string email);
	}
}
