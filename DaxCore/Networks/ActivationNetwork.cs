﻿using DaxCore.ActivationFunctions;
using DaxCore.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaxCore.Networks
{
	/// <summary>
	/// Activation network
	/// </summary>
	/// 
	/// <remarks>Activation network is a base for multi-layer neural network
	/// with activation functions. It consists of <see cref="ActivationLayer">activation
	/// layers</see>.</remarks>
	///
	public class ActivationNetwork : Network
	{
		/// <summary>
		/// Network's layers accessor
		/// </summary>
		/// 
		/// <param name="index">Layer index</param>
		/// 
		/// <remarks>Allows to access network's layer.</remarks>
		/// 
		public new ActivationLayer this[int index]
		{
			get { return ((ActivationLayer)layers[index]); }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ActivationNetwork"/> class
		/// </summary>
		/// <param name="function">Activation function of neurons of the network</param>
		/// <param name="inputsCount">Network's inputs count</param>
		/// <param name="neuronsCount">Array, which specifies the amount of neurons in
		/// each layer of the neural network</param>
		/// 
		/// <remarks>The new network will be randomized (see <see cref="ActivationNeuron.Randomize"/>
		/// method) after it is created.</remarks>
		/// 
		/// <example>The following sample illustrates the usage of <c>ActivationNetwork</c> class:
		/// <code>
		///		// create activation network
		///		ActivationNetwork network = new ActivationNetwork(
		///			new SigmoidFunction( ), // sigmoid activation function
		///			3,                      // 3 inputs
		///			4, 1 );                 // 2 layers:
		///                                 // 4 neurons in the firs layer
		///                                 // 1 neuron in the second layer
		///	</code>
		/// </example>
		/// 
		public ActivationNetwork(IActivationFunction function, int inputsCount, params int[] neuronsCount)
							: base(inputsCount, neuronsCount.Length)
		{
			// create each layer
			for (int i = 0; i < layersCount; i++)
			{
				layers[i] = new ActivationLayer(
					// neurons count in the layer
					neuronsCount[i],
					// inputs count of the layer
					(i == 0) ? inputsCount : neuronsCount[i - 1],
					// activation function of the layer
					function);
			}
		}
	}
}
