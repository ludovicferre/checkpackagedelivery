using System;
using System.IO;

namespace Symantec.CWoC {
    class CheckPkgDelivery {
		public static void Main(string [] args) {
		
			string command = "del /q /s /f";
			string postfix = "";
			// Need to run on the Altiris Agent folder
			if(args.Length == 1) {
				command = args[0];	
			} else if (args.Length == 2) {
				command = args[0];
				postfix = args[1];
			}
			
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
				Console.WriteLine("{0} \"{1}\" {2}", command, delivery_path, postfix);
				okay:
					continue;
			}
		}
	}
}
