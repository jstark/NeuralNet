using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using NeuralLib;

namespace NeuralModel
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		// my objects <*>
		private BackPropNet nnet			= null;
		private TrainingAlgorithm algorithm = null;
		private string trainingInputs		= null;
		private string trainingTargets      = null;
		private string validationInputs     = null;
		private string validationTargets    = null;
		private string testInputs			= null;
		private string testTargets          = null;
		private bool   canStart				= false;
		private bool   trIsOk				= false;
		private bool   valIsOk				= false;
		private bool   testIsOk				= false;
		private bool   keepTraining			= true;
		private string results				= null;
		// <*>
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.ComboBox cbInputNeurons;
		private System.Windows.Forms.ComboBox cbMaxHiddenNeurons;
		private System.Windows.Forms.ComboBox cbOutputNeurons;
		private System.Windows.Forms.ComboBox cbMinHiddenNeurons;
		private System.Windows.Forms.ComboBox cbOutputActFunction;
		private System.Windows.Forms.ComboBox cbHiddenActFunction;
		private System.Windows.Forms.ComboBox cbAlgorithm;
		private System.Windows.Forms.TextBox tbEpochs;
		private System.Windows.Forms.TextBox tbMaxFails;
		private System.Windows.Forms.TextBox tbMomentum;
		private System.Windows.Forms.TextBox tbLearnRate;
		private System.Windows.Forms.ComboBox cbTrainTimes;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.GroupBox groupBox11;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.OpenFileDialog openFile;
		private System.Windows.Forms.RichTextBox log;
		private System.Windows.Forms.Button bStart;
		private System.Windows.Forms.RichTextBox tbResults;
		private System.Windows.Forms.SaveFileDialog saveFile1;
		private System.Windows.Forms.CheckBox cbUseSecondLayer;
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
			for(int i=1; i<101; i++)
			{
				cbInputNeurons.Sorted = false;
				cbInputNeurons.Items.Add(i.ToString());
				cbOutputNeurons.Items.Add(i.ToString());
				cbMinHiddenNeurons.Items.Add(i.ToString());
				cbMaxHiddenNeurons.Items.Add(i.ToString());
			}
			//
			cbOutputActFunction.SelectedIndex = 0;
			cbHiddenActFunction.SelectedIndex = 1;
			cbAlgorithm.SelectedIndex = 0;
			cbTrainTimes.SelectedIndex = 4;
			cbInputNeurons.SelectedIndex = 0;
			cbOutputNeurons.SelectedIndex = 0;
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
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.groupBox12 = new System.Windows.Forms.GroupBox();
			this.label23 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cbMinHiddenNeurons = new System.Windows.Forms.ComboBox();
			this.cbMaxHiddenNeurons = new System.Windows.Forms.ComboBox();
			this.cbHiddenActFunction = new System.Windows.Forms.ComboBox();
			this.cbUseSecondLayer = new System.Windows.Forms.CheckBox();
			this.groupBox11 = new System.Windows.Forms.GroupBox();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.cbOutputNeurons = new System.Windows.Forms.ComboBox();
			this.cbOutputActFunction = new System.Windows.Forms.ComboBox();
			this.groupBox10 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbInputNeurons = new System.Windows.Forms.ComboBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbEpochs = new System.Windows.Forms.TextBox();
			this.tbMaxFails = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cbTrainTimes = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.cbAlgorithm = new System.Windows.Forms.ComboBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.tbLearnRate = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tbMomentum = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.button11 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.bStart = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.log = new System.Windows.Forms.RichTextBox();
			this.openFile = new System.Windows.Forms.OpenFileDialog();
			this.tbResults = new System.Windows.Forms.RichTextBox();
			this.saveFile1 = new System.Windows.Forms.SaveFileDialog();
			this.tabPage1.SuspendLayout();
			this.groupBox12.SuspendLayout();
			this.groupBox11.SuspendLayout();
			this.groupBox10.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.groupBox12,
																				   this.groupBox11,
																				   this.groupBox10});
			this.tabPage1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.tabPage1.Location = new System.Drawing.Point(4, 28);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(440, 184);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Network Architecture";
			// 
			// groupBox12
			// 
			this.groupBox12.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.label23,
																					 this.label3,
																					 this.label2,
																					 this.cbMinHiddenNeurons,
																					 this.cbMaxHiddenNeurons,
																					 this.cbHiddenActFunction,
																					 this.cbUseSecondLayer});
			this.groupBox12.Location = new System.Drawing.Point(224, 8);
			this.groupBox12.Name = "groupBox12";
			this.groupBox12.Size = new System.Drawing.Size(208, 168);
			this.groupBox12.TabIndex = 12;
			this.groupBox12.TabStop = false;
			this.groupBox12.Text = "Hidden Layer";
			// 
			// label23
			// 
			this.label23.Location = new System.Drawing.Point(8, 104);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(104, 24);
			this.label23.TabIndex = 12;
			this.label23.Text = "Activation:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 24);
			this.label3.TabIndex = 11;
			this.label3.Text = "Min Neurons";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(104, 24);
			this.label2.TabIndex = 10;
			this.label2.Text = "Min Neurons";
			// 
			// cbMinHiddenNeurons
			// 
			this.cbMinHiddenNeurons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMinHiddenNeurons.ItemHeight = 19;
			this.cbMinHiddenNeurons.Location = new System.Drawing.Point(120, 24);
			this.cbMinHiddenNeurons.Name = "cbMinHiddenNeurons";
			this.cbMinHiddenNeurons.Size = new System.Drawing.Size(80, 27);
			this.cbMinHiddenNeurons.TabIndex = 4;
			this.cbMinHiddenNeurons.SelectedIndexChanged += new System.EventHandler(this.cbMinHiddenNeurons_SelectedIndexChanged);
			// 
			// cbMaxHiddenNeurons
			// 
			this.cbMaxHiddenNeurons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbMaxHiddenNeurons.ItemHeight = 19;
			this.cbMaxHiddenNeurons.Location = new System.Drawing.Point(120, 64);
			this.cbMaxHiddenNeurons.Name = "cbMaxHiddenNeurons";
			this.cbMaxHiddenNeurons.Size = new System.Drawing.Size(80, 27);
			this.cbMaxHiddenNeurons.TabIndex = 6;
			this.cbMaxHiddenNeurons.SelectedIndexChanged += new System.EventHandler(this.cbMaxHiddenNeurons_SelectedIndexChanged);
			// 
			// cbHiddenActFunction
			// 
			this.cbHiddenActFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbHiddenActFunction.ItemHeight = 19;
			this.cbHiddenActFunction.Items.AddRange(new object[] {
																	 "TanSig",
																	 "LogSig",
																	 "Linear"});
			this.cbHiddenActFunction.Location = new System.Drawing.Point(120, 104);
			this.cbHiddenActFunction.Name = "cbHiddenActFunction";
			this.cbHiddenActFunction.Size = new System.Drawing.Size(80, 27);
			this.cbHiddenActFunction.TabIndex = 7;
			// 
			// cbUseSecondLayer
			// 
			this.cbUseSecondLayer.Location = new System.Drawing.Point(16, 136);
			this.cbUseSecondLayer.Name = "cbUseSecondLayer";
			this.cbUseSecondLayer.Size = new System.Drawing.Size(184, 24);
			this.cbUseSecondLayer.TabIndex = 9;
			this.cbUseSecondLayer.Text = "Use 2nd Hidden Layer";
			// 
			// groupBox11
			// 
			this.groupBox11.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.label22,
																					 this.label21,
																					 this.cbOutputNeurons,
																					 this.cbOutputActFunction});
			this.groupBox11.Location = new System.Drawing.Point(8, 72);
			this.groupBox11.Name = "groupBox11";
			this.groupBox11.Size = new System.Drawing.Size(208, 104);
			this.groupBox11.TabIndex = 11;
			this.groupBox11.TabStop = false;
			this.groupBox11.Text = "Output Layer";
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(8, 56);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(96, 24);
			this.label22.TabIndex = 6;
			this.label22.Text = "Activation:";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(8, 24);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(104, 24);
			this.label21.TabIndex = 1;
			this.label21.Text = "#of  Neurons:";
			// 
			// cbOutputNeurons
			// 
			this.cbOutputNeurons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOutputNeurons.ItemHeight = 19;
			this.cbOutputNeurons.Location = new System.Drawing.Point(120, 16);
			this.cbOutputNeurons.Name = "cbOutputNeurons";
			this.cbOutputNeurons.Size = new System.Drawing.Size(80, 27);
			this.cbOutputNeurons.TabIndex = 5;
			// 
			// cbOutputActFunction
			// 
			this.cbOutputActFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOutputActFunction.ItemHeight = 19;
			this.cbOutputActFunction.Items.AddRange(new object[] {
																	 "LogSig",
																	 "TanSig"});
			this.cbOutputActFunction.Location = new System.Drawing.Point(120, 56);
			this.cbOutputActFunction.Name = "cbOutputActFunction";
			this.cbOutputActFunction.Size = new System.Drawing.Size(80, 27);
			this.cbOutputActFunction.TabIndex = 8;
			// 
			// groupBox10
			// 
			this.groupBox10.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.label1,
																					 this.cbInputNeurons});
			this.groupBox10.Location = new System.Drawing.Point(8, 8);
			this.groupBox10.Name = "groupBox10";
			this.groupBox10.Size = new System.Drawing.Size(208, 56);
			this.groupBox10.TabIndex = 10;
			this.groupBox10.TabStop = false;
			this.groupBox10.Text = "Input Layer";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "#of  Neurons:";
			// 
			// cbInputNeurons
			// 
			this.cbInputNeurons.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbInputNeurons.ItemHeight = 19;
			this.cbInputNeurons.Location = new System.Drawing.Point(120, 16);
			this.cbInputNeurons.Name = "cbInputNeurons";
			this.cbInputNeurons.Size = new System.Drawing.Size(80, 27);
			this.cbInputNeurons.TabIndex = 3;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.checkBox3,
																				   this.groupBox3,
																				   this.groupBox2,
																				   this.groupBox1});
			this.tabPage2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.tabPage2.Location = new System.Drawing.Point(4, 28);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(440, 184);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Data";
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(8, 152);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(264, 24);
			this.checkBox3.TabIndex = 11;
			this.checkBox3.Text = "Choose Model by Validation Data";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.button5,
																					this.button6});
			this.groupBox3.Location = new System.Drawing.Point(296, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(136, 136);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "For Testing";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(8, 80);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(120, 40);
			this.button5.TabIndex = 3;
			this.button5.Text = "Targets...";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(8, 32);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(120, 40);
			this.button6.TabIndex = 2;
			this.button6.Text = "Inputs...";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.button4,
																					this.button3});
			this.groupBox2.Location = new System.Drawing.Point(152, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(136, 136);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "For Validation";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(8, 80);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(120, 40);
			this.button4.TabIndex = 3;
			this.button4.Text = "Targets...";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(8, 32);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(120, 40);
			this.button3.TabIndex = 2;
			this.button3.Text = "Inputs...";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.button1,
																					this.button2});
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(136, 136);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "For Training ";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 32);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 40);
			this.button1.TabIndex = 1;
			this.button1.Text = "Inputs...";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(8, 80);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(120, 40);
			this.button2.TabIndex = 2;
			this.button2.Text = "Targets...";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.groupBox5,
																				   this.cbTrainTimes,
																				   this.label10,
																				   this.label9,
																				   this.cbAlgorithm,
																				   this.groupBox4});
			this.tabPage3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.tabPage3.Location = new System.Drawing.Point(4, 28);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(440, 184);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Training Options";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.label4,
																					this.tbEpochs,
																					this.tbMaxFails,
																					this.label6});
			this.groupBox5.Location = new System.Drawing.Point(224, 48);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(208, 96);
			this.groupBox5.TabIndex = 27;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Generic";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 24);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 24);
			this.label4.TabIndex = 18;
			this.label4.Text = "Train Epochs:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbEpochs
			// 
			this.tbEpochs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbEpochs.Location = new System.Drawing.Point(136, 24);
			this.tbEpochs.Name = "tbEpochs";
			this.tbEpochs.Size = new System.Drawing.Size(64, 26);
			this.tbEpochs.TabIndex = 23;
			this.tbEpochs.Text = "1000";
			this.tbEpochs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbMaxFails
			// 
			this.tbMaxFails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbMaxFails.Location = new System.Drawing.Point(136, 56);
			this.tbMaxFails.Name = "tbMaxFails";
			this.tbMaxFails.Size = new System.Drawing.Size(64, 26);
			this.tbMaxFails.TabIndex = 22;
			this.tbMaxFails.Text = "5";
			this.tbMaxFails.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 56);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(128, 24);
			this.label6.TabIndex = 20;
			this.label6.Text = "Maximum Fails:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbTrainTimes
			// 
			this.cbTrainTimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbTrainTimes.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.cbTrainTimes.ItemHeight = 19;
			this.cbTrainTimes.Items.AddRange(new object[] {
															  "1",
															  "2",
															  "3",
															  "4",
															  "5",
															  "10",
															  "20",
															  "30",
															  "40",
															  "50",
															  "100",
															  "200",
															  "300",
															  "400",
															  "500"});
			this.cbTrainTimes.Location = new System.Drawing.Point(288, 150);
			this.cbTrainTimes.Name = "cbTrainTimes";
			this.cbTrainTimes.Size = new System.Drawing.Size(88, 27);
			this.cbTrainTimes.TabIndex = 25;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.label10.Location = new System.Drawing.Point(8, 152);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(272, 23);
			this.label10.TabIndex = 24;
			this.label10.Text = "Number of Times to Train Networks: ";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 14);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(88, 24);
			this.label9.TabIndex = 13;
			this.label9.Text = "Algorithm:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cbAlgorithm
			// 
			this.cbAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbAlgorithm.ItemHeight = 19;
			this.cbAlgorithm.Items.AddRange(new object[] {
															 "SimpleBPM",
															 "RProp"});
			this.cbAlgorithm.Location = new System.Drawing.Point(104, 10);
			this.cbAlgorithm.Name = "cbAlgorithm";
			this.cbAlgorithm.Size = new System.Drawing.Size(112, 27);
			this.cbAlgorithm.TabIndex = 12;
			this.cbAlgorithm.SelectedIndexChanged += new System.EventHandler(this.cbAlgorithm_SelectedIndexChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.tbLearnRate,
																					this.label7,
																					this.tbMomentum,
																					this.label8});
			this.groupBox4.Location = new System.Drawing.Point(8, 48);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(208, 96);
			this.groupBox4.TabIndex = 26;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Back Propagation";
			// 
			// tbLearnRate
			// 
			this.tbLearnRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbLearnRate.Location = new System.Drawing.Point(136, 24);
			this.tbLearnRate.Name = "tbLearnRate";
			this.tbLearnRate.Size = new System.Drawing.Size(64, 26);
			this.tbLearnRate.TabIndex = 16;
			this.tbLearnRate.Text = "0.25";
			this.tbLearnRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 56);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(96, 24);
			this.label7.TabIndex = 15;
			this.label7.Text = "Momentum:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbMomentum
			// 
			this.tbMomentum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbMomentum.Location = new System.Drawing.Point(136, 56);
			this.tbMomentum.Name = "tbMomentum";
			this.tbMomentum.Size = new System.Drawing.Size(64, 26);
			this.tbMomentum.TabIndex = 17;
			this.tbMomentum.Text = "0.0";
			this.tbMomentum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(112, 24);
			this.label8.TabIndex = 14;
			this.label8.Text = "Learn Rate:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.tabPage1,
																					  this.tabPage2,
																					  this.tabPage3});
			this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.tabControl1.ItemSize = new System.Drawing.Size(157, 24);
			this.tabControl1.Location = new System.Drawing.Point(8, 16);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(448, 216);
			this.tabControl1.TabIndex = 0;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.button11,
																					this.button9,
																					this.bStart,
																					this.button7});
			this.groupBox6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.groupBox6.Location = new System.Drawing.Point(472, 8);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(264, 136);
			this.groupBox6.TabIndex = 1;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Actions";
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(136, 24);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(120, 40);
			this.button11.TabIndex = 4;
			this.button11.Text = "Save Results...";
			this.button11.Click += new System.EventHandler(this.button11_Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(136, 80);
			this.button9.Name = "button9";
			this.button9.Size = new System.Drawing.Size(120, 40);
			this.button9.TabIndex = 2;
			this.button9.Text = "Stop Training";
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// bStart
			// 
			this.bStart.Location = new System.Drawing.Point(8, 80);
			this.bStart.Name = "bStart";
			this.bStart.Size = new System.Drawing.Size(120, 40);
			this.bStart.TabIndex = 1;
			this.bStart.Text = "Start Training";
			this.bStart.Click += new System.EventHandler(this.bStart_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(8, 24);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(120, 40);
			this.button7.TabIndex = 0;
			this.button7.Text = "Check All...";
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// log
			// 
			this.log.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.log.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.log.Location = new System.Drawing.Point(472, 152);
			this.log.Name = "log";
			this.log.Size = new System.Drawing.Size(264, 80);
			this.log.TabIndex = 2;
			this.log.Text = "";
			// 
			// openFile
			// 
			this.openFile.AddExtension = false;
			// 
			// tbResults
			// 
			this.tbResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tbResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(161)));
			this.tbResults.Location = new System.Drawing.Point(8, 240);
			this.tbResults.Name = "tbResults";
			this.tbResults.Size = new System.Drawing.Size(728, 296);
			this.tbResults.TabIndex = 3;
			this.tbResults.Text = "";
			// 
			// saveFile1
			// 
			this.saveFile1.FileName = "doc1";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(744, 542);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tbResults,
																		  this.log,
																		  this.groupBox6,
																		  this.tabControl1});
			this.Name = "Form1";
			this.Text = "Neural Network Model Estimation";
			this.tabPage1.ResumeLayout(false);
			this.groupBox12.ResumeLayout(false);
			this.groupBox11.ResumeLayout(false);
			this.groupBox10.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
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

		private void cbMinHiddenNeurons_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int c_selection1 = cbMinHiddenNeurons.SelectedIndex;
			int c_selection2 = cbMaxHiddenNeurons.SelectedIndex;
			if(c_selection1 > c_selection2)
			{
				cbMaxHiddenNeurons.SelectedIndex = c_selection1+1;
			}
		}

		private void cbMaxHiddenNeurons_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int c_selection1 = cbMinHiddenNeurons.SelectedIndex;
			int c_selection2 = cbMaxHiddenNeurons.SelectedIndex;
			if(c_selection2 < c_selection1)
			{
				cbMinHiddenNeurons.SelectedIndex = c_selection2-1;
			}
		}

		private void cbAlgorithm_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cbAlgorithm.SelectedIndex == 0)
			{
				tbLearnRate.Enabled = true;
				tbMomentum.Enabled = true;
			}
			else
			{
				tbLearnRate.Enabled = false;
				tbMomentum.Enabled = false;
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			string filename;
			//
			openFile.Title = "Choose Training Inputs File...";
			//
			if(openFile.ShowDialog() == DialogResult.OK)
			{
				filename = openFile.FileName;
				//
				if(openFile.FileName != " ")
				{
					this.trainingInputs = filename;
					//
					try
					{
						NeuralLib.DataSet temp = new NeuralLib.DataSet(trainingInputs);
						//
						if(!temp.GetDataValidation())
							throw new Exception("Training Inputs Data Corrupt!");
						else if(temp.GetLengthOfVectors() != Convert.ToInt32(cbInputNeurons.SelectedItem))
							throw new Exception("Inputs Vector Size NOT EQUAL to Network's Number Of Input Neurons!");
						else
							MessageBox.Show("Training Inputs Loaded!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch(System.Exception ex)
					{
						MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
						MessageBox.Show("Choose AGAIN Training Inputs!", "Warning");
						this.trainingInputs = null;
					}
				}
			}
			//
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			string filename;
			//
			openFile.Title = "Choose Training Targets File...";
			//
			if(openFile.ShowDialog() == DialogResult.OK)
			{
				filename = openFile.FileName;
				//
				if(openFile.FileName != " ")
				{
					this.trainingTargets = filename;
					//
					try
					{
						NeuralLib.DataSet temp = new NeuralLib.DataSet(trainingTargets);
						//
						if(!temp.GetDataValidation())
							throw new Exception("Training Targets Data Corrupt!");
						else if(temp.GetLengthOfVectors() != Convert.ToInt32(cbOutputNeurons.SelectedItem))
							throw new Exception("Targets Vector Size NOT EQUAL to Network's Number Of Output Neurons!");
						else
							MessageBox.Show("Training Targets Loaded!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch(System.Exception ex)
					{
						MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
						MessageBox.Show("Choose AGAIN Training Targets!", "Warning");
						this.trainingTargets = null;
					}
				}
			}	
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			string filename;
			//
			openFile.Title = "Choose Validation Inputs File...";
			//
			if(openFile.ShowDialog() == DialogResult.OK)
			{
				filename = openFile.FileName;
				//
				if(openFile.FileName != " ")
				{
					this.validationInputs = filename;
					//
					try
					{
						NeuralLib.DataSet temp = new NeuralLib.DataSet(validationInputs);
						//
						if(!temp.GetDataValidation())
							throw new Exception("Validation Inputs Data Corrupt!");
						else if(temp.GetLengthOfVectors() != Convert.ToInt32(cbInputNeurons.SelectedItem))
							throw new Exception("Validation Inputs Vector Size NOT EQUAL to Network's Number Of Input Neurons!");
						else
							MessageBox.Show("Validation Inputs Loaded!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch(System.Exception ex)
					{
						MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
						MessageBox.Show("Choose AGAIN Validation Inputs!", "Warning");
						this.validationInputs = null;
					}
				}
			}	
		
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			string filename;
			//
			openFile.Title = "Choose Validation Targets File...";
			//
			if(openFile.ShowDialog() == DialogResult.OK)
			{
				filename = openFile.FileName;
				//
				if(openFile.FileName != " ")
				{
					this.validationTargets = filename;
					//
					try
					{
						NeuralLib.DataSet temp = new NeuralLib.DataSet(validationTargets);
						//
						if(!temp.GetDataValidation())
							throw new Exception("Validation Targets Data Corrupt!");
						else if(temp.GetLengthOfVectors() != Convert.ToInt32(cbOutputNeurons.SelectedItem))
							throw new Exception("Validation Targets Vector Size NOT EQUAL to Network's Number Of Output Neurons!");
						else
							MessageBox.Show("Validation Targets Loaded!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch(System.Exception ex)
					{
						MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
						MessageBox.Show("Choose AGAIN Validation Targets!", "Warning");
						this.validationTargets = null;
					}
				}
			}	
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			string filename;
			//
			openFile.Title = "Choose Test Inputs File...";
			//
			if(openFile.ShowDialog() == DialogResult.OK)
			{
				filename = openFile.FileName;
				//
				if(openFile.FileName != " ")
				{
					this.testInputs = filename;
					//
					try
					{
						NeuralLib.DataSet temp = new NeuralLib.DataSet(testInputs);
						//
						if(!temp.GetDataValidation())
							throw new Exception("Test Inputs Data Corrupt!");
						else if(temp.GetLengthOfVectors() != Convert.ToInt32(cbInputNeurons.SelectedItem))
							throw new Exception("Test Inputs Vector Size NOT EQUAL to Network's Number Of Input Neurons!");
						else
							MessageBox.Show("Test Inputs Loaded!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch(System.Exception ex)
					{
						MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
						MessageBox.Show("Choose AGAIN Test Inputs!", "Warning");
						this.testInputs = null;
					}
				}
			}	
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			string filename;
			//
			openFile.Title = "Choose Test Targets File...";
			//
			if(openFile.ShowDialog() == DialogResult.OK)
			{
				filename = openFile.FileName;
				//
				if(openFile.FileName != " ")
				{
					this.testTargets = filename;
					//
					try
					{
						NeuralLib.DataSet temp = new NeuralLib.DataSet(testTargets);
						//
						if(!temp.GetDataValidation())
							throw new Exception("Test Targets Data Corrupt!");
						else if(temp.GetLengthOfVectors() != Convert.ToInt32(cbOutputNeurons.SelectedItem))
							throw new Exception("Test Targets Vector Size NOT EQUAL to Network's Number Of Output Neurons!");
						else
							MessageBox.Show("Test Targets Loaded!", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch(System.Exception ex)
					{
						MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
						MessageBox.Show("Choose AGAIN Test Targets!", "Warning");
						this.testTargets = null;
					}
				}
			}	
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			try
			{
				canStart = true;
				// check training inputs and targets
				int tinputs  = new NeuralLib.DataSet(trainingInputs).GetNumberOfVectors();
				int ttargets = new NeuralLib.DataSet(trainingTargets).GetNumberOfVectors();
				//
				if(tinputs != ttargets)
				{
					canStart = false;
					MessageBox.Show("Training Inputs and Targets Differ in Size");
					trIsOk = false;
				}
				else
				{
					trIsOk = true;
					MessageBox.Show(tinputs.ToString()+" Training Inputs and Targets.", "Attention");
				}
				//
				if(validationInputs != null && validationTargets != null)
				{
					int vinputs  = new NeuralLib.DataSet(validationInputs).GetNumberOfVectors();
					int vtargets = new NeuralLib.DataSet(validationTargets).GetNumberOfVectors();
					//
					if(vinputs != vtargets)
					{
						canStart = false;
						MessageBox.Show("Validation Inputs and Targets Differ in Size");
						valIsOk = false;
					}
					else
					{
						valIsOk = true;
						MessageBox.Show(vinputs.ToString()+" Validation Inputs & Targets. ", "Attention");
					}
				}
				//
				if(testInputs != null && testTargets != null)
				{
					int sinputs  = new NeuralLib.DataSet(testInputs).GetNumberOfVectors();
					int stargets = new NeuralLib.DataSet(testTargets).GetNumberOfVectors();
					//
					if(sinputs != stargets)
					{
						canStart = false;
						MessageBox.Show("Test Inputs and Targets Differ in Size");
						testIsOk = false;
					}
					else
					{
						testIsOk = true;
						MessageBox.Show(sinputs.ToString()+" Test Inputs and Targets.", "Attention");
					}
				}
				//
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void bStart_Click(object sender, System.EventArgs e)
		{
			//
			System.IO.StreamWriter sw = new System.IO.StreamWriter(results);
			sw.AutoFlush = true;
			keepTraining = true;
			//
			int numberOfTimesToTrain = Convert.ToInt32(cbTrainTimes.SelectedItem);
			//
			uint inputSize  = Convert.ToUInt32(cbInputNeurons.SelectedItem);
			uint outputSize = Convert.ToUInt32(cbOutputNeurons.SelectedItem);
			//
			uint minNeurons = Convert.ToUInt32(cbMinHiddenNeurons.SelectedItem);
			uint maxNeurons = Convert.ToUInt32(cbMaxHiddenNeurons.SelectedItem);
			//
			tbResults.Text = "Hidden Neurons ---- Mean Train Error --- Mean Validation Error ------ Mean Test Error";
			uint n = minNeurons-1;
			while(keepTraining)
			{
				n++;
				if(n > maxNeurons)
					break;
				//
				double meanTrError = 0;
				double meanVaError = 0;
				double meanTeError = 0;
				//
				Application.DoEvents();
				for(int i=0; i<numberOfTimesToTrain; i++)
				{
					nnet = new BackPropNet(inputSize, outputSize, n);
					//
					if(cbHiddenActFunction.SelectedItem.ToString() != "LogSig")
					{
						nnet.SetHiddenActivationFunction(ActivationFunction.TanSig);
					}
					//
					if(cbOutputActFunction.SelectedItem.ToString() == "TanSig")
						nnet.SetOutputActivationFunction(ActivationFunction.TanSig);
					else if(cbOutputActFunction.SelectedItem.ToString() == "Linear")
						nnet.SetOutputActivationFunction(ActivationFunction.Linear);
					//
					nnet.Randomize(-0.2, 0.2);
					//
					if(cbAlgorithm.Text == "RProp")
					{
						algorithm = new RProp(nnet, trainingInputs, trainingTargets);
					}
					else
					{
						algorithm = new SimpleBPM(nnet, trainingInputs, trainingTargets);
						((SimpleBPM)algorithm).Momentum = Convert.ToDouble(this.tbMomentum.Text);
						((SimpleBPM)algorithm).LearnRate = Convert.ToDouble(this.tbLearnRate.Text);
					}
					//
					algorithm.Epochs = Convert.ToUInt32(this.tbEpochs.Text);
					algorithm.MaxFailures = Convert.ToUInt32(this.tbMaxFails.Text);
					//
					if(valIsOk)
						algorithm.SetValidationData(validationInputs, validationTargets);
					//
					if(cbAlgorithm.Text == "RProp")
					{
						((RProp)algorithm).Train();
					}
					else
					{
						((SimpleBPM)algorithm).Train();
					}
					//
					double trError = algorithm.TrainingPerformance;
					double vaError = Double.NaN;
					double teError = Double.NaN;
					//
					if(valIsOk)
					{
						vaError = algorithm.ValidationPerformance;
						meanVaError += vaError;
					}
					//
					if(testIsOk)
					{
						teError = nnet.Simulate(new NeuralLib.DataSet(testInputs), new NeuralLib.DataSet(testTargets));
						meanTeError += teError;
					}
					//
					meanTrError += trError;
					Application.DoEvents();
				}
				//
				meanTrError = meanTrError/numberOfTimesToTrain;
				//
				if(valIsOk)
					meanVaError = meanVaError/numberOfTimesToTrain;
				//
				if(testIsOk)
					meanTeError = meanTeError/numberOfTimesToTrain;
				//
				tbResults.AppendText("\n"+"\t"+n.ToString()+"\t\t"+meanTrError.ToString("E5")+"\t\t"+
					meanVaError.ToString("E6")+"\t\t"+meanTeError.ToString("E6"));
				//
				sw.WriteLine(nnet.GetStructure()+"\t\t"+meanTrError.ToString("E5")+"\t\t"+
					meanVaError.ToString("E6")+"\t\t"+meanTeError.ToString("E6"));
				Application.DoEvents();
			}
			//
			if(cbUseSecondLayer.Checked == true)
			{
				uint k = 2;
				while(keepTraining)
				{
					k++;
					if(k > n)
						break;
					//
					double meanTrError = 0;
					double meanVaError = 0;
					double meanTeError = 0;
					//
					Application.DoEvents();
					for(int i=0; i<numberOfTimesToTrain; i++)
					{
						nnet = new BackPropNet(inputSize, outputSize, n-1, k-1);
						//
						if(cbHiddenActFunction.SelectedItem.ToString() != "LogSig")
						{
							nnet.SetHiddenActivationFunction(ActivationFunction.TanSig);
						}
						//
						if(cbOutputActFunction.SelectedItem.ToString() == "TanSig")
							nnet.SetOutputActivationFunction(ActivationFunction.TanSig);
						else if(cbOutputActFunction.SelectedItem.ToString() == "Linear")
							nnet.SetOutputActivationFunction(ActivationFunction.Linear);
						//
						nnet.Randomize(-0.2, 0.2);
						//
						if(cbAlgorithm.Text == "RProp")
						{
							algorithm = new RProp(nnet, trainingInputs, trainingTargets);
						}
						else
						{
							algorithm = new SimpleBPM(nnet, trainingInputs, trainingTargets);
							((SimpleBPM)algorithm).Momentum = Convert.ToDouble(this.tbMomentum.Text);
							((SimpleBPM)algorithm).LearnRate = Convert.ToDouble(this.tbLearnRate.Text);
						}
						//
						algorithm.Epochs = Convert.ToUInt32(this.tbEpochs.Text);
						algorithm.MaxFailures = Convert.ToUInt32(this.tbMaxFails.Text);
						//
						if(valIsOk)
							algorithm.SetValidationData(validationInputs, validationTargets);
						//
						if(cbAlgorithm.Text == "RProp")
						{
							((RProp)algorithm).Train();
						}
						else
						{
							((SimpleBPM)algorithm).Train();
						}
						//
						double trError = algorithm.TrainingPerformance;
						double vaError = Double.NaN;
						double teError = Double.NaN;
						//
						if(valIsOk)
						{
							vaError = algorithm.ValidationPerformance;
							meanVaError += vaError;
						}
						//
						if(testIsOk)
						{
							teError = nnet.Simulate(new NeuralLib.DataSet(testInputs), new NeuralLib.DataSet(testTargets));
							meanTeError += teError;
						}
						//
						meanTrError += trError;
						Application.DoEvents();
					}
					//
					meanTrError = meanTrError/numberOfTimesToTrain;
					//
					if(valIsOk)
					meanVaError = meanVaError/numberOfTimesToTrain;
					//
					if(testIsOk)
					meanTeError = meanTeError/numberOfTimesToTrain;
					//
					tbResults.AppendText("\n"+"\t"+nnet.GetStructure()+"\t\t"+meanTrError.ToString("E5")+"\t\t"+
						meanVaError.ToString("E6")+"\t\t"+meanTeError.ToString("E6"));
					//
					sw.WriteLine(nnet.GetStructure()+"\t\t"+meanTrError.ToString("E5")+"\t\t"+
						meanVaError.ToString("E6")+"\t\t"+meanTeError.ToString("E6"));
					Application.DoEvents();
				}
			}
			sw.Flush();
			sw.Close();
		}
		
		private void button9_Click(object sender, System.EventArgs e)
		{
			this.keepTraining = false;
		}

		private void button11_Click(object sender, System.EventArgs e)
		{
			saveFile1.Title = "Choose file to save results...";
			//
			if(saveFile1.ShowDialog() == DialogResult.OK)
			{
				if(saveFile1.FileName != " ")
				{
					results = saveFile1.FileName;
					MessageBox.Show("Results will be saved to file: "+results.ToString(), "Attention");
				}
			}	
		}
	}
}
