// created on 6/12/2003 at 9:27 AM
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace NeuralLib
{
	public class DataSet
	{
		private readonly double[][] data = null;
		private bool isValid = false;
		private TimeSpan time;
		//
		public DataSet(string filename)
		{
			try
			{
				DateTime tStart = DateTime.Now;
				StreamReader reader = new StreamReader(filename);
				Regex r = new Regex(@"\s+");
				int rows = 0;
				while(reader.Peek() > -1)
				{
					reader.ReadLine();
					rows++;
				}
				//
				data = new double[rows][];
				reader.Close();
				reader = new StreamReader(filename);
				//
				int ctr = 0;
				while(reader.Peek() > -1)
				{
					string[] s = r.Split(reader.ReadLine().Trim());
					data[ctr] = new double[s.Length];
					//
					for(int i=0; i<s.Length; i++)
						data[ctr][i] = Convert.ToDouble(s[i]);
					ctr++;
				}
				//
				reader.Close();
				this.Validate();
				DateTime tFinish = DateTime.Now;
				time = tFinish-tStart;
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
		
		}
		//
		private void Validate()
		{
			isValid = true;
			foreach(double[] vector in data)
			{
				if(vector.Length != data[0].Length)
					isValid = false;
			}
		}
		//
		public bool GetDataValidation()
		{
			return isValid;
		}
		//
		public int GetNumberOfVectors()
		{
			return data.Length;
		}
		//
		public int GetLengthOfVectors()
		{
			if(isValid)
				return data[0].Length;
			else
				return Int32.MinValue;
		}
		//
		public TimeSpan GetTimeSpan()
		{
			return time;
		}
		//
		public double[] GetDataVector(int num)
		{
			return data[num];
		}
	}
}