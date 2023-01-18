/*
 * Created by SharpDevelop.
 * User: Админ
 * Date: 04.01.2020
 * Time: 23:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace PaLoSi
{
	partial class FormConfiguration
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ComboBox comboBoxTeg;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		//private System.Windows.Forms.ListBox listBoxcheckedListLoadFile;
		private System.Windows.Forms.Button buttonDeleteProxi;
		private System.Windows.Forms.Button buttonAddProxi;
		private System.Windows.Forms.TextBox textBoxProxi;
		private System.Windows.Forms.ListBox listBoxProxi;
		private System.Windows.Forms.TextBox textBoxAddresSite;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxNameProject;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox comboBoxType;
		private System.Windows.Forms.TextBox textBoxNameClass;
		private System.Windows.Forms.ComboBox comboBoxLocationNameClass;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox checkBoxClearTeg;
		private System.Windows.Forms.CheckBox checkBoxLoadFile;
		private System.Windows.Forms.TextBox textBoxNameInfoBlock;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button buttonAddInfoBox;
		private System.Windows.Forms.Button buttonDeleteInfoBox;
		private System.Windows.Forms.ListBox listBoxInfoxBox;
		private System.Windows.Forms.Button buttonUpdateInfoBox;
		private System.Windows.Forms.Button buttonSaveProject;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxErrorLoad;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.CheckedListBox checkedListLoadFile;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TextBox ViewHreftextBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown theFrequencyOfnumericUpDown1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.NumericUpDown immersionDepthnumericUpDown1;
		private System.Windows.Forms.Button Selectbutton1;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox pathAutoExporttextBox1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button ShapeViewHreftextbutton2;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.Button DeleteBlockImportbutton1;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button AddBlocImportbutton1;
		private System.Windows.Forms.CheckedListBox ListXMLImportcheckedListBox1;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox NameBlockImportcomboBox1;
		private System.Windows.Forms.CheckBox StopOldLoadcheckBox1;
		private System.Windows.Forms.CheckBox AllLoadcheckBox1;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox PathLoadIMGBox1textBox1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.ComboBox DirSaveImgcomboBox1;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.NumericUpDown MaxFileSizenumericUpDown2;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.NumericUpDown MinFileSizenumericUpDown1;
		private System.Windows.Forms.Label label17;
	//	private System.Windows.Forms.TabControl tabControl1;
		/*private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		*/
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfiguration));
			this.buttonSaveProject = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.AllLoadcheckBox1 = new System.Windows.Forms.CheckBox();
			this.StopOldLoadcheckBox1 = new System.Windows.Forms.CheckBox();
			this.ShapeViewHreftextbutton2 = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.immersionDepthnumericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.theFrequencyOfnumericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label10 = new System.Windows.Forms.Label();
			this.ViewHreftextBox1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxErrorLoad = new System.Windows.Forms.TextBox();
			this.textBoxAddresSite = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxNameProject = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.buttonUpdateInfoBox = new System.Windows.Forms.Button();
			this.listBoxInfoxBox = new System.Windows.Forms.ListBox();
			this.buttonDeleteInfoBox = new System.Windows.Forms.Button();
			this.buttonAddInfoBox = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.textBoxNameInfoBlock = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.checkBoxClearTeg = new System.Windows.Forms.CheckBox();
			this.label8 = new System.Windows.Forms.Label();
			this.comboBoxLocationNameClass = new System.Windows.Forms.ComboBox();
			this.textBoxNameClass = new System.Windows.Forms.TextBox();
			this.comboBoxType = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.comboBoxTeg = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.listBoxProxi = new System.Windows.Forms.ListBox();
			this.buttonDeleteProxi = new System.Windows.Forms.Button();
			this.buttonAddProxi = new System.Windows.Forms.Button();
			this.textBoxProxi = new System.Windows.Forms.TextBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.label21 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.MaxFileSizenumericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.MinFileSizenumericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.PathLoadIMGBox1textBox1 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.DirSaveImgcomboBox1 = new System.Windows.Forms.ComboBox();
			this.checkBoxLoadFile = new System.Windows.Forms.CheckBox();
			this.checkedListLoadFile = new System.Windows.Forms.CheckedListBox();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.Selectbutton1 = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.pathAutoExporttextBox1 = new System.Windows.Forms.TextBox();
			this.DeleteBlockImportbutton1 = new System.Windows.Forms.Button();
			this.label14 = new System.Windows.Forms.Label();
			this.AddBlocImportbutton1 = new System.Windows.Forms.Button();
			this.ListXMLImportcheckedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.label13 = new System.Windows.Forms.Label();
			this.NameBlockImportcomboBox1 = new System.Windows.Forms.ComboBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.immersionDepthnumericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.theFrequencyOfnumericUpDown1)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MaxFileSizenumericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MinFileSizenumericUpDown1)).BeginInit();
			this.tabPage5.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonSaveProject
			// 
			this.buttonSaveProject.Location = new System.Drawing.Point(12, 455);
			this.buttonSaveProject.Name = "buttonSaveProject";
			this.buttonSaveProject.Size = new System.Drawing.Size(157, 23);
			this.buttonSaveProject.TabIndex = 44;
			this.buttonSaveProject.Text = "Save project";
			this.buttonSaveProject.UseVisualStyleBackColor = true;
			this.buttonSaveProject.Click += new System.EventHandler(this.ButtonSaveProjectClick);
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(175, 455);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(75, 23);
			this.buttonClose.TabIndex = 45;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.tabControl1.RightToLeftLayout = true;
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(353, 437);
			this.tabControl1.TabIndex = 50;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.AllLoadcheckBox1);
			this.tabPage1.Controls.Add(this.StopOldLoadcheckBox1);
			this.tabPage1.Controls.Add(this.ShapeViewHreftextbutton2);
			this.tabPage1.Controls.Add(this.label11);
			this.tabPage1.Controls.Add(this.immersionDepthnumericUpDown1);
			this.tabPage1.Controls.Add(this.theFrequencyOfnumericUpDown1);
			this.tabPage1.Controls.Add(this.label10);
			this.tabPage1.Controls.Add(this.ViewHreftextBox1);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.textBoxErrorLoad);
			this.tabPage1.Controls.Add(this.textBoxAddresSite);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.textBoxNameProject);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(345, 411);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Project";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// AllLoadcheckBox1
			// 
			this.AllLoadcheckBox1.Location = new System.Drawing.Point(9, 205);
			this.AllLoadcheckBox1.Name = "AllLoadcheckBox1";
			this.AllLoadcheckBox1.Size = new System.Drawing.Size(289, 24);
			this.AllLoadcheckBox1.TabIndex = 68;
			this.AllLoadcheckBox1.Text = "Always full load";
			this.AllLoadcheckBox1.UseVisualStyleBackColor = true;
			// 
			// StopOldLoadcheckBox1
			// 
			this.StopOldLoadcheckBox1.Checked = true;
			this.StopOldLoadcheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.StopOldLoadcheckBox1.Location = new System.Drawing.Point(8, 283);
			this.StopOldLoadcheckBox1.Name = "StopOldLoadcheckBox1";
			this.StopOldLoadcheckBox1.Size = new System.Drawing.Size(318, 24);
			this.StopOldLoadcheckBox1.TabIndex = 66;
			this.StopOldLoadcheckBox1.Text = "Start a new download, stop the one that wasn\'t started";
			this.StopOldLoadcheckBox1.UseVisualStyleBackColor = true;
			// 
			// ShapeViewHreftextbutton2
			// 
			this.ShapeViewHreftextbutton2.Location = new System.Drawing.Point(8, 175);
			this.ShapeViewHreftextbutton2.Margin = new System.Windows.Forms.Padding(2);
			this.ShapeViewHreftextbutton2.Name = "ShapeViewHreftextbutton2";
			this.ShapeViewHreftextbutton2.Size = new System.Drawing.Size(190, 23);
			this.ShapeViewHreftextbutton2.TabIndex = 65;
			this.ShapeViewHreftextbutton2.Text = "The configuration of the hyperlink";
			this.ShapeViewHreftextbutton2.UseVisualStyleBackColor = true;
			this.ShapeViewHreftextbutton2.Click += new System.EventHandler(this.ShapeViewHreftextbutton2Click);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 309);
			this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(261, 19);
			this.label11.TabIndex = 61;
			this.label11.Text = "Diving depth. 0 - Scan the entire site";
			// 
			// immersionDepthnumericUpDown1
			// 
			this.immersionDepthnumericUpDown1.Location = new System.Drawing.Point(8, 332);
			this.immersionDepthnumericUpDown1.Margin = new System.Windows.Forms.Padding(2);
			this.immersionDepthnumericUpDown1.Maximum = new decimal(new int[] {
			1000000,
			0,
			0,
			0});
			this.immersionDepthnumericUpDown1.Name = "immersionDepthnumericUpDown1";
			this.immersionDepthnumericUpDown1.Size = new System.Drawing.Size(289, 20);
			this.immersionDepthnumericUpDown1.TabIndex = 60;
			// 
			// theFrequencyOfnumericUpDown1
			// 
			this.theFrequencyOfnumericUpDown1.Location = new System.Drawing.Point(8, 260);
			this.theFrequencyOfnumericUpDown1.Margin = new System.Windows.Forms.Padding(2);
			this.theFrequencyOfnumericUpDown1.Maximum = new decimal(new int[] {
			100000000,
			0,
			0,
			0});
			this.theFrequencyOfnumericUpDown1.Name = "theFrequencyOfnumericUpDown1";
			this.theFrequencyOfnumericUpDown1.Size = new System.Drawing.Size(289, 20);
			this.theFrequencyOfnumericUpDown1.TabIndex = 59;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 236);
			this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(267, 19);
			this.label10.TabIndex = 58;
			this.label10.Text = "The frequency of (second). 0 - to download once";
			// 
			// ViewHreftextBox1
			// 
			this.ViewHreftextBox1.Location = new System.Drawing.Point(8, 152);
			this.ViewHreftextBox1.Margin = new System.Windows.Forms.Padding(2);
			this.ViewHreftextBox1.Name = "ViewHreftextBox1";
			this.ViewHreftextBox1.Size = new System.Drawing.Size(289, 20);
			this.ViewHreftextBox1.TabIndex = 57;
			this.ViewHreftextBox1.Text = "//a";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 131);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(128, 19);
			this.label4.TabIndex = 56;
			this.label4.Text = "Type of hyperlink";
			// 
			// textBoxErrorLoad
			// 
			this.textBoxErrorLoad.Location = new System.Drawing.Point(8, 110);
			this.textBoxErrorLoad.Name = "textBoxErrorLoad";
			this.textBoxErrorLoad.Size = new System.Drawing.Size(289, 20);
			this.textBoxErrorLoad.TabIndex = 55;
			// 
			// textBoxAddresSite
			// 
			this.textBoxAddresSite.Location = new System.Drawing.Point(6, 70);
			this.textBoxAddresSite.Name = "textBoxAddresSite";
			this.textBoxAddresSite.Size = new System.Drawing.Size(291, 20);
			this.textBoxAddresSite.TabIndex = 53;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(263, 20);
			this.label3.TabIndex = 54;
			this.label3.Text = "The error text download";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(265, 15);
			this.label2.TabIndex = 52;
			this.label2.Text = "Site address";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(269, 16);
			this.label1.TabIndex = 51;
			this.label1.Text = "Name project";
			// 
			// textBoxNameProject
			// 
			this.textBoxNameProject.Location = new System.Drawing.Point(6, 30);
			this.textBoxNameProject.Name = "textBoxNameProject";
			this.textBoxNameProject.Size = new System.Drawing.Size(291, 20);
			this.textBoxNameProject.TabIndex = 50;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox2);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(345, 411);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Information blocs";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.buttonUpdateInfoBox);
			this.groupBox2.Controls.Add(this.listBoxInfoxBox);
			this.groupBox2.Controls.Add(this.buttonDeleteInfoBox);
			this.groupBox2.Controls.Add(this.buttonAddInfoBox);
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.textBoxNameInfoBlock);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.checkBoxClearTeg);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.comboBoxLocationNameClass);
			this.groupBox2.Controls.Add(this.textBoxNameClass);
			this.groupBox2.Controls.Add(this.comboBoxType);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.comboBoxTeg);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Location = new System.Drawing.Point(6, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(280, 399);
			this.groupBox2.TabIndex = 48;
			this.groupBox2.TabStop = false;
			// 
			// buttonUpdateInfoBox
			// 
			this.buttonUpdateInfoBox.Location = new System.Drawing.Point(195, 140);
			this.buttonUpdateInfoBox.Name = "buttonUpdateInfoBox";
			this.buttonUpdateInfoBox.Size = new System.Drawing.Size(75, 23);
			this.buttonUpdateInfoBox.TabIndex = 58;
			this.buttonUpdateInfoBox.Text = "Update";
			this.buttonUpdateInfoBox.UseVisualStyleBackColor = true;
			this.buttonUpdateInfoBox.Click += new System.EventHandler(this.ButtonUpdateInfoBoxClick);
			// 
			// listBoxInfoxBox
			// 
			this.listBoxInfoxBox.FormattingEnabled = true;
			this.listBoxInfoxBox.Location = new System.Drawing.Point(3, 167);
			this.listBoxInfoxBox.Name = "listBoxInfoxBox";
			this.listBoxInfoxBox.Size = new System.Drawing.Size(265, 199);
			this.listBoxInfoxBox.TabIndex = 57;
			this.listBoxInfoxBox.SelectedIndexChanged += new System.EventHandler(this.ListBoxInfoxBoxSelectedIndexChanged);
			// 
			// buttonDeleteInfoBox
			// 
			this.buttonDeleteInfoBox.Location = new System.Drawing.Point(3, 371);
			this.buttonDeleteInfoBox.Name = "buttonDeleteInfoBox";
			this.buttonDeleteInfoBox.Size = new System.Drawing.Size(75, 23);
			this.buttonDeleteInfoBox.TabIndex = 56;
			this.buttonDeleteInfoBox.Text = "Delete";
			this.buttonDeleteInfoBox.UseVisualStyleBackColor = true;
			this.buttonDeleteInfoBox.Click += new System.EventHandler(this.ButtonDeleteInfoBoxClick);
			// 
			// buttonAddInfoBox
			// 
			this.buttonAddInfoBox.Location = new System.Drawing.Point(116, 140);
			this.buttonAddInfoBox.Name = "buttonAddInfoBox";
			this.buttonAddInfoBox.Size = new System.Drawing.Size(75, 23);
			this.buttonAddInfoBox.TabIndex = 55;
			this.buttonAddInfoBox.Text = "Add";
			this.buttonAddInfoBox.UseVisualStyleBackColor = true;
			this.buttonAddInfoBox.Click += new System.EventHandler(this.ButtonAddInfoBoxClick);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(3, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(215, 18);
			this.label9.TabIndex = 54;
			this.label9.Text = "Name ";
			// 
			// textBoxNameInfoBlock
			// 
			this.textBoxNameInfoBlock.Location = new System.Drawing.Point(3, 37);
			this.textBoxNameInfoBlock.Name = "textBoxNameInfoBlock";
			this.textBoxNameInfoBlock.Size = new System.Drawing.Size(265, 20);
			this.textBoxNameInfoBlock.TabIndex = 53;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(3, 101);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(215, 13);
			this.label5.TabIndex = 52;
			this.label5.Text = "Name class/id";
			// 
			// checkBoxClearTeg
			// 
			this.checkBoxClearTeg.Location = new System.Drawing.Point(3, 141);
			this.checkBoxClearTeg.Name = "checkBoxClearTeg";
			this.checkBoxClearTeg.Size = new System.Drawing.Size(116, 21);
			this.checkBoxClearTeg.TabIndex = 51;
			this.checkBoxClearTeg.Text = "Clear from tags";
			this.checkBoxClearTeg.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(152, 60);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(116, 16);
			this.label8.TabIndex = 50;
			this.label8.Text = "Placement";
			// 
			// comboBoxLocationNameClass
			// 
			this.comboBoxLocationNameClass.FormattingEnabled = true;
			this.comboBoxLocationNameClass.Items.AddRange(new object[] {
			"INPUT",
			"OUTPUT"});
			this.comboBoxLocationNameClass.Location = new System.Drawing.Point(152, 77);
			this.comboBoxLocationNameClass.Name = "comboBoxLocationNameClass";
			this.comboBoxLocationNameClass.Size = new System.Drawing.Size(116, 21);
			this.comboBoxLocationNameClass.TabIndex = 49;
			this.comboBoxLocationNameClass.Text = "OUTPUT";
			// 
			// textBoxNameClass
			// 
			this.textBoxNameClass.Location = new System.Drawing.Point(3, 119);
			this.textBoxNameClass.Name = "textBoxNameClass";
			this.textBoxNameClass.Size = new System.Drawing.Size(265, 20);
			this.textBoxNameClass.TabIndex = 48;
			// 
			// comboBoxType
			// 
			this.comboBoxType.FormattingEnabled = true;
			this.comboBoxType.Items.AddRange(new object[] {
			"CLASS",
			"ID"});
			this.comboBoxType.Location = new System.Drawing.Point(88, 76);
			this.comboBoxType.Name = "comboBoxType";
			this.comboBoxType.Size = new System.Drawing.Size(58, 21);
			this.comboBoxType.TabIndex = 47;
			this.comboBoxType.Text = "CLASS";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(88, 58);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(58, 18);
			this.label7.TabIndex = 46;
			this.label7.Text = "Тип";
			// 
			// comboBoxTeg
			// 
			this.comboBoxTeg.FormattingEnabled = true;
			this.comboBoxTeg.Items.AddRange(new object[] {
			"SPAN",
			"DIV",
			"TD",
			"TR",
			"TABLE",
			"A",
			"IMG",
			"TITLE",
			"HEAD",
			"P",
			"CENTER",
			"FONT",
			"H1",
			"H2",
			"H3",
			"H4",
			"H5",
			"H6",
			"H7"});
			this.comboBoxTeg.Location = new System.Drawing.Point(3, 76);
			this.comboBoxTeg.Name = "comboBoxTeg";
			this.comboBoxTeg.Size = new System.Drawing.Size(59, 21);
			this.comboBoxTeg.TabIndex = 45;
			this.comboBoxTeg.Text = "SPAN";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(3, 60);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(59, 11);
			this.label6.TabIndex = 44;
			this.label6.Text = "Tag";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.groupBox1);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(345, 411);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Network";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.listBoxProxi);
			this.groupBox1.Controls.Add(this.buttonDeleteProxi);
			this.groupBox1.Controls.Add(this.buttonAddProxi);
			this.groupBox1.Controls.Add(this.textBoxProxi);
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(234, 399);
			this.groupBox1.TabIndex = 47;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Proxi : prot";
			// 
			// listBoxProxi
			// 
			this.listBoxProxi.FormattingEnabled = true;
			this.listBoxProxi.Location = new System.Drawing.Point(6, 68);
			this.listBoxProxi.Name = "listBoxProxi";
			this.listBoxProxi.Size = new System.Drawing.Size(211, 316);
			this.listBoxProxi.TabIndex = 32;
			// 
			// buttonDeleteProxi
			// 
			this.buttonDeleteProxi.Location = new System.Drawing.Point(148, 41);
			this.buttonDeleteProxi.Name = "buttonDeleteProxi";
			this.buttonDeleteProxi.Size = new System.Drawing.Size(75, 23);
			this.buttonDeleteProxi.TabIndex = 31;
			this.buttonDeleteProxi.Text = "Delete";
			this.buttonDeleteProxi.UseVisualStyleBackColor = true;
			this.buttonDeleteProxi.Click += new System.EventHandler(this.ButtonDeleteProxiClick);
			// 
			// buttonAddProxi
			// 
			this.buttonAddProxi.Location = new System.Drawing.Point(6, 41);
			this.buttonAddProxi.Name = "buttonAddProxi";
			this.buttonAddProxi.Size = new System.Drawing.Size(75, 23);
			this.buttonAddProxi.TabIndex = 30;
			this.buttonAddProxi.Text = "Add";
			this.buttonAddProxi.UseVisualStyleBackColor = true;
			this.buttonAddProxi.Click += new System.EventHandler(this.ButtonAddProxiClick);
			// 
			// textBoxProxi
			// 
			this.textBoxProxi.Location = new System.Drawing.Point(6, 18);
			this.textBoxProxi.Name = "textBoxProxi";
			this.textBoxProxi.Size = new System.Drawing.Size(217, 20);
			this.textBoxProxi.TabIndex = 27;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.label21);
			this.tabPage4.Controls.Add(this.label20);
			this.tabPage4.Controls.Add(this.MaxFileSizenumericUpDown2);
			this.tabPage4.Controls.Add(this.label19);
			this.tabPage4.Controls.Add(this.label18);
			this.tabPage4.Controls.Add(this.MinFileSizenumericUpDown1);
			this.tabPage4.Controls.Add(this.label17);
			this.tabPage4.Controls.Add(this.label16);
			this.tabPage4.Controls.Add(this.button1);
			this.tabPage4.Controls.Add(this.PathLoadIMGBox1textBox1);
			this.tabPage4.Controls.Add(this.label15);
			this.tabPage4.Controls.Add(this.DirSaveImgcomboBox1);
			this.tabPage4.Controls.Add(this.checkBoxLoadFile);
			this.tabPage4.Controls.Add(this.checkedListLoadFile);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(345, 411);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Files";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.tabPage4.Click += new System.EventHandler(this.TabPage4Click);
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(134, 134);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(155, 23);
			this.label21.TabIndex = 50;
			this.label21.Text = "0 - no restrictions";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(251, 106);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(51, 23);
			this.label20.TabIndex = 49;
			this.label20.Text = "Kbait";
			// 
			// MaxFileSizenumericUpDown2
			// 
			this.MaxFileSizenumericUpDown2.Location = new System.Drawing.Point(134, 104);
			this.MaxFileSizenumericUpDown2.Maximum = new decimal(new int[] {
			1874919424,
			2328306,
			0,
			0});
			this.MaxFileSizenumericUpDown2.Name = "MaxFileSizenumericUpDown2";
			this.MaxFileSizenumericUpDown2.Size = new System.Drawing.Size(111, 20);
			this.MaxFileSizenumericUpDown2.TabIndex = 48;
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(134, 85);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(54, 23);
			this.label19.TabIndex = 47;
			this.label19.Text = "before";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(251, 62);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(64, 20);
			this.label18.TabIndex = 46;
			this.label18.Text = "Kbait";
			// 
			// MinFileSizenumericUpDown1
			// 
			this.MinFileSizenumericUpDown1.Location = new System.Drawing.Point(134, 62);
			this.MinFileSizenumericUpDown1.Maximum = new decimal(new int[] {
			1874919424,
			2328306,
			0,
			0});
			this.MinFileSizenumericUpDown1.Name = "MinFileSizenumericUpDown1";
			this.MinFileSizenumericUpDown1.Size = new System.Drawing.Size(111, 20);
			this.MinFileSizenumericUpDown1.TabIndex = 45;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(134, 36);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(155, 23);
			this.label17.TabIndex = 44;
			this.label17.Text = "Files of size from ";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(6, 348);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(198, 21);
			this.label16.TabIndex = 43;
			this.label16.Text = "Save directory";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(240, 369);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 42;
			this.button1.Text = "Select";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// PathLoadIMGBox1textBox1
			// 
			this.PathLoadIMGBox1textBox1.Enabled = false;
			this.PathLoadIMGBox1textBox1.Location = new System.Drawing.Point(6, 372);
			this.PathLoadIMGBox1textBox1.Name = "PathLoadIMGBox1textBox1";
			this.PathLoadIMGBox1textBox1.Size = new System.Drawing.Size(228, 20);
			this.PathLoadIMGBox1textBox1.TabIndex = 41;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(3, 226);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(170, 23);
			this.label15.TabIndex = 40;
			this.label15.Text = "Save subdirectory";
			// 
			// DirSaveImgcomboBox1
			// 
			this.DirSaveImgcomboBox1.FormattingEnabled = true;
			this.DirSaveImgcomboBox1.Items.AddRange(new object[] {
			"Root",
			"id pages",
			"Name of the placement page"});
			this.DirSaveImgcomboBox1.Location = new System.Drawing.Point(6, 252);
			this.DirSaveImgcomboBox1.Name = "DirSaveImgcomboBox1";
			this.DirSaveImgcomboBox1.Size = new System.Drawing.Size(150, 21);
			this.DirSaveImgcomboBox1.TabIndex = 39;
			this.DirSaveImgcomboBox1.Text = "Root";
			// 
			// checkBoxLoadFile
			// 
			this.checkBoxLoadFile.Location = new System.Drawing.Point(6, 6);
			this.checkBoxLoadFile.Name = "checkBoxLoadFile";
			this.checkBoxLoadFile.Size = new System.Drawing.Size(283, 24);
			this.checkBoxLoadFile.TabIndex = 38;
			this.checkBoxLoadFile.Text = "Download embedded images";
			this.checkBoxLoadFile.UseVisualStyleBackColor = true;
			// 
			// checkedListLoadFile
			// 
			this.checkedListLoadFile.Items.AddRange(new object[] {
			"JPEG",
			"JPG",
			"PNG",
			"PDF",
			"DOC",
			"DOCX",
			"RAR",
			"ZIP",
			"XLS",
			"XLSX"});
			this.checkedListLoadFile.Location = new System.Drawing.Point(3, 36);
			this.checkedListLoadFile.Name = "checkedListLoadFile";
			this.checkedListLoadFile.Size = new System.Drawing.Size(118, 154);
			this.checkedListLoadFile.TabIndex = 37;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.Selectbutton1);
			this.tabPage5.Controls.Add(this.label12);
			this.tabPage5.Controls.Add(this.pathAutoExporttextBox1);
			this.tabPage5.Controls.Add(this.DeleteBlockImportbutton1);
			this.tabPage5.Controls.Add(this.label14);
			this.tabPage5.Controls.Add(this.AddBlocImportbutton1);
			this.tabPage5.Controls.Add(this.ListXMLImportcheckedListBox1);
			this.tabPage5.Controls.Add(this.label13);
			this.tabPage5.Controls.Add(this.NameBlockImportcomboBox1);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage5.Size = new System.Drawing.Size(345, 411);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Auto-upload";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// Selectbutton1
			// 
			this.Selectbutton1.Location = new System.Drawing.Point(207, 362);
			this.Selectbutton1.Margin = new System.Windows.Forms.Padding(2);
			this.Selectbutton1.Name = "Selectbutton1";
			this.Selectbutton1.Size = new System.Drawing.Size(100, 24);
			this.Selectbutton1.TabIndex = 67;
			this.Selectbutton1.Text = "Select";
			this.Selectbutton1.UseVisualStyleBackColor = true;
			this.Selectbutton1.Click += new System.EventHandler(this.Selectbutton1Click);
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(18, 344);
			this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(226, 17);
			this.label12.TabIndex = 66;
			this.label12.Text = "Automatic import path";
			// 
			// pathAutoExporttextBox1
			// 
			this.pathAutoExporttextBox1.Enabled = false;
			this.pathAutoExporttextBox1.Location = new System.Drawing.Point(18, 366);
			this.pathAutoExporttextBox1.Margin = new System.Windows.Forms.Padding(2);
			this.pathAutoExporttextBox1.Name = "pathAutoExporttextBox1";
			this.pathAutoExporttextBox1.Size = new System.Drawing.Size(185, 20);
			this.pathAutoExporttextBox1.TabIndex = 65;
			// 
			// DeleteBlockImportbutton1
			// 
			this.DeleteBlockImportbutton1.Location = new System.Drawing.Point(211, 88);
			this.DeleteBlockImportbutton1.Margin = new System.Windows.Forms.Padding(2);
			this.DeleteBlockImportbutton1.Name = "DeleteBlockImportbutton1";
			this.DeleteBlockImportbutton1.Size = new System.Drawing.Size(56, 27);
			this.DeleteBlockImportbutton1.TabIndex = 5;
			this.DeleteBlockImportbutton1.Text = "Delete";
			this.DeleteBlockImportbutton1.UseVisualStyleBackColor = true;
			this.DeleteBlockImportbutton1.Click += new System.EventHandler(this.DeleteBlockImportbutton1Click);
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(18, 11);
			this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(271, 28);
			this.label14.TabIndex = 4;
			this.label14.Text = "Blocks of information to be saved in the imporet file";
			// 
			// AddBlocImportbutton1
			// 
			this.AddBlocImportbutton1.Location = new System.Drawing.Point(18, 85);
			this.AddBlocImportbutton1.Margin = new System.Windows.Forms.Padding(2);
			this.AddBlocImportbutton1.Name = "AddBlocImportbutton1";
			this.AddBlocImportbutton1.Size = new System.Drawing.Size(69, 22);
			this.AddBlocImportbutton1.TabIndex = 3;
			this.AddBlocImportbutton1.Text = "Add";
			this.AddBlocImportbutton1.UseVisualStyleBackColor = true;
			this.AddBlocImportbutton1.Click += new System.EventHandler(this.AddBlocImportbutton1Click);
			// 
			// ListXMLImportcheckedListBox1
			// 
			this.ListXMLImportcheckedListBox1.FormattingEnabled = true;
			this.ListXMLImportcheckedListBox1.Location = new System.Drawing.Point(18, 119);
			this.ListXMLImportcheckedListBox1.Margin = new System.Windows.Forms.Padding(2);
			this.ListXMLImportcheckedListBox1.Name = "ListXMLImportcheckedListBox1";
			this.ListXMLImportcheckedListBox1.Size = new System.Drawing.Size(249, 184);
			this.ListXMLImportcheckedListBox1.TabIndex = 2;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(18, 39);
			this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(154, 19);
			this.label13.TabIndex = 1;
			this.label13.Text = "Name block";
			// 
			// NameBlockImportcomboBox1
			// 
			this.NameBlockImportcomboBox1.FormattingEnabled = true;
			this.NameBlockImportcomboBox1.Location = new System.Drawing.Point(18, 60);
			this.NameBlockImportcomboBox1.Margin = new System.Windows.Forms.Padding(2);
			this.NameBlockImportcomboBox1.Name = "NameBlockImportcomboBox1";
			this.NameBlockImportcomboBox1.Size = new System.Drawing.Size(249, 21);
			this.NameBlockImportcomboBox1.TabIndex = 0;
			// 
			// FormConfiguration
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(378, 495);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonSaveProject);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormConfiguration";
			this.Text = "Configuration";
			this.Load += new System.EventHandler(this.FormConfigurationLoad);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.immersionDepthnumericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.theFrequencyOfnumericUpDown1)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.MaxFileSizenumericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MinFileSizenumericUpDown1)).EndInit();
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.ResumeLayout(false);

		}

		}
	}

