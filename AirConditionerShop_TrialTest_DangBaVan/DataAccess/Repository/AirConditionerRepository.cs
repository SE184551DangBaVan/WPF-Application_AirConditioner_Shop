using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
	public class AirConditionerRepository : IAirConditionerRepository
	{
		public void InsertACInfo(AirConditioner AC)
		{
			try
			{
				using var context = new AirConditionerShop2024DbContext();
				context.AirConditioners.Add(AC);
				context.SaveChanges();


			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		public void UpdateACInfo(AirConditioner AC)
		{
			try
			{
				using var context = new AirConditionerShop2024DbContext();
				context.Entry(AC).State = EntityState.Modified;
				context.SaveChanges();


			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
		public void DeleteACInfo(int AirConditionerId)
		{
			try
			{
				using var context = new AirConditionerShop2024DbContext();
				AirConditioner? deletedACInfo = context.AirConditioners.FirstOrDefault(ri => ri.AirConditionerId == AirConditionerId);
				if (deletedACInfo == null)
				{
					throw new Exception("No Air Conditioner was found");
				}
				deletedACInfo.Quantity = 0;
				context.SaveChanges();

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public List<AirConditioner> getAllACInfo()
		{
			try
			{
				using var context = new AirConditionerShop2024DbContext();
				return context.AirConditioners.Include(ri => ri.Supplier).Where(ri => ri.Quantity >= 1).ToList();

			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}

		}

		public List<AirConditioner> SearchAC(string search, string selectedCategory)
		{
			try
			{
				using var context = new AirConditionerShop2024DbContext();
				int quantitySearch;
				bool isQuantitySearch = int.TryParse(search, out quantitySearch);

				var query = context.AirConditioners
					.Include(ri => ri.Supplier)
					.Where(ri => (ri.Quantity != null && ri.Quantity.Equals(search)) ||
								 (isQuantitySearch && ri.Quantity.HasValue && ri.Quantity.Value == quantitySearch));

				if (!string.IsNullOrEmpty(selectedCategory) && selectedCategory != "Features")
				{
					query = query.Where(ri => ri.FeatureFunction != null && ri.FeatureFunction.Contains(selectedCategory));
				}

				return query.ToList();
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
