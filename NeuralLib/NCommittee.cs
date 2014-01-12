using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NeuralLib
{
	/// <summary>
	/// Summary description for NCommittee.
	/// </summary>
	/// 
	[Serializable]
	public class NCommittee
	{
		private BackPropNet[]	networks;
		[NonSerialized]
		private DataSet			patterns;
		[NonSerialized]
		private DataSet			targets;
		private double[,]		errors;
		private double[]		alpha;
		private double[]		outputs;
		private double			performance;
		//
		public NCommittee(DataSet pat, DataSet tar, params string[] netFiles)
		{
			try
			{
				networks = new BackPropNet[netFiles.Length];
				//
				for(int i=0; i<netFiles.Length; i++)
					networks[i] = BackPropNet.BinaryLoad(netFiles[i]);
				//
				this.SetData(pat, tar);
				this.CheckNetworks();
				//
				// allocate memory
				alpha = new double[networks.Length];
				outputs = new Double[patterns.GetNumberOfVectors()];
				errors = new double[networks.Length, patterns.GetNumberOfVectors()];
			}
			catch(System.Exception e)
			{
				Console.WriteLine(e.Message);
				networks = null;
				patterns = null;
				targets  = null;
				errors   = null;
				alpha    = null;
				throw;
			}
		}
		//
		public double Performance
		{
			get{return performance;}
		}
		//
		private void CheckNetworks()
		{
			// check if all networks have appropriate inputs-output sizes:
			for(int i=0; i<networks.Length; i++)
			{
				uint outpLayerID = networks[i].Depth-1;
				//
				if(networks[i].GetLayer(0).GetSize() != patterns.GetLengthOfVectors())
					throw new Exception("Bad Input Size");
				if(networks[i].GetLayer(outpLayerID).GetSize() != targets.GetLengthOfVectors())
					throw new Exception("Bad Output Size");
			}
		}
		//
		private void CalcErrors()
		{
			//
			int numOfPairs = patterns.GetNumberOfVectors();
			//
			for(int i=0; i<networks.Length; i++)
			{
				for(int j=0; j<numOfPairs; j++)
				{
					networks[i].SetInputVector(patterns.GetDataVector(j));
					networks[i].SetTargetVector(targets.GetDataVector(j));
					//
					networks[i].FeedForward();
					networks[i].CalculateOutputError();
					//
					this.errors[i,j] = networks[i].GetLayer(networks[i].Depth-1).GetOutput(0)-targets.GetDataVector(j)[0];
				}
			}
		}
		//
		private double[,] Calculate_CMatrix()
		{
			try
			{
				int L = errors.GetLength(0);
				double sum;
				//
				double[,] C = new double[L,L];

				//
				for(int i=0; i<L; i++)
				{
					for(int j=0; j<L; j++)
					{
						sum = 0.0;
						//
						for(int k=0; k<patterns.GetNumberOfVectors(); k++)
						{
							sum += errors[i,k]*errors[j,k];
						}
						//
						C[i,j] = sum/patterns.GetNumberOfVectors();
					}
				}
				//
				return C;
			}
			catch(System.Exception e)
			{
				Console.WriteLine(e.Message);
				throw;
			}
			//
		}
		//
		public void CalcAlpha()
		{
			CalcErrors();
			double[,]  C = Calculate_CMatrix();
			NMath.PrintMatrix(C);
			double[,] iC = NMath.InverseMatrix(C);
			NMath.PrintMatrix(iC);
			double sum = 0.0;
			//
			for(int i=0; i<iC.GetLength(0); i++)
				for(int j=0; j<iC.GetLength(0); j++)	// GetLength(0) = GetLength(1)
					sum += iC[i,j];
			//
			performance = 1.0/sum;
			Console.WriteLine("Estimated Performance: "+performance);
			//
			double dummy;
			for(int i=0; i<alpha.Length; i++)
			{
				dummy = 0.0;
				//
				for(int j=0; j<iC.GetLength(0); j++)
					dummy += iC[i,j];
				//
				alpha[i] = dummy/sum;
			}
		}
		//
		public void Simulate(string filename)
		{
			//
			this.outputs = new Double[targets.GetNumberOfVectors()];
			double[] err = new Double[patterns.GetNumberOfVectors()];
			double yOut;
			//
			for(int i=0; i<patterns.GetNumberOfVectors(); i++)
			{
				yOut = 0;
				uint id;
				//
				for(int j=0; j<networks.Length; j++)
				{
					id = networks[j].Depth-1;
					networks[j].SetInputVector(patterns.GetDataVector(i));
					networks[j].SetTargetVector(targets.GetDataVector(i));
					//
					networks[j].FeedForward();
					//
					yOut += alpha[j]*networks[j].GetLayer(id).GetOutputVector()[0];
				}
				//
				outputs[i] = yOut;
				err[i] = yOut-targets.GetDataVector(i)[0];
			}
			//
			System.IO.StreamWriter writer = new System.IO.StreamWriter(filename);
			//
			for(int i=0; i<outputs.Length; i++)
			{
				writer.WriteLine(outputs[i].ToString("F5")+"\t"+err[i].ToString("F5"));
			}
			writer.Flush();
			writer.Close();
		}
		//
		public static void BinarySave(NCommittee comm, string filename)
		{
			try
			{
				FileStream fs = new FileStream(filename, FileMode.Create);
				BinaryFormatter bf = new BinaryFormatter();
				//
				bf.Serialize(fs, comm);
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
		public static NCommittee BinaryLoad(string filename)
		{
			NCommittee n_comm = null;
			FileStream fs = null;
			//
			try
			{
				fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
				BinaryFormatter bf = new BinaryFormatter();
				n_comm = (NCommittee)bf.Deserialize(fs);
				return n_comm;
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
		public void SetData(NeuralLib.DataSet pat, NeuralLib.DataSet tar)
		{
			patterns = pat;
			targets  = tar;
			//
			if(patterns.GetDataValidation() != true || targets.GetDataValidation() != true
				|| patterns.GetNumberOfVectors() != targets.GetNumberOfVectors())
				throw new Exception("Bad Patterns/Targets or vectors differ in length");
			//
			this.CheckNetworks();
		}
		//
		public string AlphaToString()
		{
			string s = null;
			double sum = 0;
			for(int i=0; i< alpha.Length; i++)
			{
				sum += alpha[i];
				s += alpha[i].ToString("E5")+"\n";
			}
			//
			s += "\n\nSUM: "+sum.ToString("F4");
			return s;
		}
		//
		public override string ToString()
		{
			string s =null;
			//
			for(int i=0; i<networks.Length; i++)
				s += networks[i].GetStructure()+"\n";
			//
			return s;
		}
		//
		public double[] GetVectorOfOutputs()
		{
			return this.outputs;
		}
	}
}
