using System;

namespace NeuralLib
{
	/// <summary>
	/// Summary description for Layer.
	/// </summary>
	/// 
	[Serializable]
	public abstract class Layer
	{

		protected double[] input;
		protected double[] output;
		protected uint size;
		//
		public Layer(uint numberOfNeurons)
		{
			// allocate memory
			output = new double[numberOfNeurons];
			size = numberOfNeurons;
		}
		//
		public void SetInput(double[] vector)
		{
                this.input = vector;
		}
		//
		public double GetOutput(int neuronPosition)
		{
			return output[neuronPosition];
		}
		//
		public double[] GetOutputVector()
		{
			return this.output;
		}
		//
		public uint GetSize()
		{
			return this.size;
		}
		//
		public abstract void FeedForward();
		//
	}
}
