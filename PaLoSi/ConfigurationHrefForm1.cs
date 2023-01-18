/*
 * Создано в SharpDevelop.
 * Пользователь: АРМ162
 * Дата: 29.01.2020
 * Время: 11:43
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PaLoSi
{
	/// <summary>
	/// Description of ConfigurationHrefForm1.
	/// </summary>
public partial class ConfigurationHrefForm1 : Form{
TextBox txt=new TextBox();
public ConfigurationHrefForm1(){
	InitializeComponent();
}
public ConfigurationHrefForm1(TextBox ViewHreftextBox1){
	InitializeComponent();
	txt=ViewHreftextBox1;
}	
void Button1Click(object sender, EventArgs e){
	if((TypeHrefcomboBox1.Text.Length>0)&&(NameClassHreftextBox1.Text.Length>0))
	txt.Text="//a [@"+TypeHrefcomboBox1.Text+"='"+NameClassHreftextBox1.Text+"']";
	this.Close();
}
void Defaultbutton3Click(object sender, EventArgs e){
	TypeHrefcomboBox1.Text="";
	NameClassHreftextBox1.Text="";
	txt.Text="//a";
}
void Closebutton2Click(object sender, EventArgs e){
	this.Close();
}
	}
}
