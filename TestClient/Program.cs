using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestClient
{
	class Program
	{
		static void Main(string[] args)
		{	
			//File path
			string filepath = @"C:\\Users\adam\\Documents\\Visual Studio 2015\\Projects\\DaxCore\\data.csv";
			string[][] data = loadData(filepath);

			//Print out the data in the file
			for (int i=0; i<data.Length; i++)
			{
				for(int j=0; j<data[i].Length; j++)
				{
					Console.WriteLine(data[i][j]);
				}
			}

			Console.ReadKey();
		}

		
		/// <summary>
		/// Loads data from a CSV file into an 2d array.
		/// </summary>
		/// <param name="filepath"></param>
		/// <returns>string[][]</returns>
		public static string[][] loadData(string filepath)
		{
			int row = 0;
			var lines = new List<string[]>();
			char[] whitespace = new char[] { ' ', '\t' };

			try
			{
				StreamReader file = new StreamReader(filepath);

				while (!file.EndOfStream)
				{
					string[] line = file.ReadLine().Split(whitespace);
					lines.Add(line);
					row++;
				}

				var data = lines.ToArray();
				file.Close();
				return data;
			}

			catch (Exception e)
			{
				Console.WriteLine("Could not read the file!");
				Console.WriteLine(e.Message);
			}
			return null;
		}
	}
}
