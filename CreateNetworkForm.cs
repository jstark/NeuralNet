using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using NeuralLib;

namespace NetworkPreprocessor
{
	/// <summary>
	/// Summary description for CreateNetworkForm.
	/// </summary>
	public class CreateNetworkForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cb1;
		private System.Windows.Forms.ComboBox cb2;
		private System.Windows.Forms.TextBox tb1;
		private System.Windows.Forms.TextBox tb2;
		private System.Windows.Forms.TextBox tb3;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CreateNetworkForm()
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
				if(components != null)
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tb1 = new System.Windows.Forms.TextBox();
			this.tb2 = new System.Windows.Forms.TextBox();
			this.tb3 = new System.Windows.Forms.TextBox();
			this.cb1 = new System.Windows.Forms.ComboBox();
			this.cb2 = new System.Windows.Forms.ComboBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Input:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.label2.Location = new System.Drawing.Point(16, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 24);
			this.label2.TabIndex = 1;
			this.label2.Text = "Hidden:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.label3.Location = new System.Drawing.Point(16, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 24);
			this.label3.TabIndex = 2;
			this.label3.Text = "Output:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tb1
			// 
			this.tb1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.tb1.Location = new System.Drawing.Point(96, 24);
			this.tb1.Name = "tb1";
			this.tb1.Size = new System.Drawing.Size(72, 22);
			this.tb1.TabIndex = 3;
			this.tb1.Text = "2";
			this.tb1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tb2
			// 
			this.tb2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.tb2.Location = new System.Drawing.Point(96, 56);
			this.tb2.Name = "tb2";
			this.tb2.Size = new System.Drawing.Size(72, 22);
			this.tb2.TabIndex = 4;
			this.tb2.Text = "2";
			this.tb2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tb3
			// 
			this.tb3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.tb3.Location = new System.Drawing.Point(96, 88);
			this.tb3.Name = "tb3";
			this.tb3.Size = new System.Drawing.Size(72, 22);
			this.tb3.TabIndex = 5;
			this.tb3.Text = "1";
			this.tb3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// cb1
			// 
			this.cb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.cb1.Items.AddRange(new object[] {
													 "TanSig",
													 "LogSig"});
			this.cb1.Location = new System.Drawing.Point(176, 56);
			this.cb1.Name = "cb1";
			this.cb1.Size = new System.Drawing.Size(96, 24);
			this.cb1.TabIndex = 6;
			// 
			// cb2
			// 
			this.cb2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.cb2.Items.AddRange(new object[] {
													 "TanSig",
													 "LogSig",
													 "Linear"});
			this.cb2.Location = new System.Drawing.Point(176, 88);
			this.cb2.Name = "cb2";
			this.cb2.Size = new System.Drawing.Size(96, 24);
			this.cb2.TabIndex = 7;
			// 
			// comboBox1
			// 
			this.comboBox1.Enabled = false;
			this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.comboBox1.Items.AddRange(new object[] {
														   "TanSig",
														   "LogSig"});
			this.comboBox1.Location = new System.Drawing.Point(176, 24);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(96, 24);
			this.comboBox1.TabIndex = 8;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.cb1,
																					this.cb2,
																					this.tb1,
																					this.tb2,
																					this.label2,
																					this.tb3,
																					this.label3,
																					this.comboBox1,
																					this.label1});
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(280, 120);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Layers / Activation Functions";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.button1.Location = new System.Drawing.Point(296, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(130, 32);
			this.button1.TabIndex = 10;
			this.button1.Text = "Create";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.button2.Location = new System.Drawing.Point(296, 56);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(130, 32);
			this.button2.TabIndex = 11;
			this.button2.Text = "Cancel";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Enabled = false;
			this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.button3.Location = new System.Drawing.Point(296, 96);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(130, 32);
			this.button3.TabIndex = 12;
			this.button3.Text = "OK";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// CreateNetworkForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(432, 134);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button3,
																		  this.button2,
																		  this.button1,
																		  this.groupBox1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "CreateNetworkForm";
			this.Text = "Create New Network Structure";
			this.Load += new System.EventHandler(this.CreateNetworkForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void CreateNetworkForm_Load(object sender, System.EventArgs e)
		{
			tb1.Text = "2";
			tb2.Text = "2";
			tb3.Text = "1";
			//
			cb1.SelectedItem = cb1.Items[0];
			cb2.SelectedItem = cb2.Items[1];
			//
			this.button3.Enabled = false;
			//
			this.Top = this.Owner.Top+this.Owner.Height+5;
			this.Left = this.Owner.Left;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				// get input neurons
				uint inp = Convert.ToUInt32(tb1.Text.Trim());
				if(inp < 1)
					throw new Exception("Invalid Number of Neurons");
				// get output neurons;
				uint outp= Convert.ToUInt32(tb3.Text.Trim());
				if(outp < 1)
					throw new Exception("Invalid Number of Neurons");
				// get hidden neurons;
				uint[] hid = null;
				//
				Regex r = new Regex(@"\s+");
				string[] hidden = r.Split(tb2.Text.Trim());
				hid = new uint[hidden.Length];
				//
				for(int i=0; i<hid.Length; i++)
				{
					hid[i] = Convert.ToUInt32(hidden[i]);
					//
					if(hid[i] < 1)
						throw new Exception("Invalid Number of Neurons");
				}			
				// create network
				Form1.Network = new BackPropNet(inp, outp, hid);

				// check activation functions in hidden layers
				if((string)cb1.SelectedItem != "LogSig")
				{
					for(uint i=0; i<hid.Length; i++)
					{
						HiddenLayer h = (HiddenLayer)Form1.Network.GetLayer(i+1);
						h.SetActivationFunction(NeuralLib.ActivationFunction.TanSig);
					}
				}
				//
				// check activation function in output layers
				if((string)cb2.SelectedItem != "LogSig")
				{
					HiddenLayer h = (HiddenLayer)Form1.Network.GetLayer((uint)(hid.Length+1));
					if((string)cb2.SelectedItem == "TanSig")
					{
						h.SetActivationFunction(NeuralLib.ActivationFunction.TanSig);
					}
					else
					{
						h.SetActivationFunction(NeuralLib.ActivationFunction.Linear);
					}
				}
				//
				this.button3.Enabled = true;
			}
			catch(System.Exception ex)
			{
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Form1.Network = null;
				this.button3.Enabled = false;
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Hide();
			this.DialogResult = DialogResult.Cancel;
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			this.Hide();
			this.DialogResult = DialogResult.OK;
		}
	}
}
