using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
	public class AirConditionerObject
	{
		private readonly IAirConditionerRepository airConditionerRepository;
		public AirConditionerObject()
		{
			airConditionerRepository = new AirConditionerRepository();

		}
		public static AirConditioner? AirConditionerSearch { get; set; }

		public void AddAC(AirConditioner ACInformation)
		{
			airConditionerRepository.InsertACInfo(ACInformation);
		}

		public void UpdateAirConditioner(AirConditioner airConditioner)
		{
			airConditionerRepository.UpdateACInfo(airConditioner);
		}
		public void Delete(int AirConditionerId)
		{
			airConditionerRepository.DeleteACInfo(AirConditionerId);
		}

		public List<AirConditioner> GetAllACInformation()
		{
			return airConditionerRepository.getAllACInfo();
		}

		public List<AirConditioner> SearchAC(string search, string selectedCategory)
		{
			return airConditionerRepository.SearchAC(search, selectedCategory);
		}
	}
}
