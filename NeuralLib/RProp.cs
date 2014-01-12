using System;

namespace NeuralLib
{
	/// <summary>
	/// Summary description for RProp.
	/// </summary>
	public class RProp : TrainingAlgorithm
	{
		private double[][]	oldTotalDelta;
		//
		private double[][]	totalDelta;
		//
		private double[][,] oldTotalErrGrad;
		//
		private double[][,] totalErrGrad;
		//
		private double[][]  biasLearnRates;
		//
		private double[][,] weightLearnRates;
		//
		private const double maxLearnRate	= 50.00;
		private const double minLearnRate	= 0.00000001;
		private const double hPlus			= 1.2;
		private const double hMinus			= 0.5;
		//
		public RProp(BackPropNet net, string patterns, string targets)
		:base(net, patterns, targets)
		{
			try
			{
				// allocate mem for oldTotalDelta
				oldTotalDelta	= new double[net.Depth-1][];
				totalDelta		= new double[net.Depth-1][];
				biasLearnRates	= new double[net.Depth-1][];
				oldTotalErrGrad = new double[net.Depth-1][,];
				totalErrGrad    = new double[net.Depth-1][,];
				weightLearnRates  = new double[net.Depth-1][,];

				//
				for(uint i=0; i< net.Depth-1; i++)
				{
					oldTotalDelta[i] = new double[net.GetLayer(i+1).GetSize()];
					totalDelta[i]    = new double[net.GetLayer(i+1).GetSize()];
					biasLearnRates[i] = new double[net.GetLayer(i+1).GetSize()];
					oldTotalErrGrad[i] = new double[errGrad[i].GetLength(0), errGrad[i].GetLength(1)];
					totalErrGrad[i] = new double[errGrad[i].GetLength(0), errGrad[i].GetLength(1)];
					weightLearnRates[i]= new double[errGrad[i].GetLength(0), errGrad[i].GetLength(1)];
				}
				//
				// initialize all learning rates to 0.1
				//
				InitializeLearnRates();
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
		}
		//
		public RProp(BackPropNet net, string tPatterns, string tTargets, string vPatterns, string vTargets)
			: this(net, tPatterns, tTargets)
		{
			this.SetValidationData(vPatterns, vTargets);

		}
		//
		private void InitializeLearnRates()
		{
			// set bias learn rates
			for(int i=0; i < biasLearnRates.Length; i++)
			{
				for(int j=0; j < biasLearnRates[i].Length; j++)
				{
					biasLearnRates[i][j] = 0.1;
				}
			}
			//
			//
			// set weight learn rates
			for(int i=0; i<weightLearnRates.Length; i++)
			{
				for(int j=0; j<weightLearnRates[i].GetLength(0); j++)
				{
					for(int k=0; k < weightLearnRates[i].GetLength(1); k++)
					{
						weightLearnRates[i][j,k] = 0.1;
					}
				}
			}
		}
		//
		public void UpdateTotalDelta()
		{
			for(uint i=0; i<network.Depth-1; i++)
			{
				double delta = 0.0;
				HiddenLayer h = (HiddenLayer)network.GetLayer(i+1);
				//
				for(uint j=0; j<h.GetSize(); j++)
				{
					delta = h.GetDelta(j);
					totalDelta[i][j] += delta;
				}
			}
		}
		//
		public void UpdateTotalErrorGradient()
		{
			for(uint i=0; i<errGrad.Length; i++)
			{
				for(uint j=0; j<errGrad[i].GetLength(0); j++)
				{
					for(uint k=0; k<errGrad[i].GetLength(1); k++)
					{
						totalErrGrad[i][j,k] += errGrad[i][j,k];
					}
				}
			}
		}
		//
		public void UpdateBiases()
		{
			for(uint i=0; i<network.Depth-1; i++)
			{
				HiddenLayer h = (HiddenLayer)network.GetLayer(i+1);
				//
				for(uint j=0; j<h.GetSize(); j++)
				{
					double update = 0.0;
					//
					if(totalDelta[i][j]*oldTotalDelta[i][j] > 0)
					{
						biasLearnRates[i][j] = System.Math.Min(biasLearnRates[i][j]*RProp.hPlus, RProp.maxLearnRate);
						update = -System.Math.Sign(totalDelta[i][j])*biasLearnRates[i][j];
						oldTotalDelta[i][j] = totalDelta[i][j];
					}
					else if(totalDelta[i][j]*oldTotalDelta[i][j] < 0)
					{
						biasLearnRates[i][j] = System.Math.Max(biasLearnRates[i][j]*RProp.hMinus, RProp.minLearnRate);
						oldTotalDelta[i][j] = 0;
						update = 0;
					}
					else
					{
						update = -System.Math.Sign(totalDelta[i][j])*biasLearnRates[i][j];
						oldTotalDelta[i][j] = totalDelta[i][j];
					}
					//
					if(WeightDecay == true)
						update -= decay*h.GetBias(j);
					//
					h.UpdateBias(j, update);
				}
			}
		}
		//
		public void UpdateWeights()
		{
			for(uint i=0; i<network.Depth-1; i++)
			{
				HiddenLayer h = (HiddenLayer)network.GetLayer(i+1);
				//
				for(uint j=0; j<network.GetLayer(i).GetSize(); j++)
				{
					for(uint k=0; k<h.GetSize(); k++)
					{
						double update = 0.0;
						if(totalErrGrad[i][j,k]*oldTotalErrGrad[i][j,k] > 0)
						{
							weightLearnRates[i][j,k] = System.Math.Min(weightLearnRates[i][j,k]*RProp.hPlus, RProp.maxLearnRate);
							update = -System.Math.Sign(totalErrGrad[i][j,k])*weightLearnRates[i][j,k];
							oldTotalErrGrad[i][j,k] = totalErrGrad[i][j,k];
						}
						else if(totalErrGrad[i][j,k]*oldTotalErrGrad[i][j,k] < 0)
						{
							update = 0.0;
							weightLearnRates[i][j,k] = System.Math.Max(weightLearnRates[i][j,k]*RProp.hMinus, RProp.minLearnRate);
							oldTotalErrGrad[i][j,k] = 0;
						}
						else
						{
							update = -System.Math.Sign(totalErrGrad[i][j,k])*weightLearnRates[i][j,k];
							oldTotalErrGrad[i][j,k] = totalErrGrad[i][j,k];
						}
						//
						if(WeightDecay == true)
						{
							update -= decay*h.GetWeight(k,j);
						}
						//
						h.UpdateWeight(k, j, update);
					}
				}
			}
		}
		//
		public double TrainPair(int id)
		{
			double error = 0.0;
			//
			network.SetInputVector(trPatterns.GetDataVector(id));
			network.SetTargetVector(trTargets.GetDataVector(id));
			//
			network.FeedForward();
			network.CalculateOutputError();
			error = network.GetInstantOutputError();
			//
			network.BackPropagateError();
			this.CalculateErrorGradients();
			this.UpdateTotalDelta();
			this.UpdateTotalErrorGradient();
			return error;
		}
		//
		public override void TrainOnePeriod()
		{
			double sse = 0.0;
			int numOfVectors = trPatterns.GetNumberOfVectors();
			//
			for(int i=0; i<numOfVectors; i++)
			{
				sse += TrainPair(i);
			}
			//
			this.UpdateBiases();
			this.UpdateWeights();
			NMath.SetToZero(totalDelta);
			NMath.SetToZero(totalErrGrad);
			//
			this.tPerformance = sse/numOfVectors;
			//
			if(WeightDecay == true)
				this.tPerformance += decay*network.GetSumOfSquaredWeights()/numOfVectors;
		}
		//
		public void Train()
		{
			//
			uint fail = 0;
			double vError = Double.MaxValue;
			//
			DateTime st = DateTime.Now;
			for(uint i=0; i<this.epochs; i++)
			{
				TrainOnePeriod();
				//
				if(i%this.vPeriod == 0 && validate == true)
				{
					Validate();
				}
				//
				Console.Write("\r\fEpoch: {2} \tTraining Error: {0:E7} \tValidation Error: {1:E7}", tPerformance, vError, i);
				//
				if(tPerformance < this.MaxError)
					break;
				//
				if(vPerformance > vError)
				{
					if(fail > this.maxFailures)
					{
						break;
					}
					else
					{
						fail++;
						vError = vPerformance;
					}
				}
				else
				{
					vError = vPerformance;
				}
			}
			//
			Console.WriteLine("\n\nTraining Time: {0}", DateTime.Now.Subtract(st));
		}
	}
}
