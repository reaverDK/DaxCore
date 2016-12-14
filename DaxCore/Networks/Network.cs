using DaxCore.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaxCore.Networks
{
	/// <summary>
	/// Base neural network class
	/// </summary>
	/// 
	/// <remarks>This is a base neural netwok class, which represents
	/// collection of neuron's layers.</remarks>
	/// 
	[Serializable]
	public abstract class Network
	{
		/// <summary>
		/// Network's layers
		/// </summary>
		protected Layer[] layers;

		/// <summary>
		/// Network's inputs count
		/// </summary>
		public int InputsCount { get; protected set; }

		/// <summary>
		/// Network's layers count
		/// </summary>
		public int LayersCount { get; protected set; }

		/// <summary>
		/// Network's output vector
		/// </summary>
		/// 
		/// <remarks>The calculation way of network's output vector is determined by
		/// inherited class.</remarks>
		/// 
		public double[] Output { get; protected set; }
        /// <summary>
        /// Network's backpropagation
        /// </summary>
        /// 
        /// <remarks>Used for training the network</remarks>
        private Learning.BackPropagationLearning backprop { get; set; }
       
		/// <summary>
		/// Network's layers accessor
		/// </summary>
		/// 
		/// <param name="index">Layer index</param>
		/// 
		/// <remarks>Allows to access network's layer.</remarks>
		/// 
		public Layer this[int index]
		{
			get { return layers[index]; }
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="Network"/> class
		/// </summary>
		/// 
		/// <param name="inputsCount">Network's inputs count</param>
		/// <param name="layersCount">Network's layers count</param>
		/// 
		/// <remarks>Protected constructor, which initializes <see cref="inputsCount"/>,
		/// <see cref="layersCount"/> and <see cref="layers"/> members.</remarks>
		/// 
		protected Network(int inputsCount, int layersCount)
		{
			this.InputsCount = Math.Max(1, inputsCount);
			this.LayersCount = Math.Max(1, layersCount);
			// create collection of layers
			layers = new Layer[this.LayersCount];
		}

		/// <summary>
		/// Compute output vector of the network
		/// </summary>
		/// 
		/// <param name="input">Input vector</param>
		/// 
		/// <returns>Returns network's output vector</returns>
		/// 
		/// <remarks>The actual network's output vecor is determined by inherited class and it
		/// represents an output vector of the last layer of the network. The output vector is
		/// also stored in <see cref="Output"/> property.</remarks>
		/// 
		public virtual double[] Compute(double[] input)
		{
			Output = input;

			// compute each layer
			foreach (Layer layer in layers)
			{
				Output = layer.Compute(Output);
			}

			return Output;
		}

		/// <summary>
		/// Randomize layers of the network
		/// </summary>
		/// 
		/// <remarks>Randomizes network's layers by calling <see cref="Layer.Randomize"/> method
		/// of each layer.</remarks>
		/// 
		public virtual void Randomize()
		{
			foreach (Layer layer in layers)
			{
				layer.Randomize();
			}
		}
    }
}
