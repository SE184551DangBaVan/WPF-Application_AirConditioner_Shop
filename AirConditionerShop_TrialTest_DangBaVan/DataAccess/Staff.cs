using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class Staff
	{
		public StaffAccount StaffAccount { get; private set; }

		public Staff()
		{
			var json = File.ReadAllText("appsettings.json");
			var appSettings = JsonConvert.DeserializeObject<AppSettings>(json);
			StaffAccount = appSettings.StaffAccount;
		}
	}

	public class StaffAccount
	{
		public int Role { get; set; }
	}

}
