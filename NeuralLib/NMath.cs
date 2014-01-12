using System;

namespace NeuralLib
{
	/// <summary>
	/// Summary description for NMath.
	/// </summary>
	public class NMath
	{
		private NMath()
		{}
		//
		public static double LogSig(double x)
		{
			return 1.0/(1.0+Math.Exp(-x));
		}
		//
		public static double DLogSig(double fx)
		{
			return fx*(1.0-fx);
		}
		//
		public static double Linear(double arg)
		{
			return arg;
		}
		//
		public static double DLinear(double fx)
		{
			return 1.0;
		}
		//
		public static double TanSig(double x)
		{
			const double a = 1.7159;
			const double b = 2.0/3.0;
			//
			return a*Math.Tanh(b*x);
		}
		//
		public static double DTanSig(double fx)
		{
			const double a = 1.7159;
			const double b = 2.0/3.0;
			//
			return (b/a)*(a-fx)*(a+fx);
		}
		//
		public static double Sum(double[] vector)
		{
			double sum = 0.0;
			//
			foreach(double d in vector)
				sum += d;
			//
			return sum;
		}
		//
		public static double SSE(double[] vector)
		{
			double sum = 0.0;
			//
			foreach(double d in vector)
				sum += d*d;
			//
			return sum;
		}
		//
		public static void SetToZero(double[] vector)
		{
			for(int i=0; i<vector.Length; i++)
				vector[i] = 0;
		}
		//
		public static void SetToZero(double[][] vv)
		{
			foreach(double[] v in vv)
				SetToZero(v);
		}
		//
		public static void SetToZero(double[,] matrix)
		{
			for(int i=0; i<matrix.GetLength(0); i++)
			{
				for(int j=0; j<matrix.GetLength(1); j++)
				{
					matrix[i,j] = 0;
				}
			}
		}
		//
		public static void SetToZero(double[][,] vm)
		{
			foreach(double[,] m in vm)
				SetToZero(m);
		}
		//
		public static void PrintMatrix(double[,] matrix)
		{
			for(int i=0; i<matrix.GetLength(0); i++)
			{
				for(int j=0; j<matrix.GetLength(1); j++)
				{
					Console.Write(matrix[i,j].ToString("F10")+" ");
				}
				Console.Write("\n");
			}
		}
		//
		public static void PrintVector(double[] vector)
		{
			Console.WriteLine("\n");
			for(int i=0; i<vector.Length; i++)
				Console.Write(vector[i].ToString("F10")+" ");
			Console.Write("\n");
		}
		//
		public static void PrintVectorOfVectors(double[][] vv)
		{
			Console.WriteLine("\t");
			foreach(double[] v in vv)
				PrintVector(v);
		}
		//
		public static void PrintVectorOfMatrices(double[][,] vm)
		{
			Console.WriteLine("\t");
			foreach(double[,] m in vm)
			{
				PrintMatrix(m);
				Console.WriteLine("*");
			}
		}
		//
		public static double[,] InverseMatrix(double[,] matrix)
		{
			// works ok but changes matrix
			try
			{
				if(matrix.GetLength(0) != matrix.GetLength(1))
					throw new Exception("Matrix not Square");
				//
				int N = matrix.GetLength(0);
				double[,] inv = new double[N,N];
				//
				for(int i=0; i<N; i++)
					inv[i,i] = 1;
				//
				double D1 = 1;
				double D2;
				//
				for(int i=0; i<N; i++)
				{
					D2 = matrix[i,i];
					D1 = D1*D2;
					//
					for(int j=0; j<N; j++)
					{
						matrix[i,j] = matrix[i,j]/D2;
						inv[i,j] = inv[i,j]/D2;
					}
					//
					for(int j=0; j<N; j++)
					{
						if(i == j)
							continue;
						else
						{
							D1 = matrix[j,i];
							for(int k=0; k<N; k++)
							{
								matrix[j,k] -= D1*matrix[i,k];
								inv[j,k] -= D1*inv[i,k];
							}
						}
					}
				}
				//
				return inv;
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
				throw;
			}
		}
		//
	}
}
