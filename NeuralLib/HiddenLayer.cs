using System;

namespace NeuralLib
{
	public enum ActivationFunction{LogSig, TanSig, Linear};
	/// <summary>
	/// Summary description for HiddenLayer.
	/// </summary>
	/// 
	[Serializable]
	public class HiddenLayer : Layer
	{
		//
		protected Layer previousLayer;
		//
		protected ActivationFunction activationFunction;
		protected ToActivationFunction pointer;
		protected ToActivationDerivative pDeriv;
		//
		protected Neuron[] layerNeurons;

		public HiddenLayer(uint numberOfNeurons, Layer previous) : base(numberOfNeurons)
		{
			this.previousLayer = previous;
			// default activation function is logsig
			this.activationFunction = ActivationFunction.LogSig;
			this.pointer = new ToActivationFunction(NMath.LogSig);
			this.pDeriv = new ToActivationDerivative(NMath.DLogSig);
			this.input = previous.GetOutputVector();
			//
			try
			{

				layerNeurons = new Neuron[numberOfNeurons];
				//
				for(int i=0; i<numberOfNeurons; i++)
				{
					layerNeurons[i] = new Neuron(previous.GetSize());
					layerNeurons[i].SetInputVector(input);
				}
				//
			}
			catch(System.Exception exception)
			{
				Console.WriteLine("****EXCEPTION****\n {0} {1}", exception.Message);
				previousLayer = null;
				pointer = null;
				layerNeurons = null;
			}
		}
		//
		public void Randomize(double min, double max)
		{
			foreach(Neuron n in layerNeurons)
				n.Randomize(min, max);
		}
		//
		public override void FeedForward()
		{
			for(int i=0; i<size; i++)
			{
				layerNeurons[i].FeedForward(this.pointer);
				output[i] = layerNeurons[i].GetOutput();
			}
		}
		//
		public void WriteOutput()
		{
			for(int i=0; i<size; i++)
				Console.WriteLine(output[i]);
		}
		//
		public void WriteWeights()
		{
			foreach(Neuron n in this.layerNeurons)
			{
				n.WriteWeights();
			}
		}
		//
		public void WriteInput()
		{
			for(int i=0; i<this.previousLayer.GetSize(); i++)
				Console.WriteLine(input[i]);
		}
		//
		public void PrintDeltaVector()
		{
			foreach(Neuron n in this.layerNeurons)
				Console.Write(n.GetDelta().ToString("F4")+" ");
			Console.Write("\n");
		}
		//
		public void BackPropagateError(HiddenLayer nextLayer)
		{
			for(uint i=0; i<size; i++)
			{
				double sum = 0.0;
				double outp = output[i];
				//
				for(uint j=0; j<nextLayer.GetSize(); j++)
				{
					sum += nextLayer.layerNeurons[j].GetWeight(i)*nextLayer.layerNeurons[j].GetDelta();
				}
				//
				this.layerNeurons[i].SetDelta(pDeriv(outp)*sum);
			}
			//
			if(this.previousLayer is HiddenLayer)
				((HiddenLayer)previousLayer).BackPropagateError(this);
		}
		//
		public double GetDelta(uint pos)
		{
			return this.layerNeurons[pos].GetDelta();
		}
		//
		public void UpdateBias(uint pos, double update)
		{
			this.layerNeurons[pos].UpdateBias(update);
		}
		//
		public void UpdateWeight(uint neuronPosition, uint link, double update)
		{
			this.layerNeurons[neuronPosition].UpdateWeight(link, update);
		}
		//
		public void SetActivationFunction(ActivationFunction af)
		{
			this.activationFunction = af;
			//
			switch(af)
			{
				case ActivationFunction.LogSig:
					this.pointer = new ToActivationFunction(NMath.LogSig);
					this.pDeriv = new ToActivationDerivative(NMath.DLogSig);
					break;
				case ActivationFunction.TanSig:
					this.pointer = new ToActivationFunction(NMath.TanSig);
					this.pDeriv = new ToActivationDerivative(NMath.DTanSig);
					break;
				case ActivationFunction.Linear:
					this.pointer = new ToActivationFunction(NMath.Linear);
					this.pDeriv = new ToActivationDerivative(NMath.DLinear);
					break;
				default:
					break;
			}
		}
		//
		public override string ToString()
		{
			string s = null;
			//
			foreach(Neuron n in this.layerNeurons)
				s += n.ToString()+"\n";
			//
			return s;
		}
		//
		public ActivationFunction GetActivationFunction()
		{
			return this.activationFunction;
		}
		//
		public double GetSumOfSquaredWeights()
		{
			double sum = 0.0;
			//
			foreach(Neuron n in this.layerNeurons)
				sum += n.GetSumOfSquaredWeights();
			//
			return sum;
		}
		//
		public double GetWeight(uint neuronPosition, uint weightPosition)
		{
			return this.layerNeurons[neuronPosition].GetWeight(weightPosition);
		}
		//
		public double GetBias(uint neuronPosition)
		{
			return this.layerNeurons[neuronPosition].GetBias();
		}
	}
}

