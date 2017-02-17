using DaxCore.Networks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DaxCore.Serialization
{
	public class Serialization
	{
		public static void SaveNetwork(Network network, string file)
		{
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None);
			formatter.Serialize(stream, network);
			stream.Close();
		}

		public static ActivationNetwork LoadNetwork(string file)
		{
			IFormatter formatter = new BinaryFormatter();
			Stream stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read);
            ActivationNetwork network = (ActivationNetwork)formatter.Deserialize(stream);
			stream.Close();
			return network;
		}
	}
}
