/*
 * Создано в SharpDevelop.
 * Пользователь: Белый Господин
 * Дата: 23.02.2020
 * Время: 19:26
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace PaLoSi
{
	/// <summary>
	/// Description of ExportForm1.
	/// </summary>
public partial class ExportForm1 : Form{
private MainForm frm;
private VarExportFile VrExprtFlV=new VarExportFile();
private List<string> ListNameThreading=new List<string>();
public ExportForm1(MainForm f){
	frm=f;
	InitializeComponent();
}
public ExportForm1(MainForm f,List<string> st){
	InitializeComponent();
	frm=f;
	ListNameThreading=st;
	PathtextBox1.Text=System.Environment.GetFolderPath(System.Environment.SpecialFolder.UserProfile);
	
}
void TypecomboBox1SelectedIndexChanged(object sender, EventArgs e){
	
}
void ListBox1SelectedIndexChanged(object sender, EventArgs e){
	if(WhatLoadlistBox1.SelectedIndex==5) ExportDifferentFilecheckBox1.Enabled=true;
	else ExportDifferentFilecheckBox1.Enabled=false;
}
void Button1Click(object sender, EventArgs e){
	VrExprtFlV.path=PathtextBox1.Text;
	VrExprtFlV.SetType(TypecomboBox1.Text);
	VrExprtFlV.WhatLoad=WhatLoadlistBox1.SelectedItem.ToString();
	VrExprtFlV.WhatLoadId=WhatLoadlistBox1.SelectedIndex;
	VrExprtFlV.ExportDifferentFile=ExportDifferentFilecheckBox1.Checked;
	if((VrExprtFlV.path.Length>0)&&(VrExprtFlV.GetTypeString().Length>0)&&(VrExprtFlV.WhatLoadId>-1)){
		Work wrk=new Work();
		wrk.Export(VrExprtFlV,ListNameThreading);
		this.Close();
	}
}
void Button2Click(object sender, EventArgs e){
	if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
		PathtextBox1.Text= folderBrowserDialog1.SelectedPath;
	}
void WhatLoadlistBox1KeyPress(object sender, KeyPressEventArgs e){

		}
		void WhatLoadlistBox1MouseClick(object sender, MouseEventArgs e)
		{
	button1.Enabled=true;
		}


	}
}
