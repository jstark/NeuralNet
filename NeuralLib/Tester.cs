using System;

namespace NeuralLib
{
	/// <summary>
	/// Summary description for Tester.
	/// </summary>
	public class Tester
	{
		public static void Main()
		{
			//BackPropNet net = new BackPropNet(2,1, 6);
			//net.SetOutputActivationFunction(ActivationFunction.LogSig);
			//net.Randomize(-0.5, 0.5);
			//
			//RProp rp = new RProp(net, "X", "Y");
			//rp.SetValidationData("VX", "VY");
			//rp.WeightDecay = false;
			//rp.Epochs = 15000;
			//rp.MaxFailures = 10000;
			//
			//rp.Train();
			//
			//net.Simulate("X", "Y", "res1");
			//net.Simulate("VX", "VY", "res2");
			//string s = Console.ReadLine();
			//if(s == "y")
			//{
			//	Console.WriteLine("Network saved");
			//	BackPropNet.BinarySave("net6_wV", net);
			//}
			BackPropNet net = BackPropNet.BinaryLoad("net6_2");
			net.Simulate("res1", "results");
		}
	}
}
