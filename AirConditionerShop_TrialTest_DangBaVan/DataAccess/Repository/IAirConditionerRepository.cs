using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
	public interface IAirConditionerRepository
	{
		public void InsertACInfo(AirConditioner AC);
		public void UpdateACInfo(AirConditioner AC);
		public void DeleteACInfo(int AirConditionerId);
		public List<AirConditioner> getAllACInfo();
		List<AirConditioner> SearchAC(string search, string selectedCategory);
	}
}
