using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using NeuralLib;

namespace NetworkPreprocessor
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		//
		public static BackPropNet Network = null;
		CreateNetworkForm create = null;
		InfoForm info = new InfoForm();
		//
		private System.Windows.Forms.Button bNew;
		private System.Windows.Forms.Button bLoad;
		private System.Windows.Forms.Button bSave;
		private System.Windows.Forms.SaveFileDialog sf;
		private System.Windows.Forms.OpenFileDialog of;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			create = new CreateNetworkForm();
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
			this.bNew = new System.Windows.Forms.Button();
			this.bLoad = new System.Windows.Forms.Button();
			this.bSave = new System.Windows.Forms.Button();
			this.sf = new System.Windows.Forms.SaveFileDialog();
			this.of = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// bNew
			// 
			this.bNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.bNew.Location = new System.Drawing.Point(8, 8);
			this.bNew.Name = "bNew";
			this.bNew.Size = new System.Drawing.Size(130, 32);
			this.bNew.TabIndex = 0;
			this.bNew.Text = "New Network...";
			this.bNew.Click += new System.EventHandler(this.button1_Click);
			// 
			// bLoad
			// 
			this.bLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.bLoad.Location = new System.Drawing.Point(152, 8);
			this.bLoad.Name = "bLoad";
			this.bLoad.Size = new System.Drawing.Size(130, 32);
			this.bLoad.TabIndex = 1;
			this.bLoad.Text = "Load Network...";
			this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
			// 
			// bSave
			// 
			this.bSave.Enabled = false;
			this.bSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.bSave.Location = new System.Drawing.Point(296, 8);
			this.bSave.Name = "bSave";
			this.bSave.Size = new System.Drawing.Size(130, 32);
			this.bSave.TabIndex = 2;
			this.bSave.Text = "Save Network...";
			this.bSave.Click += new System.EventHandler(this.bSave_Click);
			// 
			// sf
			// 
			this.sf.DefaultExt = "nst";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(432, 46);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.bSave,
																		  this.bLoad,
																		  this.bNew});
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Preprocessor";
			this.Load += new System.EventHandler(this.Form1_Load);
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

		private void button1_Click(object sender, System.EventArgs e)
		{
			bLoad.Enabled = false;
			//
			if(create.ShowDialog(this) == DialogResult.Cancel)
			{
				this.bLoad.Enabled = true;
			}
			else
			{
				this.bSave.Enabled = true;
			}

		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void bSave_Click(object sender, System.EventArgs e)
		{
			sf.Title = "Save Network Structure";
			//
			if(Network != null && sf.ShowDialog() == DialogResult.OK)
			{
				string filename = sf.FileName;
				//
				BackPropNet.BinarySave(filename, Network);
			}
			//
			this.bLoad.Enabled = true;
		}

		private void bLoad_Click(object sender, System.EventArgs e)
		{
			//
			if(of.ShowDialog() == DialogResult.OK)
			{
				try
				{
					Network = BackPropNet.BinaryLoad(of.FileName);
					info.ShowDialog(this);
				}
				catch(System.Exception ex)
				{
					MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Network = null;
				}
			}
		}
	}
}
