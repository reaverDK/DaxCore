using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DaxCore;


namespace TestClient
{
	class Program
	{
        static void Main(string[] args)
        {
            //File path
            string filepath = "C:\\Users\\tbn\\Source\\Repos\\DaxCore\\data.csv";
            string[][] data = loadData(filepath);

            Console.WriteLine("###########Test1###########");
            DaxCore.Networks.ActivationNetwork network = new DaxCore.Networks.ActivationNetwork(new DaxCore.ActivationFunctions.BipolarSigmoidFunction(), data[1].Length - 1, 3, 3);
            DaxCore.Learning.BackPropagationLearning backProp = new DaxCore.Learning.BackPropagationLearning(network);
            backProp.LearningRate = 0.1;
            backProp.Momentum = 0.3;

            double[] input = new double[data[1].Length - 1];
            double[] output = new double[3];
            double[] netOut = new double[3];
            double err = 1000;
            int iteration = 0;
            int randomIndex = 1;
            List<int> ints = new List<int>();
            Random rand;

            //Print out the data in the file
            for (int i = 1; i < data.Length; i++)
            {
                //Select random data set.
                while (ints.Contains(randomIndex))
                {
                    rand = new Random(Guid.NewGuid().GetHashCode());
                    randomIndex = rand.Next(1, (int)(data.Length));
                }
                ints.Add(randomIndex);

                

                for (int j = 0; j < data[i].Length; j++)
                {
                    if (j == 0)
                    {
                        switch (data[randomIndex][j])
                        {
                            case "L":
                                output[0] = 1;
                                output[1] = 0;
                                output[2] = 0;
                                break;
                            case "B":
                                output[0] = 0;
                                output[1] = 1;
                                output[2] = 0;
                                break;
                            case "R":
                                output[0] = 0;
                                output[1] = 0;
                                output[2] = 1;
                                break;
                        }
                    }
                    else
                        //input default between -2 and 2.
                        input[j - 1] = -2 + ((double.Parse(data[randomIndex][j]) - 1)*(2-(-2)))/(5-1);
                }
                    if (i < data.Length * 0.9)
                    {
                        err = 1000;
                        iteration = 0;
                        while (err > 0.01 && iteration < 1000)
                        {
                            err = backProp.Run(input, output);
                            iteration++;
                            Console.WriteLine("Iteration: " + iteration);
                        }
                        Console.WriteLine("Desired: " + output[0] + ", " + output[1] + ", " + output[2]);
                    }
                    else
                    {
                        Console.WriteLine("Press a key for compute new data set:");
                        Console.ReadKey();
                        netOut = network.Compute(input);
                        Console.WriteLine("Test data " + i);
                        Console.WriteLine("Desired: " + output[0] + ", " + output[1] + ", " + output[2]);
                        Console.WriteLine("Actual: " + netOut[0] + ", " + netOut[1] + ", " + netOut[2]);
                    }
                    Console.WriteLine("data set: " + randomIndex + "\n");
                }

                Console.ReadKey();

                Console.WriteLine("###########Test2###########");



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
			char[] whitespace = new char[] { ' ', '\t', ';' };

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
