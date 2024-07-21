using BusinessLayer;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirConditionerShop_DangBaVan
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly AirConditionerObject airConditionerObject;
		public MainWindow()
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

		private void BackButton_Click(object sender, RoutedEventArgs e)
		{
			LoginWindow window = new LoginWindow();
			window.Show();
			Close();
		}

		private void Search_Click(object sender, RoutedEventArgs e)
		{
			string search = txtSearch.Text;
			string selectedCategory = ((ComboBoxItem)cmbSearchCategory.SelectedItem)?.Content.ToString();

			AirConditionerDataGrid.ItemsSource = airConditionerObject.SearchAC(search, selectedCategory);

		}
	}
}