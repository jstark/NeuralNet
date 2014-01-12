using System;

namespace NeuralLib
{
	/// <summary>
	/// Summary description for InputLayer.
	/// </summary>
	/// 
	[Serializable]
	public class InputLayer : Layer
	{
		public InputLayer(uint numberOfNeurons) : base(numberOfNeurons)
		{
			//
		}
		//
		public override void FeedForward()
		{
			for(int i=0; i<size; i++)
				output[i] = input[i];
		}
		//
		public void WriteInput()
		{
			for(int i=0; i<size; i++)
				Console.Write(input[i].ToString("F4")+" ");
			Console.Write("\n");
		}
		//
		public void WriteOutput()
		{
			for(int i=0; i<size; i++)
				Console.Write(output[i].ToString("F4")+" ");
			Console.Write("\n");
		}
	}
}
