using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class Administrator
	{
		public AdminAccount AdminAccount { get; private set; }

		public Administrator()
		{
			var json = File.ReadAllText("appsettings.json");
			var appSettings = JsonConvert.DeserializeObject<AppSettings>(json);
			AdminAccount = appSettings.AdminAccount;
		}
	}

	public class AdminAccount
	{
		public int Role { get; set; }
	}

	public class AppSettings
	{
		public AdminAccount AdminAccount { get; set; }
		public StaffAccount StaffAccount { get; set; }
	}
}
