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
	/// Interaction logic for AirConditionerManagement.xaml
	/// </summary>
	public partial class AirConditionerManagement : Window
	{
		private readonly AirConditionerObject airConditionerObject;
		public AirConditionerManagement()
		{
			InitializeComponent();
			airConditionerObject = new AirConditionerObject();
			Loaded += AirConditionerLoad;
		}

		private void AirConditionerLoad(object sender, RoutedEventArgs e)
		{
			LoadAirConditioner();
		}

		private void LoadAirConditioner()
		{
			AirConditionerDataGrid.ItemsSource = null;
			AirConditionerDataGrid.ItemsSource = airConditionerObject.GetAllACInformation();

		}

		private void Search_Click(object sender, RoutedEventArgs e)
		{
			string search = txtSearch.Text;
			string selectedCategory = ((ComboBoxItem)cmbSearchCategory.SelectedItem)?.Content.ToString();

			AirConditionerDataGrid.ItemsSource = airConditionerObject.SearchAC(search, selectedCategory);
		}

		private void BackButton_Click(object sender, RoutedEventArgs e)
		{
			LoginWindow window = new LoginWindow();
			window.Show();
			Close();
		}

		private void AddButton_Click(object sender, RoutedEventArgs e)
		{
			AddAirConditioner addWindow = new AddAirConditioner();
			addWindow.Show();
		}

		private void UpdateButton_Click(object sender, RoutedEventArgs e)
		{
			UpdateAirConditioner updateAC = new UpdateAirConditioner((AirConditioner)AirConditionerDataGrid.SelectedItem);
			updateAC.Show();
		}

		private void DeleteButton_Click(object sender, RoutedEventArgs e)
		{
			var selectedAC = (AirConditioner)AirConditionerDataGrid.SelectedItem;
			if (selectedAC != null)
			{
				MessageBoxResult result = MessageBox.Show(
			   "Are you sure you want to delete this Item?", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
				if (result == MessageBoxResult.Yes)
				{
					airConditionerObject.Delete(selectedAC.AirConditionerId);
					MessageBox.Show("AC deleted successfully!");
					LoadAirConditioner();
				}
			}
		}

	}
}
