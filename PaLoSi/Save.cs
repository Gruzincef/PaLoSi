/*
 * Создано в SharpDevelop.
 * Пользователь: Админ
 * Дата: 05.01.2020
 * Время: 18:08
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Data;
using System.Collections;
using System.Threading;

using System.Data.SQLite;
using System.Data.SqlClient;

namespace PaLoSi
{
	/// <summary>
	/// Description of Save.
	/// </summary>
public class Save{
public static string appdata;
public Save(){	
		appdata =  Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PaLoSi\";
	EnabledBlockBD=true;
}

public static bool EnabledBlockBD;

public  struct StructTable {
	public  List<string> Value;
}
public  struct StrctTbl {
	public  string[] Value;
}

public static DataTable SqlRead(string Table, string query){
	EnabledBlockBD=false;
	VerifyBD(Table);
	System.Data.SQLite.SQLiteConnection Connect = new System.Data.SQLite.SQLiteConnection(@"URI=file:"+appdata+"info\\"+Table+"\\"+Table+".pbd");
	System.Data.SQLite.SQLiteCommand command =new	System.Data.SQLite.SQLiteCommand(Connect);
	Connect.Open();
	System.Data.SQLite.SQLiteDataAdapter adapter = new System.Data.SQLite.SQLiteDataAdapter (query, Connect);
	DataSet DS = new DataSet ();
	adapter.Fill(DS);
	adapter.Dispose();
	Connect.Close ();
	command.Dispose ();
	EnabledBlockBD=true;
	if (DS.Tables.Count > 0)
		return DS.Tables [0];
	else
		return null;
}
/********************************************************************/
public static string Serializ(object ob){
	XmlSerializer serializer = new XmlSerializer (ob.GetType());
	XmlWriterSettings ws = new XmlWriterSettings ();
	ws.Encoding = Encoding.UTF8;
	StringBuilder output = new StringBuilder ();
	XmlWriter xmlWriter = XmlWriter.Create (output, ws);
	serializer.Serialize (xmlWriter, ob);
	return output.ToString ();
}
public static object deSerialize(object ob,string s){
	XmlSerializer deserialize = new XmlSerializer (ob.GetType());
	StringReader reader = new StringReader(s);
	return (object)deserialize.Deserialize(reader);
}

public static void SaveConfig(object Data,string NameSave){
	if(!Directory.Exists(appdata+"Config")) 	Directory.CreateDirectory(appdata+"Config");
	if(File.Exists (appdata+"Config//"+NameSave+".pls")) File.Delete(appdata+"Config//"+NameSave+".pls");
	File.WriteAllText(appdata+"Config//"+NameSave+".pls", Serializ (Data));
}

/*************************************************************************************/
public static void SaveProjectInXML(List<Project.project> Data,string NameSave){
	List<Project.project> project=new List<Project.project>();
	Project.project prjct=new Project.project();
	List<string> xml=new List<string>();
	XDocument doc=null;
	XDocument addedDocs=null;
	for(int i=0;i<Data.Count;i++){

		xml.Add(Serializ(Data[i]));
		if(i==0)
			doc=XDocument.Parse(Serializ(Data[i]));
		else{
			addedDocs=XDocument.Parse(Serializ(Data[i]));
			XElement orderData=doc.Descendants("project").FirstOrDefault();
			XElement addedOrderData=addedDocs.Descendants("project").FirstOrDefault();
			List<XElement> children = addedOrderData.Elements().ToList();
			foreach(XElement element in children){
				string tagName=element.Name.LocalName;
				XElement lastElement= orderData.Elements(tagName).LastOrDefault();
				if(lastElement==null){
					orderData.Add(element);
				}else{
					lastElement.ReplaceWith(new XElement[]{lastElement, element});
				}
			}
		}
	}
	if(File.Exists (appdata+NameSave)) File.Delete(appdata+NameSave);
	doc.Save(appdata+NameSave);
}


