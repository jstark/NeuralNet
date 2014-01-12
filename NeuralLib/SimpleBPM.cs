using System;

namespace NeuralLib
{
	/// <summary>
	/// Summary description for SimpleBPM.
	/// </summary>
	public class SimpleBPM : TrainingAlgorithm	//Validated at: 23/06/2003 with 0 momentum.
	{
		private double learnRate  = 0.25;
		private double momentum   = 0.00;
		//
		private double[][]  pBiasUpdates;
		private double[][,] pWeightUpdates;
		//
		public SimpleBPM(BackPropNet net, string patterns, string targets)
			:base(net, patterns, targets)
		{
			//
			try
			{
				// allocate memory for previous biases
				pBiasUpdates = new double[net.Depth-1][];
				//
				for(uint i=0; i<net.Depth-1; i++)
					pBiasUpdates[i] = new double[net.GetLayer(i+1).GetSize()];
				//
				// allocate memory for previous weights
				pWeightUpdates = (double[][,])this.errGrad.Clone(); // it should be tested
				//
			}
			catch(System.Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
		}
		//
		public SimpleBPM(BackPropNet net, string tPatterns, string tTargets, string vPatterns, string vTargets)
			: this(net, tPatterns, tTargets)
		{
			//
			this.SetValidationData(vPatterns, vTargets);
		}
		//
		public double Momentum
		{
			get{return this.momentum;}
			set{this.momentum = value;}
		}
		//
		public double LearnRate
		{
			get{return this.learnRate;}
			set{this.learnRate = value;}
		}
		//
		public void UpdateBiases()
		{
			double update = 0.0;
			//
			for(uint i=0; i<network.Depth-1; i++)
			{
				HiddenLayer h = (HiddenLayer)network.GetLayer(i+1);
				//
				for(uint j=0; j<h.GetSize(); j++)
				{
					update = -learnRate*h.GetDelta(j)+momentum*pBiasUpdates[i][j];
					//
					h.UpdateBias(j, update);
					pBiasUpdates[i][j] = update;
				}
			}
		}
		//
		public void UpdateWeights()
		{
			double update = 0.0;
			//
			for(uint i=0; i<network.Depth-1; i++)
			{
				HiddenLayer h = (HiddenLayer)network.GetLayer(i+1);
				//
				for(uint j=0; j<h.GetSize(); j++)
				{
					for(uint k=0; k<network.GetLayer(i).GetSize(); k++)
					{
						update = -learnRate*errGrad[i][k,j]+momentum*pWeightUpdates[i][k,j];
						//
						h.UpdateWeight(j, k, update);
						pWeightUpdates[i][k,j] = update;
					}
				}
			}
		}
		//
		public void TrainPair(int id)
		{
			double error = Double.MaxValue;
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
			this.UpdateBiases();
			this.UpdateWeights();
			//
		}
		//
		public override void TrainOnePeriod()
		{
			//
			for(int i=0; i<trPatterns.GetNumberOfVectors(); i++)
                TrainPair(i);
			//
			double err = 0;
			int    num = trPatterns.GetNumberOfVectors();
			for(int i=0; i<num; i++)
			{
				network.SetInputVector(trPatterns.GetDataVector(i));
				network.SetTargetVector(trTargets.GetDataVector(i));
				network.FeedForward();
				//
				network.CalculateOutputError();
				err += network.GetInstantOutputError();
			}
			this.tPerformance = err/num;
			//this.tPerformance = avError/trPatterns.GetNumberOfVectors();
		}
		//
		public void Train()
		{
			//
			uint fail = 0;
			double pvError = Double.MaxValue;
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
				Console.Write("\f\rEpoch: {2} \tTraining Error: {0:E7} \tValidation Error: {1:E6} \tFailures: {3}", tPerformance, vPerformance, i, fail);
				//
				if(tPerformance < this.MaxError)
					break;
				//
				if(vPerformance > pvError)
				{
					if(fail > this.maxFailures)
					{
						break;
					}
					else
					{
						fail++;
						pvError = vPerformance;
					}
				}
				else
				{
					pvError = vPerformance;
				}
			}
			//
			Console.WriteLine("\n\nTraining Time: {0}", DateTime.Now.Subtract(st));
		}

	}
}
