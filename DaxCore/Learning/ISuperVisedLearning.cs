﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaxCore.Learning
{
	/// <summary>
	/// Supervised learning interface
	/// </summary>
	/// 
	/// <remarks>The interface describes methods, which should be implemented
	/// by all supervised learning algorithms. Supervised learning is such a
	/// type of learning algorithms, where system's desired output is known on
	/// the learning stage. So, given sample input values and desired outputs,
	/// system should adopt its internals to produce correct (or closer to correct)
	/// result after the learning step is complete.</remarks>
	/// 
	public interface ISupervisedLearning
	{
		/// <summary>
		/// Runs learning iteration
		/// </summary>
		/// 
		/// <param name="input">input vector</param>
		/// <param name="output">desired output vector</param>
		/// 
		/// <returns>Returns learning error</returns>
		/// 
		double Run(double[] input, double[] output);

		/// <summary>
		/// Runs learning epoch
		/// </summary>
		/// 
		/// <param name="input">array of input vectors</param>
		/// <param name="output">array of output vectors</param>
		/// 
		/// <returns>Returns sum of learning errors</returns>
		/// 
		double RunEpoch(double[][] input, double[][] output);
	}
}
