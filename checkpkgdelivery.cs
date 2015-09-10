using System;
using System.IO;

namespace Symantec.CWoC {
    class CheckPkgDelivery {
		public static void Main(string [] args) {
		
			// Need to run on the Altiris Agent folder
			string base_folder = "Package Server Agent\\PackageStatus";
			string delivery_folder = "Package Delivery";
			
			// Check delivery folder against base
			string [] delivery_folder_list = Directory.GetDirectories(delivery_folder);
			string [] base_folder_list = Directory.GetDirectories(base_folder);
			
			foreach(string delivery_path in delivery_folder_list) {
				foreach(string base_path in base_folder_list) {
					if (delivery_path.Replace(delivery_folder + "\\", "") == base_path.Replace(base_folder + "\\", "")) {
						goto okay;
					}
				}
				Console.WriteLine("del /s /f {0}", delivery_path);
				okay:
					continue;
			}
		}
	}
}
