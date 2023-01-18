/*
 * Создано в SharpDevelop.
 * Пользователь: Белый Господин
 * Дата: 07.05.2020
 * Время: 19:45
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
namespace PaLoSi
{
	/// <summary>
	/// Description of LicenseText.
	/// </summary>
	public partial class LicenseText : Form
	{
		public LicenseText(string st)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			webBrowser1.Url=new Uri(String.Format("file:////{0}/"+st,System.IO.Directory.GetCurrentDirectory()));
			webBrowser1.ScriptErrorsSuppressed=true;
			if(!File.Exists("Licens.bin"))
				button2.Visible=true;
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
void Button1Click(object sender, EventArgs e){
			this.Close();
		}
void Button2Click(object sender, EventArgs e){	LicensKey frm1=new LicensKey();
	frm1.Show(this);
	
		}
	}
}
