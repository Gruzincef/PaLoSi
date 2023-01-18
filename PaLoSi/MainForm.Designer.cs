/*
 * Создано в SharpDevelop.
 * Пользователь: Белый Господин
 * Дата: 04.01.2020
 * Время: 20:55
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
namespace PaLoSi
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label labelMessage;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem ProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem LoadToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem UpdateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem LoadAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem LoadSelectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem StopAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem StopSelectToolStripMenuItem;
		private System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.RichTextBox LogrichTextBox1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem infoBlockToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem errorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ClearHistoryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ActivationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem OpisToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem LicensToolStripMenuItem;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		/*
		private System.Windows.Forms.ToolStripMenuItem ImportToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem cSVToolStripMenuItem12;
		private System.Windows.Forms.ToolStripMenuItem sytemapToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem12;
		private System.Windows.Forms.ToolStripMenuItem htmlToolStripMenuItem1;*/
		private System.Windows.Forms.ToolStripMenuItem exchangeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
		//private System.Windows.Forms.ToolStripMenuItem exchangeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ImportToolStripMenuItem;
		//private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem cSVToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sytemapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem htmlToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem xMLToolStripMenuItem;
		
		
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.LogrichTextBox1 = new System.Windows.Forms.RichTextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.labelMessage = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.ProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.UpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DeleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.ClearHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LoadAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LoadSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.StopAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.StopSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exchangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.cSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sytemapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.xMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.htmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.infoBlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.errorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ActivationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LicensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(196, 50);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(555, 454);
			this.tabControl1.TabIndex = 0;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.LogrichTextBox1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(547, 428);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "History";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// LogrichTextBox1
			// 
			this.LogrichTextBox1.Location = new System.Drawing.Point(2, 5);
			this.LogrichTextBox1.Margin = new System.Windows.Forms.Padding(2);
			this.LogrichTextBox1.Name = "LogrichTextBox1";
			this.LogrichTextBox1.ReadOnly = true;
			this.LogrichTextBox1.Size = new System.Drawing.Size(542, 418);
			this.LogrichTextBox1.TabIndex = 0;
			this.LogrichTextBox1.Text = "History";
			// 
			// tabPage2
			// 
			this.tabPage2.AutoScroll = true;
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(547, 428);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Information";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// progressBar1
			// 
			this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.progressBar1.Location = new System.Drawing.Point(0, 542);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(763, 23);
			this.progressBar1.TabIndex = 1;
			// 
			// labelMessage
			// 
			this.labelMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.labelMessage.Location = new System.Drawing.Point(0, 521);
			this.labelMessage.Name = "labelMessage";
			this.labelMessage.Size = new System.Drawing.Size(763, 21);
			this.labelMessage.TabIndex = 2;
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ProjectToolStripMenuItem,
			this.LoadToolStripMenuItem,
			this.exchangeToolStripMenuItem,
			this.viewToolStripMenuItem,
			this.HelpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(763, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// ProjectToolStripMenuItem
			// 
			this.ProjectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.AddToolStripMenuItem,
			this.UpdateToolStripMenuItem,
			this.DeleteToolStripMenuItem1,
			this.ClearHistoryToolStripMenuItem});
			this.ProjectToolStripMenuItem.Name = "ProjectToolStripMenuItem";
			this.ProjectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.ProjectToolStripMenuItem.Text = "Project";
			// 
			// AddToolStripMenuItem
			// 
			this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
			this.AddToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
			this.AddToolStripMenuItem.Text = "Add";
			this.AddToolStripMenuItem.Click += new System.EventHandler(this.AddToolStripMenuItemClick);
			// 
			// UpdateToolStripMenuItem
			// 
			this.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem";
			this.UpdateToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
			this.UpdateToolStripMenuItem.Text = "Update";
			this.UpdateToolStripMenuItem.Click += new System.EventHandler(this.UpdateToolStripMenuItemClick);
			// 
			// DeleteToolStripMenuItem1
			// 
			this.DeleteToolStripMenuItem1.Name = "DeleteToolStripMenuItem1";
			this.DeleteToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
			this.DeleteToolStripMenuItem1.Text = "Delete";
			this.DeleteToolStripMenuItem1.Click += new System.EventHandler(this.DeleteToolStripMenuItem1Click);
			// 
			// ClearHistoryToolStripMenuItem
			// 
			this.ClearHistoryToolStripMenuItem.Name = "ClearHistoryToolStripMenuItem";
			this.ClearHistoryToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
			this.ClearHistoryToolStripMenuItem.Text = "Clear history";
			this.ClearHistoryToolStripMenuItem.Click += new System.EventHandler(this.ClearHistoryToolStripMenuItemClick);
			// 
			// LoadToolStripMenuItem
			// 
			this.LoadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.LoadAllToolStripMenuItem,
			this.LoadSelectToolStripMenuItem,
			this.StopAllToolStripMenuItem,
			this.StopSelectToolStripMenuItem});
			this.LoadToolStripMenuItem.Name = "LoadToolStripMenuItem";
			this.LoadToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
			this.LoadToolStripMenuItem.Text = "Start";
			// 
			// LoadAllToolStripMenuItem
			// 
			this.LoadAllToolStripMenuItem.Name = "LoadAllToolStripMenuItem";
			this.LoadAllToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.LoadAllToolStripMenuItem.Text = "Download all";
			this.LoadAllToolStripMenuItem.Click += new System.EventHandler(this.LoadAllToolStripMenuItemClick);
			// 
			// LoadSelectToolStripMenuItem
			// 
			this.LoadSelectToolStripMenuItem.Name = "LoadSelectToolStripMenuItem";
			this.LoadSelectToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.LoadSelectToolStripMenuItem.Text = "Upload a selection";
			this.LoadSelectToolStripMenuItem.Click += new System.EventHandler(this.LoadSelectToolStripMenuItemClick);
			// 
			// StopAllToolStripMenuItem
			// 
			this.StopAllToolStripMenuItem.Name = "StopAllToolStripMenuItem";
			this.StopAllToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.StopAllToolStripMenuItem.Text = "Stop everything";
			this.StopAllToolStripMenuItem.Click += new System.EventHandler(this.StopAllToolStripMenuItemClick);
			// 
			// StopSelectToolStripMenuItem
			// 
			this.StopSelectToolStripMenuItem.Name = "StopSelectToolStripMenuItem";
			this.StopSelectToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.StopSelectToolStripMenuItem.Text = "Stop selected";
			this.StopSelectToolStripMenuItem.Click += new System.EventHandler(this.StopSelectToolStripMenuItemClick);
			// 
			// exchangeToolStripMenuItem
			// 
			this.exchangeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ImportToolStripMenuItem,
			this.exportToolStripMenuItem1});
			this.exchangeToolStripMenuItem.Name = "exchangeToolStripMenuItem";
			this.exchangeToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
			this.exchangeToolStripMenuItem.Text = "Exchange";
			// 
			// ImportToolStripMenuItem
			// 
			this.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem";
			this.ImportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
			this.ImportToolStripMenuItem.Text = "Import";
			this.ImportToolStripMenuItem.Click += new System.EventHandler(this.ImportToolStripMenuItemClick);
			// 
			// exportToolStripMenuItem1
			// 
			this.exportToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.cSVToolStripMenuItem,
			this.sytemapToolStripMenuItem,
			this.xMLToolStripMenuItem,
			this.htmlToolStripMenuItem});
			this.exportToolStripMenuItem1.Name = "exportToolStripMenuItem1";
			this.exportToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
			this.exportToolStripMenuItem1.Text = "Export";
			// 
			// cSVToolStripMenuItem
			// 
			this.cSVToolStripMenuItem.Name = "cSVToolStripMenuItem";
			this.cSVToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
			this.cSVToolStripMenuItem.Text = "Upload everything";
			this.cSVToolStripMenuItem.Click += new System.EventHandler(this.CSVToolStripMenuItemClick);
			// 
			// sytemapToolStripMenuItem
			// 
			this.sytemapToolStripMenuItem.Name = "sytemapToolStripMenuItem";
			this.sytemapToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
			this.sytemapToolStripMenuItem.Text = "To upload a selected";
			this.sytemapToolStripMenuItem.Click += new System.EventHandler(this.SytemapToolStripMenuItemClick);
			// 
			// xMLToolStripMenuItem
			// 
			this.xMLToolStripMenuItem.Name = "xMLToolStripMenuItem";
			this.xMLToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
			this.xMLToolStripMenuItem.Text = "Stop everything";
			this.xMLToolStripMenuItem.Click += new System.EventHandler(this.XMLToolStripMenuItemClick);
			// 
			// htmlToolStripMenuItem
			// 
			this.htmlToolStripMenuItem.Name = "htmlToolStripMenuItem";
			this.htmlToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
			this.htmlToolStripMenuItem.Text = "Stop selected";
			this.htmlToolStripMenuItem.Click += new System.EventHandler(this.HtmlToolStripMenuItemClick);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.infoBlockToolStripMenuItem,
			this.errorToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// infoBlockToolStripMenuItem
			// 
			this.infoBlockToolStripMenuItem.Name = "infoBlockToolStripMenuItem";
			this.infoBlockToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.infoBlockToolStripMenuItem.Text = "Information";
			this.infoBlockToolStripMenuItem.Click += new System.EventHandler(this.InfoBlockToolStripMenuItemClick);
			// 
			// errorToolStripMenuItem
			// 
			this.errorToolStripMenuItem.Name = "errorToolStripMenuItem";
			this.errorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.errorToolStripMenuItem.Text = "Not uploaded";
			this.errorToolStripMenuItem.Click += new System.EventHandler(this.ErrorToolStripMenuItemClick);
			// 
			// HelpToolStripMenuItem
			// 
			this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ActivationToolStripMenuItem,
			this.OpisToolStripMenuItem,
			this.LicensToolStripMenuItem});
			this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
			this.HelpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.HelpToolStripMenuItem.Text = "Help";
			// 
			// ActivationToolStripMenuItem
			// 
			this.ActivationToolStripMenuItem.Name = "ActivationToolStripMenuItem";
			this.ActivationToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.ActivationToolStripMenuItem.Text = "Activation";
			this.ActivationToolStripMenuItem.Click += new System.EventHandler(this.ActivationToolStripMenuItemClick);
			// 
			// OpisToolStripMenuItem
			// 
			this.OpisToolStripMenuItem.Name = "OpisToolStripMenuItem";
			this.OpisToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.OpisToolStripMenuItem.Text = "Description";
			this.OpisToolStripMenuItem.Click += new System.EventHandler(this.OpisToolStripMenuItemClick);
			// 
			// LicensToolStripMenuItem
			// 
			this.LicensToolStripMenuItem.Name = "LicensToolStripMenuItem";
			this.LicensToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.LicensToolStripMenuItem.Text = "Licens";
			this.LicensToolStripMenuItem.Click += new System.EventHandler(this.LicensToolStripMenuItemClick);
			// 
			// panel1
			// 
			this.panel1.AutoScroll = true;
			this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.panel1.Location = new System.Drawing.Point(12, 50);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(178, 450);
			this.panel1.TabIndex = 5;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1FileOk);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "PaLoSi";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.DoubleClick += new System.EventHandler(this.NotifyIcon1DoubleClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(763, 565);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.labelMessage);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "PaLoSi";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
			this.Resize += new System.EventHandler(this.MainFormResize);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
