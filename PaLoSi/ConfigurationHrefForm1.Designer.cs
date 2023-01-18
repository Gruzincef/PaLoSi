/*
 * Создано в SharpDevelop.
 * Пользователь: АРМ162
 * Дата: 29.01.2020
 * Время: 11:43
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace PaLoSi
{
	partial class ConfigurationHrefForm1
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ComboBox TypeHrefcomboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox NameClassHreftextBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button Closebutton2;
		private System.Windows.Forms.Button Defaultbutton3;
		
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
			this.TypeHrefcomboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.NameClassHreftextBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.Closebutton2 = new System.Windows.Forms.Button();
			this.Defaultbutton3 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TypeHrefcomboBox1
			// 
			this.TypeHrefcomboBox1.FormattingEnabled = true;
			this.TypeHrefcomboBox1.Items.AddRange(new object[] {
			"class",
			"id"});
			this.TypeHrefcomboBox1.Location = new System.Drawing.Point(100, 10);
			this.TypeHrefcomboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.TypeHrefcomboBox1.Name = "TypeHrefcomboBox1";
			this.TypeHrefcomboBox1.Size = new System.Drawing.Size(61, 21);
			this.TypeHrefcomboBox1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 10);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "Type";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 34);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(151, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "Name class/ID";
			// 
			// NameClassHreftextBox1
			// 
			this.NameClassHreftextBox1.Location = new System.Drawing.Point(9, 53);
			this.NameClassHreftextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.NameClassHreftextBox1.Name = "NameClassHreftextBox1";
			this.NameClassHreftextBox1.Size = new System.Drawing.Size(278, 20);
			this.NameClassHreftextBox1.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(9, 77);
			this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 25);
			this.button1.TabIndex = 4;
			this.button1.Text = "Save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// Closebutton2
			// 
			this.Closebutton2.Location = new System.Drawing.Point(230, 80);
			this.Closebutton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Closebutton2.Name = "Closebutton2";
			this.Closebutton2.Size = new System.Drawing.Size(56, 25);
			this.Closebutton2.TabIndex = 5;
			this.Closebutton2.Text = "Close";
			this.Closebutton2.UseVisualStyleBackColor = true;
			this.Closebutton2.Click += new System.EventHandler(this.Closebutton2Click);
			// 
			// Defaultbutton3
			// 
			this.Defaultbutton3.Location = new System.Drawing.Point(103, 80);
			this.Defaultbutton3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Defaultbutton3.Name = "Defaultbutton3";
			this.Defaultbutton3.Size = new System.Drawing.Size(97, 25);
			this.Defaultbutton3.TabIndex = 6;
			this.Defaultbutton3.Text = "Default";
			this.Defaultbutton3.UseVisualStyleBackColor = true;
			this.Defaultbutton3.Click += new System.EventHandler(this.Defaultbutton3Click);
			// 
			// ConfigurationHrefForm1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(295, 115);
			this.Controls.Add(this.Defaultbutton3);
			this.Controls.Add(this.Closebutton2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.NameClassHreftextBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.TypeHrefcomboBox1);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ConfigurationHrefForm1";
			this.Text = "The configuration of the hyperlink";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
