using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NeuralLib
{
	/// <summary>
	/// Summary description for BackPropNet.
	/// </summary>
	/// 
	[Serializable]
	public class BackPropNet
	{
		private InputLayer		iLayer;
		private HiddenLayer[]	hLayers;
		private OutputLayer		oLayer;
		private uint			depth;
		//

		public BackPropNet(uint inputSize, uint outSize, params uint[] hiddenSizes)
		{
			try
			{
				iLayer = new InputLayer(inputSize);
				uint numberOfHiddenLayers = (uint)hiddenSizes.Length;
				hLayers = new HiddenLayer[numberOfHiddenLayers];
				//
				hLayers[0] = new HiddenLayer(hiddenSizes[0], iLayer);
				//
				if(numberOfHiddenLayers > 1)
				{
					for(int i=1; i<numberOfHiddenLayers; i++)
						hLayers[i] = new HiddenLayer(hiddenSizes[i], hLayers[i-1]);
				}
				//
				oLayer = new OutputLayer(outSize, hLayers[numberOfHiddenLayers-1]);
				depth = numberOfHiddenLayers + 2;
			}
			catch(System.Exception ex)
			{
				Console.WriteLine(ex.Message);
				iLayer = null;
				hLayers = null;
				oLayer = null;
			}

		}
		//
		public Layer GetLayer(uint pos)
		{// was corrected 23/6/2003
			if(pos == 0)
				return this.iLayer;
			else if(pos == depth-1)
				return this.oLayer;
			else
				return this.hLayers[pos-1];
		}
		//
		public void Randomize(double minValue, double maxValue)
		{
			foreach(HiddenLayer h in hLayers)
				h.Randomize(minValue, maxValue);
			//
			oLayer.Randomize(minValue, maxValue);
		}
		//
		public void FeedForward()
		{
			for(uint i=0; i<depth; i++)
				this.GetLayer(i).FeedForward();
		}
		//
		public void BackPropagateError()
		{
			this.oLayer.BackPropagateError();
		}
		//
		public void SetInputVector(double[] input)
		{
			iLayer.SetInput(input);
		}
		//
		public void SetTargetVector(double[] target)
		{
			oLayer.SetTarget(target);
		}
		//
		public void CalculateOutputError()
		{
			this.oLayer.CalculateOutputErrors();
		}
		//
		public double GetInstantOutputError()
		{
			return this.oLayer.InstantSSE;
		}
		//
		public uint Depth
		{
			get{return this.depth;}
		}
		//
		public void WriteParameters()
		{
			for(uint i=1; i<Depth; i++)
			{
				HiddenLayer h = (HiddenLayer)this.GetLayer(i);
				h.WriteWeights();
			}
		}
		//
		public void Simulate(DataSet ds, string results)
		{
			string filename = results;
			//
			StreamWriter writer = new StreamWriter(filename, false);
			//
			try
			{
				//
				if(ds.GetLengthOfVectors() != iLayer.GetSize())
					throw new Exception("Input Vector Length differs from Input Layer's Size");
				//
				if(ds.GetDataValidation())
				{
					for(int i=0; i<ds.GetNumberOfVectors(); i++)
					{
						this.SetInputVector(ds.GetDataVector(i));
						this.FeedForward();
						//
						foreach(double d in this.oLayer.GetOutputVector())
						{
							writer.Write(d.ToString("F4")+" ");
						}
						//
						writer.Write("\n");
					}
				}
				else
				{
					writer.WriteLine("Invalid Simulation Data");
				}
				//
				writer.Flush();
				writer.Close();
			}
			catch(System.Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
			finally
			{
				writer.Close();
			}
		}
		//
		public void Simulate(string patterns, string results)
		{
			DataSet ds = new DataSet(patterns);
			//
			Simulate(ds, results);
		}
		//
		public void Simulate(DataSet patterns, DataSet targets, string results)
		{
			double  err = 0.0;
			double  sim = 0.0;
			//
			string filename = results;
			StreamWriter writer = new StreamWriter(filename, false);
			//
			try
			{
				if(patterns.GetLengthOfVectors() != iLayer.GetSize() || targets.GetLengthOfVectors() != oLayer.GetSize())
					throw new Exception("Input/Target Vectors Invalid with Input/Output Layer Size");
				//
				if(patterns.GetDataValidation() == true && targets.GetDataValidation() == true
					&& patterns.GetNumberOfVectors() == targets.GetNumberOfVectors())
				{
					for(int i=0; i<patterns.GetNumberOfVectors(); i++)
					{
						this.SetInputVector(patterns.GetDataVector(i));
						this.SetTargetVector(targets.GetDataVector(i));
						this.FeedForward();
						this.CalculateOutputError();
						err = this.GetInstantOutputError();
						sim += err;
						//
						foreach(double d in this.oLayer.GetOutputVector())
						{
							writer.Write(d.ToString("F6")+" ");
						}
						//
						writer.Write(err.ToString("E6"));
						writer.Write("\n");
					}
					//
					Console.WriteLine("Average Simulation Error: {0:E6}", sim/patterns.GetNumberOfVectors());
				}
				else
				{
					writer.WriteLine("Invalid Simulation Data");
					throw new Exception("Invalid Simulation Data");
				}
				//
				writer.Flush();
				writer.Close();	
			}
			catch(System.Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
			finally
			{
				writer.Close();
			}
		}
		//
		public double Simulate(DataSet patterns, DataSet targets)
		{
			double  err = 0.0;
			double  sim = 0.0;
			//
			try
			{
				if(patterns.GetLengthOfVectors() != iLayer.GetSize() || targets.GetLengthOfVectors() != oLayer.GetSize())
					throw new Exception("Input/Target Vectors Invalid with Input/Output Layer Size");
				//
				if(patterns.GetDataValidation() == true && targets.GetDataValidation() == true
					&& patterns.GetNumberOfVectors() == targets.GetNumberOfVectors())
				{
					for(int i=0; i<patterns.GetNumberOfVectors(); i++)
					{
						this.SetInputVector(patterns.GetDataVector(i));
						this.SetTargetVector(targets.GetDataVector(i));
						this.FeedForward();
						this.CalculateOutputError();
						err = this.GetInstantOutputError();
						sim += err;
					}
					//
				}
				else
				{
					throw new Exception("Invalid Simulation Data");
				}
				//
				return sim/patterns.GetNumberOfVectors();
			}
			catch(System.Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
		}
		//
		public void Simulate(string sPatterns, string sTargets, string results)
		{
			DataSet patterns = new DataSet(sPatterns);
			DataSet targets  = new DataSet(sTargets);
			//
			Simulate(patterns, targets, results);
		}
		//
		public static void BinarySave(string filename, BackPropNet network)
		{
			try
			{
				FileStream fs = new FileStream(filename, FileMode.Create);
				BinaryFormatter bf = new BinaryFormatter();
				//
				bf.Serialize(fs, network);
				fs.Flush();
				fs.Close();
			}
			catch(System.Exception e)
			{
				Console.WriteLine(e.Message);
				throw;
			}
		}
		//
		public static BackPropNet BinaryLoad(string filename)
		{
			BackPropNet net = null;
			FileStream fs = null;
			//
			try
			{
				fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
				BinaryFormatter bf = new BinaryFormatter();
				net = (BackPropNet)bf.Deserialize(fs);
				return net;
			}
			catch(System.Exception e)
			{
				Console.WriteLine(e.Message);
				throw;
			}
			finally
			{
				fs.Close();
			}	
		}
		//
		public override string ToString()
		{
			string s = null;
			//
			s += "Multi-Layer FeedForward Network"+"\n";
			s += "Number of Layers: "+this.Depth+"\n";
			s += "Input Layer Size: "+this.GetLayer(0).GetSize()+"\n";
			s += "Number of Hidden Layers: "+this.hLayers.Length+"\n";
			//
			for(uint i=0; i<hLayers.Length; i++)
				s += "Hidden Layer ID: "+(i+1).ToString()+" "+"Size: "+this.GetLayer(i+1).GetSize().ToString()+" "+"Activation Function: "+hLayers[i].GetActivationFunction().ToString()+"\n";
			//
			s += "OutputLayer Size: "+oLayer.GetSize()+" "+"Activation Function: "+oLayer.GetActivationFunction().ToString()+"\n";
			//
			return s;
		}
		//
		public string Weights()
		{
			string s = null;
			//
			for(uint i=0; i<this.Depth-2; i++)
			{
				s += "Hidden Layer: "+(i+1).ToString()+"\n";
				s += ((HiddenLayer)this.GetLayer(i+1)).ToString();
			}
			s += "\nOutput Layer: "+"\n";
			s += oLayer.ToString();
			//
			return s;
		}
		//
		public string GetStructure()
		{
			string s = null;
			//
			s += iLayer.GetSize().ToString()+"-";
			//
			for(int i=0; i<hLayers.Length; i++)
				s += hLayers[i].GetSize().ToString()+"-";
			//
			s += oLayer.GetSize().ToString();
			//
			return s;
		}
		//
		public double GetSumOfSquaredWeights()
		{
			double sum = 0.0;
			//
			foreach(HiddenLayer h in this.hLayers)
				sum += h.GetSumOfSquaredWeights();
			//
			sum += oLayer.GetSumOfSquaredWeights();
			return sum;
		}
		//
		public void SetOutputActivationFunction(ActivationFunction af)
		{
			oLayer.SetActivationFunction(af);
		}
		//
		public void SetHiddenActivationFunction(ActivationFunction af)
		{
			foreach(HiddenLayer h in this.hLayers)
				h.SetActivationFunction(af);
		}
	}
}
