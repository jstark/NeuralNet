using System;

namespace NeuralLib
{
	/// <summary>
	/// Summary description for TrainAlgorithm.
	/// </summary>
	public abstract class TrainingAlgorithm
	{
		//
		protected BackPropNet	network;
		protected double[][,]	errGrad;
		protected DataSet		trPatterns;
		protected DataSet		trTargets;
		protected DataSet		vaPatterns;
		protected DataSet		vaTargets;
		protected bool			validate;
		protected bool			useWeightDecay;
		//
		protected double		tPerformance = Double.MaxValue;	// training performance = AMSE
		protected double		vPerformance = Double.MaxValue;	// validation performance
		//
		protected ulong		epochs			= 1000; 	// max number of epochs.
		protected double	allowableError	= 0.0;  	// minimum allowable training error.
		protected uint		maxFailures		= 5;		// max failures during validation.
		protected uint		vPeriod			= 5;		// validation period.
		protected double    decay			= 0.005;	// weight decay coefficient
		//
		//
		public TrainingAlgorithm(BackPropNet net, string tPatterns, string tTargets)
		{
			uint depth = net.Depth;
			//
			try
			{
				// allocate mem for matrices of error gradients
				errGrad = new double[depth-1][,]; // allocate mem for depth-1 vectors
				//
				for(uint i=0; i<depth-1; i++)
				{
					uint temp1 = net.GetLayer(i).GetSize();
					uint temp2 = net.GetLayer(i+1).GetSize();
					//
					errGrad[i] = new double[temp1, temp2];
				}
				//
				//
				this.trPatterns = new DataSet(tPatterns);
				this.trTargets  = new DataSet(tTargets);
				this.network    = net;
				//
				if(trPatterns.GetNumberOfVectors() != trTargets.GetNumberOfVectors())
					throw new Exception("Datasets have different number of vectors.");
				if(trPatterns.GetDataValidation() != true || trTargets.GetDataValidation() != true)
					throw new Exception("Invalid Data");
				if(trPatterns.GetLengthOfVectors() != net.GetLayer(0).GetSize() ||
					trTargets.GetLengthOfVectors() != net.GetLayer(net.Depth-1).GetSize())
					throw new Exception("Incosistent Data/Inputs or Data/Outputs");

			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
		}
		//
		public TrainingAlgorithm(BackPropNet net, string tPatterns, string tTargets, string vPatterns, string vTargets)
			: this(net, tPatterns, tTargets)
		{
			this.SetValidationData(vPatterns, vTargets);
		}
		//
		public double TrainingPerformance
		{
			get{return this.tPerformance;}
		}
		//
		public double ValidationPerformance
		{
			get{return this.vPerformance;}
		}
		//
		public double MaxError
		{
			get{return this.allowableError;}
			set{this.allowableError = value;}
		}
		//
		public ulong Epochs
		{
			get{return this.epochs;}
			set{this.epochs = value;}
		}
		//
		public uint MaxFailures
		{
			get{return this.maxFailures;}
			set{this.maxFailures = value;}
		}
		//
		public uint ValidationPeriod
		{
			get{return this.vPeriod;}
			set{this.vPeriod = value;}
		}
		//
		public bool WeightDecay
		{
			get{return this.useWeightDecay;}
			set{this.useWeightDecay = value;}
		}
		//
		public double Decay
		{
			get{return this.decay;}
			set{this.decay = value;}
		}
		//
		public void Validate()
		{
			//
			int numOfVectors = vaPatterns.GetNumberOfVectors();
			double sse = 0.0;
			//
			for(int i=0; i<numOfVectors; i++)
			{
				network.SetInputVector(vaPatterns.GetDataVector(i));
				network.SetTargetVector(vaTargets.GetDataVector(i));
				
				// feedforward signal
				network.FeedForward();
				
				// calculate output errors 
				network.CalculateOutputError();
				
				// get instant square error
				sse += network.GetInstantOutputError();
			}
			// vPerformance = (1/2N)*SUM(SUM(e^2))
			this.vPerformance = sse/numOfVectors;
		}
		//
		public void CalculateErrorGradients()
		{
			for(uint i=0; i<network.Depth-1; i++)
			{
				for(uint j=0; j<network.GetLayer(i).GetSize(); j++)
				{
					for(uint k=0; k<network.GetLayer(i+1).GetSize(); k++)
					{
						HiddenLayer h = (HiddenLayer)network.GetLayer(i+1);
						//
						errGrad[i][j,k] = network.GetLayer(i).GetOutput((int)j) * h.GetDelta(k);
					}
				}
			}
		}
		//
		public void SetValidationData(string vPatterns, string vTargets)
		{
			try
			{
				this.vaPatterns = new DataSet(vPatterns);
				this.vaTargets  = new DataSet(vTargets);
				//
				if(vaPatterns.GetNumberOfVectors() != vaTargets.GetNumberOfVectors())
					throw new Exception("Datasets have different number of vectors.");
				if(vaPatterns.GetDataValidation() != true || vaTargets.GetDataValidation() != true)
					throw new Exception("Invalid Data");
				if(vaPatterns.GetLengthOfVectors() != network.GetLayer(0).GetSize() ||
					vaTargets.GetLengthOfVectors() != network.GetLayer(network.Depth-1).GetSize())
					throw new Exception("Incosistent Data/Inputs or Data/Outputs");
				this.validate = true;
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				this.validate = false;
				throw;
			}
		}
		//
		public abstract void TrainOnePeriod();
		//
	}
}
