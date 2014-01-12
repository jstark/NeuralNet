using System;

namespace NeuralLib
{
	/// <summary>
	/// Summary description for OutputLayer.
	/// </summary>
	/// 
	[Serializable]
	public class OutputLayer : HiddenLayer
	{
		private double[] error;
		private double[] target;
		//
		public OutputLayer(uint numOfNeurons,  Layer previous) : base(numOfNeurons, previous)
		{
			error = new double[numOfNeurons];
		}
		//
		public void SetTarget(double[] target)
		{
			this.target = target;
		}
		//
		public double InstantSSE
		{
			get
			{
				return NMath.SSE(error);
			}
		}
		//
		public void CalculateOutputErrors()
		{
			for(int i=0; i<size; i++)
				error[i] = output[i]-target[i];
		}
		//
		public void BackPropagateError()
		{
			double dummy = 0.0;
			double outp = 0.0;
			//
			for(int i=0; i<size; i++)
			{
				outp = output[i];
				dummy = pDeriv(outp)*error[i];
				layerNeurons[i].SetDelta(dummy);
			}
			//
			((HiddenLayer)previousLayer).BackPropagateError(this);
		}
		//
		public void WriteTarget()
		{
			foreach(double d in this.target)
				Console.Write(d.ToString("F4")+" ");
		}
	}
}
