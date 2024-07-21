using BusinessLayer;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirConditionerShop_DangBaVan
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		private readonly StaffMemberObject staffmemberObject;
		private readonly AdministratorObject adminObject;
		private readonly StaffAccountObject staffAccountObject;

		public LoginWindow()
		{
			InitializeComponent();
			staffmemberObject = new StaffMemberObject();
			adminObject = new AdministratorObject();
			staffAccountObject = new StaffAccountObject();
		}

		private void btnLogin_Click(object sender, RoutedEventArgs e)
		{
			string email = txtEmail.Text;
			string password = txtPassword.Password;
			int? role = staffmemberObject.GetRoleByEmail(email);
			if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
			{
				MessageBox.Show("Please input all fields", "Login");
			}
			int Role = adminObject.CheckAdminRole();
			int SRole = staffAccountObject.CheckStaffRole();
			if (Role.Equals(role))
			{
				AirConditionerManagement AdminWindow = new AirConditionerManagement();
				AdminWindow.Show();
				Close();
			}
			else if (SRole.Equals(role))
			{
				MainWindow mainWindow = new MainWindow();
				mainWindow.Show();
				Close();
			}
			else
			{
				bool authorize = staffmemberObject.Login(email, password);
				if (authorize)
				{
					Properties.Settings.Default.Email = email;
					Home home = new Home();
					home.Show();
					Close();
				}
				else
				{
					MessageBox.Show("You have no permission to access this function!", "Login");
				}
			}

		}

	}
}

