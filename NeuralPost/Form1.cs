using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using NeuralLib;
using SoftwareFX.ChartFX.Lite;

namespace NNSim
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.OpenFileDialog of;
		
		//
		private BackPropNet network  = null;
		private NeuralLib.DataSet	patterns = null;
		private System.Windows.Forms.SaveFileDialog sf;
		private SoftwareFX.ChartFX.Lite.Chart chart1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RichTextBox rtb1;
		private System.Windows.Forms.Label label1;
		private NeuralLib.DataSet	targets  = null;
		//
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.of = new System.Windows.Forms.OpenFileDialog();
			this.sf = new System.Windows.Forms.SaveFileDialog();
			this.chart1 = new SoftwareFX.ChartFX.Lite.Chart();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.rtb1 = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("MS Reference Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.button2.Location = new System.Drawing.Point(8, 24);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(96, 32);
			this.button2.TabIndex = 2;
			this.button2.Text = "Network";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.button4,
																					this.button3,
																					this.button2});
			this.groupBox1.Font = new System.Drawing.Font("MS Reference Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(120, 144);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Load...";
			// 
			// button4
			// 
			this.button4.Enabled = false;
			this.button4.Font = new System.Drawing.Font("MS Reference Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.button4.Location = new System.Drawing.Point(8, 104);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(96, 32);
			this.button4.TabIndex = 4;
			this.button4.Text = "Targets";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Font = new System.Drawing.Font("MS Reference Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.button3.Location = new System.Drawing.Point(8, 64);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(96, 32);
			this.button3.TabIndex = 3;
			this.button3.Text = "Patterns";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button5
			// 
			this.button5.Enabled = false;
			this.button5.Font = new System.Drawing.Font("MS Reference Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.button5.Location = new System.Drawing.Point(8, 24);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(96, 32);
			this.button5.TabIndex = 5;
			this.button5.Text = "Simulate";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// sf
			// 
			this.sf.AddExtension = false;
			this.sf.CreatePrompt = true;
			this.sf.Title = "Save Results To File:";
			// 
			// chart1
			// 
			this.chart1.AxisY.Title.Text = "Square Error";
			this.chart1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.chart1.Gallery = SoftwareFX.ChartFX.Lite.Gallery.Lines;
			this.chart1.Location = new System.Drawing.Point(136, 8);
			this.chart1.MarkerShape = SoftwareFX.ChartFX.Lite.MarkerShape.None;
			this.chart1.Name = "chart1";
			this.chart1.NSeries = 1;
			this.chart1.Size = new System.Drawing.Size(672, 408);
			this.chart1.TabIndex = 4;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.button5});
			this.groupBox2.Location = new System.Drawing.Point(8, 160);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(120, 64);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Action";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("MS Reference Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.button1.Location = new System.Drawing.Point(16, 384);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 32);
			this.button1.TabIndex = 7;
			this.button1.Text = "Exit";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// rtb1
			// 
			this.rtb1.BackColor = System.Drawing.SystemColors.WindowText;
			this.rtb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.rtb1.Font = new System.Drawing.Font("MS Reference Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.rtb1.ForeColor = System.Drawing.SystemColors.Info;
			this.rtb1.Location = new System.Drawing.Point(8, 232);
			this.rtb1.Name = "rtb1";
			this.rtb1.Size = new System.Drawing.Size(120, 144);
			this.rtb1.TabIndex = 8;
			this.rtb1.Text = "";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.label1.Location = new System.Drawing.Point(368, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(163, 17);
			this.label1.TabIndex = 9;
			this.label1.Text = "Test Performance:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
			this.ClientSize = new System.Drawing.Size(816, 422);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1,
																		  this.rtb1,
																		  this.groupBox2,
																		  this.chart1,
																		  this.groupBox1,
																		  this.button1});
			this.Font = new System.Drawing.Font("MS Reference Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Neural PostProcessor";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{

		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(of.ShowDialog() == DialogResult.OK && of.FileName != "")
				{
					network = BackPropNet.BinaryLoad(of.FileName);
					rtb1.Text = "Network: "+network.GetStructure();
				}
				patterns = null;
				targets = null;
			}
			catch(System.Exception ex)
			{
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
				network = null;
			}
			//
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(of.ShowDialog() == DialogResult.OK && of.FileName != "")
				{
					patterns = new NeuralLib.DataSet(of.FileName);
					rtb1.Text = "\nPatterns: "+patterns.GetNumberOfVectors().ToString()+"x"+patterns.GetLengthOfVectors().ToString();
				}
				//
				button4.Enabled = true;
				button5.Enabled = true;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
				patterns = null;
			}

			//
		}
		//
		private void button4_Click(object sender, System.EventArgs e)
		{
			try
			{

				if(of.ShowDialog() == DialogResult.OK && of.FileName != "")
				{
					targets = new NeuralLib.DataSet(of.FileName);
					rtb1.Text = "\nTargets: "+targets.GetNumberOfVectors().ToString()+"x"+targets.GetLengthOfVectors().ToString();
				}
			}
			catch(System.Exception ex)
			{
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
				targets = null;
			}
		}
		//
		private void button5_Click(object sender, System.EventArgs e)
		{
			string filename = null;
			//
			if(sf.ShowDialog() == DialogResult.OK && of.FileName != " ")
			{
				filename = sf.FileName;
				//
				try
				{

					if(patterns != null)
					{
						if(targets != null)
							network.Simulate(patterns, targets, filename);
						else
							network.Simulate(patterns, filename);
					}
					//
					MessageBox.Show("Simulation Finished", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				catch(System.Exception ex)
				{
					MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
					patterns = null;
					patterns = null;
					network  = null;
					this.button3.Enabled = false;
					this.button4.Enabled = false;
					this.button5.Enabled = false;
				}
			}
			//
			if(targets != null)
			{
				NeuralLib.DataSet dset = new NeuralLib.DataSet(filename);
				//
				double[] dummy;
				//
				chart1.Series.Clear();	
				chart1.OpenData(COD.Values, 0, dset.GetNumberOfVectors());
				if(network.GetLayer(network.Depth-1).GetSize() == 1)
				{
					// network has one output neuron.
					chart1.AxisY.Title.Text = "Real Output-Simulated Output";
					double sse = 0.0;
					for(int i=0; i<dset.GetNumberOfVectors(); i++)
					{
						dummy = dset.GetDataVector(i);
						chart1.Value[0, i] = targets.GetDataVector(i)[0];
						chart1.Value[1, i] = dummy[0];
						sse += dummy[dummy.Length-1];
					}
					//
					label1.Text = "SSE: "+sse.ToString("F6")+" MSE: "+(sse/dset.GetNumberOfVectors()).ToString("F6")+" RMSE: "+
						Math.Sqrt(sse/dset.GetNumberOfVectors()).ToString("F6");
				}
				else
				{
					chart1.AxisY.Title.Text = "RMSE";
					double sse = 0.0;
					for(int i=0; i<dset.GetNumberOfVectors(); i++)
					{
						dummy = dset.GetDataVector(i);
						chart1.Value[0, i] = Math.Sqrt(dummy[dummy.Length-1]);
						sse += dummy[dummy.Length-1];
					}
					label1.Text = "SSE: "+sse.ToString("F6")+" MSE: "+(sse/dset.GetNumberOfVectors()).ToString("F6")+" RMSE: "+
						Math.Sqrt(sse/dset.GetNumberOfVectors()).ToString("F6");
				}
				//
				label1.Left = chart1.Left+chart1.Width/2-label1.Width/2;
				chart1.CloseData(COD.Values);
				chart1.RecalcScale();
				chart1.Refresh();
			}
					
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}
	}
}
