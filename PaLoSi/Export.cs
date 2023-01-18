/*
 * Создано в SharpDevelop.
 * Пользователь: Белый Господин
 * Дата: 08.03.2020
 * Время: 17:52
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading;

namespace PaLoSi
{
	/// <summary>
	/// Description of Export.
	/// </summary>

public class Export: Threaders{
	private VarExportFile VrExprtFl =new VarExportFile();
	private ListSites.Project Prjct =new ListSites.Project();
	private Export()	{
	}
	public Export(VarExportFile vrExprtFl,ListSites.Project prjct){
		Prjct=prjct;
		VrExprtFl=vrExprtFl;
	}

	private MenegerEvent ME=MenegerEvent.getInstance();
	private EVENT_TYPE StatusThreading;
	private Thread Threading;

public void	AutoExportInXMLThreading(){
		StringBuilder str=new StringBuilder();
	DataTable RdQr;
	ME.SetEvent(EVENT_TYPE.SAVE,"Сохранение проекта "+Prjct.nameProject,Prjct.nameProject,Prjct.nameThreading);
	if(Prjct.AllLoad) RdQr=Save.SqlRead(Prjct.nameThreading,"SELECT * FROM "+Prjct.nameThreading+" WHERE export=true");
	else RdQr=Save.SqlRead(Prjct.nameThreading,"SELECT * FROM "+Prjct.nameThreading+" WHERE export=false");
	str.Append("<?xml version=\"1.0\" encoding=\"utf-16\"?><project xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><project><nameproject>"+Prjct.nameProject+"</nameproject>");
		for(int j=0;j<RdQr.Rows.Count;j++){
			string s=RdQr.Rows[j]["xml"].ToString();
			if(s.Length>0){
				str.Append("<data><href>"+RdQr.Rows[j]["href"].ToString()+"</href>");
				ME.SetEvent(EVENT_TYPE.SAVE,"Сохранение "+Prjct.nameProject,Prjct.nameProject,Prjct.nameThreading);
				XmlDocument doc=new XmlDocument();
				if(File.Exists("log.txt")) File.Delete("log.txt");
				File.AppendAllText("log.txt", s, Encoding.Unicode);
				doc.LoadXml(s);
				XmlNode head=doc.SelectSingleNode("/bloc");
				foreach(XmlNode  node in head.ChildNodes){
					if( Prjct.nameBlocFileExportXML.IndexOf(node.Name.ToString())>-1)
						str.Append("<"+node.Name+">"+System.Net.WebUtility.HtmlDecode(node.InnerXml)+"<"+node.Name+">");
				}
				str.Append("</data>");
				Save.SqlQuery(Prjct.nameThreading, "UPDATE  "+Prjct.nameThreading+" SET export=true where Href='"+RdQr.Rows[j]["href"].ToString()+"'" );
			}
			if(StatusThreading==EVENT_TYPE.STOP) break;
		}
	str.Append("</project>");
		if(File.Exists (Prjct.pathAutoExport+"\\"+Prjct.nameProject+".XML")) File.Delete(VrExprtFl.path+"\\"+Prjct.nameProject+".XML");
		File.WriteAllText(Prjct.pathAutoExport+"\\"+Prjct.nameProject+".XML",str.ToString());
		ME.SetEvent(EVENT_TYPE.ENDSAVE,"Завершено сохранение проекта "+Prjct.nameProject,Prjct.nameProject,Prjct.nameThreading);
}


public void ExportFileXml(object qr){
	StringBuilder str=new StringBuilder();
	ME.SetEvent(EVENT_TYPE.SAVE,"Экспорт проекта "+Prjct.nameProject,Prjct.nameProject,Prjct.nameThreading);
	DataTable RdQr=Save.SqlRead(Prjct.nameThreading, (string)qr);
	str.Append("<?xml version=\"1.0\" encoding=\"utf-16\"?><project xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><nameproject>"+Prjct.nameProject+"</nameproject>");
	
	for(int j=0;j<RdQr.Rows.Count;j++){
		ME.SetEvent(EVENT_TYPE.SAVE,"Экспорт  "+Prjct.nameProject,Prjct.nameProject,Prjct.nameThreading);
		str.Append("<data>\r");
		for(int k=0;k<RdQr.Rows[j].ItemArray.Length;k++)
			str.Append("<"+RdQr.Columns[k].ColumnName+">"+RdQr.Rows[j][RdQr.Columns[k].ColumnName]+"</"+RdQr.Columns[k].ColumnName+">\r\n");
		str.Append("</data>\r");
		if(StatusThreading==EVENT_TYPE.STOP){
			ME.SetEvent(EVENT_TYPE.STOPLOAD,"Экспорт остановлен "+Prjct.nameProject,Prjct.nameProject,Prjct.nameThreading);
			break;
		}
 	}
	str.Append("</project>");
	if(File.Exists (VrExprtFl.path+"\\"+Prjct.nameProject+".XML")) File.Delete(VrExprtFl.path+"\\"+Prjct.nameThreading+".XML");
	File.WriteAllText(VrExprtFl.path+"\\"+Prjct.nameProject+".XML",str.ToString());
	ME.SetEvent(EVENT_TYPE.ENDSAVE,"Экспорт завершен "+Prjct.nameProject,Prjct.nameProject,Prjct.nameThreading);
}
public void ExportFileTxt(object qr){
		StringBuilder str=new StringBuilder();
	ME.SetEvent(EVENT_TYPE.SAVE,"Экспорт проекта "+Prjct.nameProject,Prjct.nameProject,Prjct.nameThreading);
	DataTable RdQr=Save.SqlRead(Prjct.nameThreading, (string)qr);
	str.Append(Prjct.nameProject);
	for(int j=0;j<RdQr.Rows.Count;j++){
		ME.SetEvent(EVENT_TYPE.SAVE,"Экспорт  "+Prjct.nameProject,Prjct.nameProject,Prjct.nameThreading);
		str.Append("\r");
		for(int k=0;k<RdQr.Rows[j].ItemArray.Length;k++)
			str.Append(RdQr.Rows[j][RdQr.Columns[k].ColumnName]+"\r");
		if(StatusThreading==EVENT_TYPE.STOP){
			ME.SetEvent(EVENT_TYPE.STOPLOAD,"Экспорт остановлен "+Prjct.nameProject,Prjct.nameProject,Prjct.nameThreading);
			break;
		}
 	}
	if(File.Exists (VrExprtFl.path+"\\"+Prjct.nameProject+".TXT")) File.Delete(VrExprtFl.path+"\\"+Prjct.nameThreading+".TXT");
	File.WriteAllText(VrExprtFl.path+"\\"+Prjct.nameProject+".TXT",str.ToString());
	ME.SetEvent(EVENT_TYPE.ENDSAVE,"Экспорт завершен "+Prjct.nameProject,Prjct.nameProject,Prjct.nameThreading);
}
public void ExportFileHtml(object qr){
		StringBuilder str=new StringBuilder();
	ME.SetEvent(EVENT_TYPE.SAVE,"Экспорт проекта "+Prjct.nameProject,Prjct.nameProject,Prjct.nameThreading);
	DataTable RdQr=Save.SqlRead(Prjct.nameThreading, (string)qr);
	str.Append("<BODY><H1>"+Prjct.nameProject+"</H1><TABLE>");
	for(int j=0;j<RdQr.Rows.Count;j++){
		ME.SetEvent(EVENT_TYPE.SAVE,"Экспорт  "+Prjct.nameProject,Prjct.nameProject,Prjct.nameThreading);
		str.Append("<TR>");
		for(int k=0;k<RdQr.Rows[j].ItemArray.Length;k++)
			str.Append("<TD>"+RdQr.Rows[j][RdQr.Columns[k].ColumnName]+"</TD>");
		str.Append("</TR>");
		if(StatusThreading==EVENT_TYPE.STOP){
			ME.SetEvent(EVENT_TYPE.STOPLOAD,"Экспорт остановлен "+Prjct.nameProject,Prjct.nameProject,Prjct.nameThreading);
			break;
		}
 	}
	str.Append("</TABLE></<BODY>");
	if(File.Exists (VrExprtFl.path+"\\"+Prjct.nameProject+".HTML")) File.Delete(VrExprtFl.path+"\\"+Prjct.nameThreading+".HTML");
	File.WriteAllText(VrExprtFl.path+"\\"+Prjct.nameProject+".HTML",str.ToString());
	ME.SetEvent(EVENT_TYPE.ENDSAVE,"Экспорт завершен "+Prjct.nameProject,Prjct.nameProject,Prjct.nameThreading);
}
public void	StartThreadExport(){
		string query="";
		StatusThreading=EVENT_TYPE.START;
	if(VrExprtFl.WhatLoadId==0) query="SELECT href,title,txthref,dateload,xml FROM "+Prjct.nameThreading;
	if(VrExprtFl.WhatLoadId==1) query="SELECT href,txthref FROM "+Prjct.nameThreading+" WHERE document=true";
	if(VrExprtFl.WhatLoadId==2) query="SELECT href,txthref FROM "+Prjct.nameThreading+" WHERE document=false";
	if(VrExprtFl.WhatLoadId==3) query="SELECT href,txthref FROM "+Prjct.nameThreading+" WHERE document=false AND error=false";
	if(VrExprtFl.WhatLoadId==4) query="SELECT tb2.href as root_href, tb2.txthref as root_texthref , tb2.title as root_title, tb1.href as error_href ,tb1.txthref as error_txthref  FROM "+Prjct.nameThreading+" as tb1, "+Prjct.nameThreading+" as tb2 WHERE tb1.error=true and tb2.id=tb1.idcategory";
	if(VrExprtFl.WhatLoadId==5) query="SELECT href,title,xml txthref  FROM "+Prjct.nameThreading+" WHERE error=false";

	if(VrExprtFl.GetTypeString()=="XML")	Threading=StartThead(ExportFileXml,(object)query);
	if(VrExprtFl.GetTypeString()=="TXT")	Threading=StartThead(ExportFileTxt,(object)query);
	if(VrExprtFl.GetTypeString()=="HTML")	Threading=StartThead(ExportFileHtml,(object)query);
}	

public void StopExport(){
	if(Threading.IsAlive){
		StatusThreading=EVENT_TYPE.STOP;
		AbortThead(100);
	}
	
}
	
/*****************/	
}
}
