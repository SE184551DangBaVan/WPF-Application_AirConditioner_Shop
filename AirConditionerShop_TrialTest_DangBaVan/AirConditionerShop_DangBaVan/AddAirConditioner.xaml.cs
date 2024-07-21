using BusinessLayer;
using DataAccess.Models;
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
	/// Interaction logic for AddAirConditioner.xaml
	/// </summary>
	public partial class AddAirConditioner : Window
	{
		private readonly AirConditionerObject airConditionerObj;
		public AddAirConditioner()
		{
			InitializeComponent();
			airConditionerObj = new AirConditionerObject();
		}

		private void btnAddAC_Click(object sender, RoutedEventArgs e)
		{
			int ACid;
			if (!int.TryParse(tbAirConditionerId.Text, out ACid))
			{
				MessageBox.Show("Invalid format for Air Conditioner ID.");
				return;
			}
			int Quantity;
			if (!int.TryParse(tbQuantity.Text, out Quantity))
			{
				MessageBox.Show("Invalid format for Quantity.");
				return;
			}
			if (int.Parse(tbQuantity.Text) < 0 || int.Parse(tbQuantity.Text) >= 4000000)
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
			if (float.Parse(tbDollarPrice.Text) < 0 || float.Parse(tbDollarPrice.Text) > 4000000)
			{
				MessageBox.Show("Dollar Price must be greater than or equal to 0 and less than 4 000 000.");
				return;
			}
			AirConditioner ACInformation = new AirConditioner()
			{
				AirConditionerId = int.Parse(tbAirConditionerId.Text),
				AirConditionerName = tbAirConditionerName.Text,
				Warranty = tbWarranty.Text,
				SoundPressureLevel = tbSoundPressureLevel.Text,
				FeatureFunction = tbFeatureFunction.Text,
				Quantity = int.Parse(tbQuantity.Text),
				DollarPrice = float.Parse(tbDollarPrice.Text),
				SupplierId = tbSupplierId.Text,
			};
			airConditionerObj.AddAC(ACInformation);
			MessageBox.Show("Air Conditioner Added!");
			Close();
		}

		private void btnCancelAC_Click(object sender, RoutedEventArgs e)
		{
			if (MessageBox.Show("Do you want to quit?", "Add", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				Close();
			}
		}
	}
}
