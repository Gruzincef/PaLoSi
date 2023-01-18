/*
 * Создано в SharpDevelop.
 * Пользователь: Белый Господин
 * Дата: 23.02.2020
 * Время: 19:26
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace PaLoSi
{
	partial class ExportForm1
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ComboBox TypecomboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox WhatLoadlistBox1;
		private System.Windows.Forms.CheckBox ExportDifferentFilecheckBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.TextBox PathtextBox1;
		private System.Windows.Forms.Button button2;
		
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
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportForm1));
			this.TypecomboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.WhatLoadlistBox1 = new System.Windows.Forms.ListBox();
			this.ExportDifferentFilecheckBox1 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.PathtextBox1 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TypecomboBox1
			// 
			this.TypecomboBox1.FormattingEnabled = true;
			this.TypecomboBox1.Items.AddRange(new object[] {
			"HTML",
			"XML",
			"TXT"});
			this.TypecomboBox1.Location = new System.Drawing.Point(143, 20);
			this.TypecomboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.TypecomboBox1.Name = "TypecomboBox1";
			this.TypecomboBox1.Size = new System.Drawing.Size(160, 24);
			this.TypecomboBox1.TabIndex = 0;
			this.TypecomboBox1.Text = "XML";
			this.TypecomboBox1.SelectedIndexChanged += new System.EventHandler(this.TypecomboBox1SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(5, 20);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 28);
			this.label1.TabIndex = 1;
			this.label1.Text = "Type file";
			// 
			// WhatLoadlistBox1
			// 
			this.WhatLoadlistBox1.FormattingEnabled = true;
			this.WhatLoadlistBox1.ItemHeight = 16;
			this.WhatLoadlistBox1.Items.AddRange(new object[] {
			"All",
			"List of links to files",
			"Hyperlinks",
			"Inaccessible hyperlinks",
			"Read errors",
			"Information"});
			this.WhatLoadlistBox1.Location = new System.Drawing.Point(385, 15);
			this.WhatLoadlistBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.WhatLoadlistBox1.Name = "WhatLoadlistBox1";
			this.WhatLoadlistBox1.Size = new System.Drawing.Size(264, 244);
			this.WhatLoadlistBox1.TabIndex = 4;
			this.WhatLoadlistBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.WhatLoadlistBox1MouseClick);
			this.WhatLoadlistBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1SelectedIndexChanged);
			this.WhatLoadlistBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WhatLoadlistBox1KeyPress);
			// 
			// ExportDifferentFilecheckBox1
			// 
			this.ExportDifferentFilecheckBox1.Enabled = false;
			this.ExportDifferentFilecheckBox1.Location = new System.Drawing.Point(16, 53);
			this.ExportDifferentFilecheckBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.ExportDifferentFilecheckBox1.Name = "ExportDifferentFilecheckBox1";
			this.ExportDifferentFilecheckBox1.Size = new System.Drawing.Size(288, 30);
			this.ExportDifferentFilecheckBox1.TabIndex = 5;
			this.ExportDifferentFilecheckBox1.Text = "To upload a different file";
			this.ExportDifferentFilecheckBox1.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Enabled = false;
			this.button1.Location = new System.Drawing.Point(16, 297);
			this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 28);
			this.button1.TabIndex = 6;
			this.button1.Text = "Upload";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// PathtextBox1
			// 
			this.PathtextBox1.Enabled = false;
			this.PathtextBox1.Location = new System.Drawing.Point(16, 90);
			this.PathtextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.PathtextBox1.Name = "PathtextBox1";
			this.PathtextBox1.Size = new System.Drawing.Size(340, 22);
			this.PathtextBox1.TabIndex = 7;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(16, 133);
			this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(161, 28);
			this.button2.TabIndex = 8;
			this.button2.Text = "Select a folder";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// ExportForm1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(764, 340);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.PathtextBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.ExportDifferentFilecheckBox1);
			this.Controls.Add(this.WhatLoadlistBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TypecomboBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ExportForm1";
			this.Text = "Export";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
