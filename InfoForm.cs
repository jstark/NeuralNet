using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

namespace NetworkPreprocessor
{
	/// <summary>
	/// Summary description for InfoForm.
	/// </summary>
	public class InfoForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button bInfo;
		private System.Windows.Forms.Button bWeights;
		private System.Windows.Forms.Button bNet;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public InfoForm()
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
			this.bInfo = new System.Windows.Forms.Button();
			this.bWeights = new System.Windows.Forms.Button();
			this.bNet = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// bInfo
			// 
			this.bInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.bInfo.Location = new System.Drawing.Point(8, 8);
			this.bInfo.Name = "bInfo";
			this.bInfo.Size = new System.Drawing.Size(130, 32);
			this.bInfo.TabIndex = 1;
			this.bInfo.Text = "View Structure...";
			this.bInfo.Click += new System.EventHandler(this.bInfo_Click);
			// 
			// bWeights
			// 
			this.bWeights.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.bWeights.Location = new System.Drawing.Point(152, 8);
			this.bWeights.Name = "bWeights";
			this.bWeights.Size = new System.Drawing.Size(130, 32);
			this.bWeights.TabIndex = 2;
			this.bWeights.Text = "View Weights...";
			this.bWeights.Click += new System.EventHandler(this.bWeights_Click);
			// 
			// bNet
			// 
			this.bNet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.bNet.Location = new System.Drawing.Point(296, 8);
			this.bNet.Name = "bNet";
			this.bNet.Size = new System.Drawing.Size(130, 32);
			this.bNet.TabIndex = 3;
			this.bNet.Text = "View Network...";
			// 
			// InfoForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(434, 48);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.bNet,
																		  this.bWeights,
																		  this.bInfo});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "InfoForm";
			this.Text = "Network Info";
			this.Load += new System.EventHandler(this.InfoForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void bInfo_Click(object sender, System.EventArgs e)
		{
			System.IO.StreamWriter writer = new System.IO.StreamWriter("temp_file");
			//
			writer.WriteLine(Form1.Network.ToString());
			writer.Flush();
			writer.Close();
			//
			Process.Start("wordpad", "temp_file");
		}

		private void bWeights_Click(object sender, System.EventArgs e)
		{
			System.IO.StreamWriter writer = new System.IO.StreamWriter("temp_file");
			//
			writer.WriteLine(Form1.Network.Weights());
			writer.Flush();
			writer.Close();
			//
			Process.Start("wordpad", "temp_file");		
		}

		private void InfoForm_Load(object sender, System.EventArgs e)
		{
			this.Top = this.Owner.Top+this.Owner.Height+2;
			this.Left = this.Owner.Left;
		}
	}
}
