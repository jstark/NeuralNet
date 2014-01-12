using System;

namespace NeuralLib
{
	public delegate double ToActivationFunction(double arg);
	public delegate double ToActivationDerivative(double arg);
	/// <summary>
	/// Summary description for Neuron.
	/// </summary>
	/// 
	[Serializable]
	public class Neuron
	{
		//
		static Random ran = new Random(DateTime.Now.Second);
		//
		private double bias;
		//
		private double[] input;
		//
		private double[] weights;
		//
		private double output;
		//
		private double delta;
		//
		public Neuron(uint inputLength)
		{
			// allocate memory to hold weights
			weights = new double[inputLength];
		}
		//
		public void Randomize(double minValue, double maxValue)
		{	
			// randomize weights
			for(int i=0; i<weights.Length; i++)
				weights[i] = minValue+(maxValue-minValue)*ran.NextDouble();
			
			// randomize bias
			bias = minValue+(maxValue-minValue)*ran.NextDouble();
		}
		//
		public void SetInputVector(double[] input)
		{
			if(input.Length == weights.Length)
				this.input = input;
			else
				throw new Exception("Input vector length not equal to weight vector length");
		}
		//
		public double GetOutput()
		{
			return output;
		}
		//
		public double GetWeight(uint element)
		{
			return weights[element];
		}
		//
		public void SetWeight(uint position, double val)
		{
			weights[position] = val;
		}
		//
		public void UpdateWeight(uint position, double update)
		{
			weights[position] += update;
		}
		//
		public double GetBias()
		{
			return bias;
		}
		//
		public void UpdateBias(double update)
		{
			bias += update;
		}
		//
		public void SetBias(double newBias)
		{
			bias = newBias;
		}
		//
		public void FeedForward(ToActivationFunction pointer)
		{
			double neuronInput = 0.0;
			//
			for(int i=0; i<weights.Length; i++)
			{
				neuronInput += input[i]*weights[i];
			}
			//
			// add bias
			neuronInput += bias;
			// pass neuron input to activation function and get output
			
			output = pointer(neuronInput);
		}
		//
		public void WriteWeights()
		{
			for(int i=0; i<=weights.Length; i++)
			{
				if(i == weights.Length)
					Console.Write("*B* {0}", bias.ToString("F4"));
				else
                    Console.Write(weights[i].ToString("F4")+" ");
			}
			Console.Write("\n");
		}
		//
		public double GetDelta()
		{
			return this.delta;
		}
		//
		public void SetDelta(double dValue)
		{
			this.delta = dValue;
		}
		//
		public override string ToString()
		{
			string s = null;
			//
			for(int i=0; i<weights.Length; i++)
				s += weights[i].ToString("E5")+" ";
			//
			s += bias.ToString("E5");
			//
			return s;
		}
		//
		public double GetSumOfSquaredWeights()
		{
			double sum = 0.0;
			//
			for(int i=0; i<this.weights.Length; i++)
				sum += weights[i]*weights[i];
			//
			return sum;
		}
	}
}