public static List<object> ReadConfig (object Dt){
	if (Directory.Exists(appdata+"Config")){
		string[] fil=Directory.GetFiles(appdata+"Config//");
		List<object> ob=new List<object>();
		for(int i=0;i<fil.Length;i++)
			if(Path.GetExtension(fil[i]).ToString()==".pls")
			ob.Add(deSerialize (Dt, File.ReadAllText (fil[i])));
		return ob;
	}
	else
		return null;
}

public static object ReadCopyConfig (object Dt,string fil){
		object ob=new object();
		ob=deSerialize (Dt, File.ReadAllText (fil));
		return ob;
}
public static void DeleteFileConfig(string NameSave){
	if(File.Exists (appdata+"Config//"+NameSave+".pls")) File.Delete(appdata+"Config//"+NameSave+".pls");
}

public static void SqlQuery(string Name,string query ){	
	EnabledBlockBD=true;
	System.Data.SQLite.SQLiteConnection Connect = new System.Data.SQLite.SQLiteConnection(@"URI=file:"+appdata+"info\\"+Name+"\\"+Name+".pbd");
	Connect.Open();
	System.Data.SQLite.SQLiteCommand command =new	System.Data.SQLite.SQLiteCommand(query, Connect);
	command.ExecuteNonQuery();
	Connect.Close();
	command.Dispose();
	EnabledBlockBD=true;
}
public static void SqlQuery(string Name,List<string> query ){	
	EnabledBlockBD=true;
	System.Data.SQLite.SQLiteConnection Connect = new System.Data.SQLite.SQLiteConnection(@"URI=file:"+appdata+"info\\"+Name+"\\"+Name+".pbd");
	Connect.Open();
	System.Data.SQLite.SQLiteCommand command=new System.Data.SQLite.SQLiteCommand(query[0].ToString(), Connect);
	command.ExecuteNonQuery();
	for(int i=1;i<query.Count;i++){
		command=new System.Data.SQLite.SQLiteCommand(query[i].ToString(), Connect);
		command.ExecuteNonQuery();
	}
	command.Dispose();
	Connect.Close();
	EnabledBlockBD=true;
}

public static bool VerifyBD(string Name){
	if(!Directory.Exists(appdata+"info")) Directory.CreateDirectory(appdata+"info");
	if(!Directory.Exists(appdata+"info\\"+Name)) Directory.CreateDirectory(appdata+"info\\"+Name);
	if(!File.Exists (appdata+"info\\"+Name+"\\"+Name+".pbd")){
		CreateBD(Name);
		return true;
	} else return false;

}

public static void  CreateBD(string Name){
	EnabledBlockBD=false;
	if(!File.Exists(appdata+"info\\"+Name+"\\"+Name+".pbd")) SQLiteConnection.CreateFile(appdata+"info\\"+Name+"\\"+Name+".pbd");
	string query="CREATE TABLE "+Name+" ("+
			"id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,"+
			"idcategory,"+
			"href STRING NOT NULL,"+ 
			"title STRING,"+ 
			"txthref STRING,"+ 
			"get BOOLEAN DEFAULT FALSE,"+
			"error BOOLEAN DEFAULT FALSE,"+
			"dateload STRING,"+
			"document BOOLEAN DEFAULT FALSE,"+
			"documentload  BOOLEAN DEFAULT FALSE,"+
			"export  BOOLEAN DEFAULT FALSE,"+
			"xml TEXT," +
			"proxi STRING," +
			"port STRING," +
			"hierarchy INT," +
			"cookie TEXT)";
	SqlQuery(Name,query);
	EnabledBlockBD=true;
}

public static void DeleteBD(string Name){
	try{
	EnabledBlockBD=false;
	if(!Directory.Exists(appdata+"info")) Directory.CreateDirectory(appdata+"info");
	if(!Directory.Exists(appdata+"info\\"+Name)) Directory.CreateDirectory(appdata+"info\\"+Name);
	if(File.Exists (appdata+"info\\"+Name+"\\"+Name+".pbd")) File.Delete(appdata+"info\\"+Name+"\\"+Name+".pbd");
	} catch{
		Thread.Sleep(1000);
		DeleteBD(Name);
	}
}

	}
}