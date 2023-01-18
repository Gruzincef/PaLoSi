/*
 * Создано в SharpDevelop.
 * Пользователь: Белый Господин
 * Дата: 02.05.2020
 * Время: 12:54
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace PaLoSi
{
	/// <summary>
	/// Description of LicensKeу.
	/// </summary>
	public partial class LicensKey : Form
	{
		public LicensKey()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			richTextBox1.Text=RsaWithCspKey.CryptoKey(Work.Protector());
			if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PaLoSi\Licens.bin")){
				richTextBox2.Text=File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PaLoSi\Licens.bin", Encoding.Default);
				Activation();
			}
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
void Button1Click(object sender, EventArgs e){
	Activation();
}
public void Activation(){
string	 s= richTextBox2.Text;	
	if(Work.Licens(s)){
	if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PaLoSi\Licens.bin")) File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PaLoSi\Licens.bin");
		File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PaLoSi\Licens.bin",s);
		label3.Text="The program is activated";
	}else label3.Text="The key didn't fit";			
			
}
void Button2Click(object sender, EventArgs e){
	if(saveFileDialog1.ShowDialog()==DialogResult.OK)
		File.WriteAllText(saveFileDialog1.FileName,richTextBox1.Text);
}
void Button3Click(object sender, EventArgs e){
	openFileDialog1.Filter="Project (*.key)|*.key";
	openFileDialog1.FilterIndex=1;
	openFileDialog1.RestoreDirectory=true;
if(openFileDialog1.ShowDialog()==DialogResult.OK)
		richTextBox2.Text=File.ReadAllText(openFileDialog1.FileName, Encoding.Default);
}
void Button4Click(object sender, EventArgs e){
	LicenseText frm=new LicenseText("opisanie.mht");
	frm.Show(this);
}
		
		
	}
}
