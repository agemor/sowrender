using System;
using MySql.Data.MySqlClient;

namespace AurenderTycoonLeo
{
	class MainClass
	{
		public static void Main(string[] args)
		{

			string connectionData = "Server=hyunjun.org;Database=hyunjun;Uid=;Pwd=zzz;";

			MySqlConnection connection = new MySqlConnection(connectionData);



			connection.Open();

		
				


			/**
			 * 
			 * 
			 * 
			 * 
			 * 
			 * 
			 * 
			 * 
			 * 
			 */


			Console.WriteLine("Hello World!");
		}
	}
}
