using BusinessLayer;
using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AirConditionerShop_DangBaVan
{
	/// <summary>
	/// Interaction logic for UpdateAirConditioner.xaml
	/// </summary>
	public partial class UpdateAirConditioner : Window
	{
		private readonly AirConditionerObject airConditionerObject;
		private AirConditioner airConditioner;
		public UpdateAirConditioner(AirConditioner AC)
		{
			InitializeComponent();
			airConditioner = AC;
			airConditionerObject = new AirConditionerObject();
			DataContext = airConditioner;
		}

		private void btnUpdateAC_Click(object sender, RoutedEventArgs e)
		{
			int Quantity;
			if (!int.TryParse(tbQuantity.Text, out Quantity))
			{
				MessageBox.Show("Invalid format for Quantity.");
				return;
			}
			if (int.Parse(tbQuantity.Text) < 0 || int.Parse(tbQuantity.Text) > 4000000)
			{
				MessageBox.Show("Quantity must be greater than or equal to 0 and less than 4 000 000.");
				return;
			}
			float Price;
			if (!float.TryParse(tbDollarPrice.Text, out Price))
			{
				MessageBox.Show("Invalid format for Dollar Price.");
				return;
			}
			if (float.Parse(tbDollarPrice.Text) < 0 || float.Parse(tbDollarPrice.Text) >= 4000000)
			{
				MessageBox.Show("Dollar Price must be greater than or equal to 0 and less than 4 000 000.");
				return;
			}
			try
			{
				AirConditioner updateAC = new AirConditioner()
				{
					AirConditionerId = airConditioner.AirConditionerId,
					AirConditionerName = tbAirConditionerName.Text,
					Warranty = tbWarranty.Text,
					SoundPressureLevel = tbSoundPressureLevel.Text,
					FeatureFunction = tbFeatureFunction.Text,
					Quantity = int.Parse(tbQuantity.Text),
					DollarPrice = float.Parse(tbDollarPrice.Text),
					SupplierId = tbSupplierId.Text,
				};


				airConditionerObject.UpdateAirConditioner(updateAC);
				MessageBox.Show("Updated Air Conditioner successfully");
				Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred: {ex.Message}");
			}
		}

		private void btnCancelAC_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Do you want to quit?", "Update", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				Close();
			}
		}
	}
}
